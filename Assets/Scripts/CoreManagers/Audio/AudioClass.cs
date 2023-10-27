using UnityEngine;
using System;
using DG.Tweening;

namespace AudioClasses
{

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

        public void SetVolume(float volume, float durationToVolume)
        {
            _source.DOFade(volume, durationToVolume);
        }

        public void Play()
        {
            if (_pitchProps.RandPitch)
            {
                _source.pitch = UnityEngine.Random.Range(_pitchProps.Min, _pitchProps.Max);
            }

            _source.Play();
        }

        public void Stop()
        {
            _source.Stop();
        }
    }



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



}