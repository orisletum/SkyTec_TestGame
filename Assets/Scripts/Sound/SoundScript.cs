using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundScript : MonoBehaviour
{

	public static List<SoundScript> sounds;
    public static List<SoundScript> soundsResume;

    [Range(0, 1)]
    public float localVolume = 1f;

	static float _volume;
	public static float volume
    {
		get
		{
			return _volume;
		}
		set
		{
			_volume = value;
			if (sounds != null)
			{
                soundsResume = new List<SoundScript>();
				foreach (SoundScript sound in sounds)
				{
                    sound.GetComponent<AudioSource>().volume = _volume;
				}
			}
		}
	}

    public float pitch
    {
        get
        {
            return GetComponent<AudioSource>().pitch;
        }
        set
        {
            GetComponent<AudioSource>().pitch = value;
        }
    }

    public AudioClip clip
    {
        get
        {
            return GetComponent<AudioSource>().clip;
        }
        set
        {
            GetComponent<AudioSource>().clip = value;
        }
    }

    public bool loop
    {
        get
        {
            return GetComponent<AudioSource>().loop;
        }
        set
        {
            GetComponent<AudioSource>().loop = value;
        }
    }

	void Awake ()
	{
		if (sounds == null) sounds = new List<SoundScript> ();
        GetComponent<AudioSource>().volume = _volume * localVolume;
		if (!sounds.Contains(this)) sounds.Add (this);
	}

	public void play (float delay = 0f)
	{
        GetComponent<AudioSource>().volume = _volume * localVolume;
        if (delay > 0f)
        {
            GetComponent<AudioSource>().PlayDelayed(delay);
        }
        else
        {
            GetComponent<AudioSource>().Play();
        }
	}

	public void stop ()
	{
		GetComponent<AudioSource>().Stop();
	}

    public void pause()
    {
        GetComponent<AudioSource>().Pause();
    }

    public bool isPlaying()
    {
        return GetComponent<AudioSource>().isPlaying;
    }

	public static void stop (string name)
	{
		foreach (SoundScript sound in sounds)
		{
			if (sound.gameObject.name == name)
			{
				sound.GetComponent<AudioSource>().Stop ();
				return;
			}
		}
	}
	
	public static void stopAll ()
	{
		foreach(SoundScript sound in sounds)
		{
			sound.GetComponent<AudioSource>().Stop();
		}
	}

    public static void pauseAll()
    {
        foreach (SoundScript sound in sounds)
        {
            if (sound.GetComponent<AudioSource>().isPlaying)
            {
                sound.GetComponent<AudioSource>().Pause();
                soundsResume.Add(sound);
            }
        }
    }

    public static void resumeAll()
    {
        foreach (SoundScript sound in soundsResume)
        {
            sound.play();
        }
        soundsResume.Clear();
    }
	void OnDestroy()
	{
		sounds.Remove(this);
	}
}