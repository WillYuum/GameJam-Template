/*
* Taken from Brackeys.
* https://www.youtube.com/watch?v=6OT43pvUyfY
*/
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
	public static AudioManager instance;

	public AudioMixerGroup mixerGroup;

	public Sound[] sounds;

	void Awake()
	{
		if (instance != null)
		{
			Destroy(gameObject);
		}
		else
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}

		CreateAudioSource();
	}

	public void Play(string sound)
	{
		Sound s = Array.Find(sounds, item => item.name == sound);
		if (s == null)
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}

		s.source.volume = s.volume; /* * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));*/
		s.source.pitch = s.pitch; /** (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));*/

		s.source.Play();
	}
	
	public void Stop(string sound)
	{
		Sound s = Array.Find(sounds, item => item.name == sound);
		if (s == null)
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}

		s.source.Stop();
	}


	//Creates/adds the audio in the scene
	private void CreateAudioSource()
	{
		foreach (Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.name = s.clip.name;
			s.source.volume = s.volume;
			s.source.clip = s.clip;
			s.source.loop = s.loop;

			s.source.outputAudioMixerGroup = mixerGroup;
		}
	}


}


[System.Serializable]
public class Sound
{
	[HideInInspector]public string name;

	public bool loop = false;
	public AudioClip clip;

	[Range(0f, 1f)]
	public float volume = .75f;
	//[Range(0f, 1f)]
	//public float volumeVariance = .1f;

	[Range(.1f, 3f)]
	public float pitch = 1f;
	//[Range(0f, 1f)]
	//public float pitchVariance = .1f;

	public AudioMixerGroup mixerGroup;

	[HideInInspector]
	public AudioSource source;

}
