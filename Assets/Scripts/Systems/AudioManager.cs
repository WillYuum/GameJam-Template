using System.Collections.Generic;
using UnityEngine;
using Utils.GenericSingletons;
using AudioClasses;

public class AudioManager : MonoBehaviourSingleton<AudioManager>
{
    [SerializeField] private List<AudioConfig> _sfxConfigs;
    [SerializeField] private List<AudioConfig> _bgmConfigs;
    private List<Audio> _sfx;
    private List<Audio> _bgm;


    public void Load()
    {
        Debug.Log("Loading AudioManager");

        _sfx = new List<Audio>();
        _bgm = new List<Audio>();


        void LoadAudioConfigs(List<AudioConfig> configs, List<Audio> audios)
        {
            configs.ForEach(audioConfig =>
           {
               GameObject spawnedAudioObject = Instantiate(new GameObject(), transform);
               spawnedAudioObject.name = audioConfig.Name;
               AudioSource audioSource = spawnedAudioObject.AddComponent<AudioSource>();

#if UNITY_EDITOR
               if (audioSource == null) Debug.LogError("audioSource is null");
               if (audioConfig == null) Debug.LogError("audioConfig is null");
#endif

               audios.Add(new Audio(audioSource, audioConfig));
           });
        }

        LoadAudioConfigs(_sfxConfigs, _sfx);
        LoadAudioConfigs(_bgmConfigs, _bgm);
    }

    public void PlaySFX(string name) => Play(name, _sfx);

    public void PlayBGM(string name)
    {
        StopAllBGM();
        Play(name, _bgm);
    }

    public void StopAllBGM()
    {
        _bgm.ForEach(audio => audio.Stop());
    }





    private void Play(string audioName, List<Audio> audios)
    {
        Audio audio = audios.Find(x => x.Name == audioName);

#if UNITY_EDITOR
        if (audio == null)
        {
            Debug.LogError("Aduio not found: " + audioName);
            return;
        }
#endif

        audio.Play();
    }
}




namespace AudioClasses
{

    [System.Serializable]
    public class AudioConfig
    {
        [SerializeField] public string Name = "";
        [SerializeField] public AudioClip Clip;
        [SerializeField][Range(0f, 1.0f)] public float Volume = 1.0f;
        [SerializeField] public bool Loop = false;
        [SerializeField] public PitchProps PitchProps;
    }

    [System.Serializable]
    public class PitchProps
    {
        [SerializeField] public bool RandPitch = false;
        [SerializeField] public float Min = 0.8f;
        [SerializeField] public float Max = 1.1f;
    }



    public class Audio
    {
        private string _name;
        private AudioSource _source;


        public string Name { get => _name; }
        public bool isPlaying { get => _source.isPlaying; }

        private PitchProps _pitchProps;

        public Audio(AudioSource source, AudioConfig audioConfig)
        {
            _source = source;

            _name = audioConfig.Name;
            _source.volume = audioConfig.Volume;
            _source.clip = audioConfig.Clip;
            _source.loop = audioConfig.Loop;
            _pitchProps = audioConfig.PitchProps;
        }

        public void SetVolume(float volume)
        {
            _source.volume = volume;
        }

        public void Play()
        {
            if (_pitchProps.RandPitch)
            {
                _source.pitch = Random.Range(_pitchProps.Min, _pitchProps.Max);
            }

            _source.Play();
        }

        public void Stop()
        {
            _source.Stop();
        }
    }
}