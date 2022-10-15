using System.Collections.Generic;
using UnityEngine;
using Utils.GenericSingletons;
using AudioClasses;

public class AudioManager : MonoBehaviourSingleton<AudioManager>
{
    [SerializeField] private List<AudioConfig> _sfxConfigs;
    private List<Audio> _sfx;
    private List<Audio> _bgm;


    public void Load()
    {
        Debug.Log("Loading AudioManager");

        _sfx = new List<Audio>();
        _bgm = new List<Audio>();


        _sfxConfigs.ForEach(audioConfig =>
        {
            GameObject spawnedAudioObject = Instantiate(new GameObject(), transform);
            spawnedAudioObject.name = audioConfig.Name;
            AudioSource audioSource = spawnedAudioObject.AddComponent<AudioSource>();

#if UNITY_EDITOR
            if (audioSource == null) Debug.LogError("audioSource is null");
            if (audioConfig == null) Debug.LogError("audioConfig is null");
#endif

            _sfx.Add(new Audio(audioSource, audioConfig));
        });
    }

    public void PlaySFX(string name) => Play(name, _sfx);

    public void PlayBGM(string name) => Play(name, _bgm);





    private void Play(string audioName, List<Audio> audios)
    {
        Audio audio = audios.Find(x => x.Name == audioName);

#if UNITY_EDITOR
        if (audio == null)
        {
            Debug.LogError("SFX not found: " + audioName);
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
    }



    public class Audio
    {
        private string _name;
        private AudioSource _source;


        public string Name { get => _name; }
        public bool isPlaying { get => _source.isPlaying; }


        public Audio(AudioSource source, AudioConfig audioConfig)
        {
            _source = source;

            _name = audioConfig.Name;
            _source.volume = audioConfig.Volume;
            _source.clip = audioConfig.Clip;
            _source.loop = audioConfig.Loop;
        }

        public void SetVolume(float volume)
        {
            _source.volume = volume;
        }

        public void Play()
        {
            _source.Play();
        }

        public void Stop()
        {
            _source.Stop();
        }
    }
}