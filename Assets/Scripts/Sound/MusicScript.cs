using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MusicScript : MonoBehaviour
{
	public static Hashtable musics;

    AudioClip menuMusic;

    public string[] sceneName;
    public AudioClip[] sceneMusic;

    Dictionary<string, AudioClip> clipDictionary;

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
			if (musics != null)
			{
				foreach (MusicScript music in musics.Values)
				{
					music.GetComponent<AudioSource>().volume = _volume;
				}
			}
		}
	}

	void Awake ()
	{
        clipDictionary = new Dictionary<string, AudioClip>();
        int lengthCount = Mathf.Min(sceneName.Length, sceneMusic.Length);
        for (int i = 0; i < lengthCount; i++)
        {
            if (sceneName[i] != "" && sceneMusic[i] != null)
            {
                clipDictionary.Add(sceneName[i], sceneMusic[i]);
            }
        }

        if (musics == null)
        {
            musics = new Hashtable();
        }

		GetComponent<AudioSource>().volume = _volume;

		if (!musics.ContainsKey(name))
		{
			musics.Add(name, this);
			DontDestroyOnLoad (this);
            menuMusic = GetComponent<AudioSource>().clip;
		}
		else
		{
			GetComponent<AudioSource>().Stop();
			Destroy(gameObject);
		}
	}

	public void play ()
	{
		GetComponent<AudioSource>().Play ();
	}
	
	public static void stop (string name)
	{
		foreach (MusicScript music in musics)
		{
			if (music.gameObject.name == name)
			{
				music.GetComponent<AudioSource>().Stop ();
				return;
			}
		}
	}
	
	public static void stopAll ()
	{
		foreach(MusicScript music in musics.Values)
		{
			music.GetComponent<AudioSource>().Stop();
		}
	}

    void Update()
    {
        if (Application.loadedLevelName.Equals("Menu"))
        {
            if (GetComponent<AudioSource>().clip != menuMusic)
            {
                GetComponent<AudioSource>().clip = menuMusic;
                GetComponent<AudioSource>().Play();
            }
        }
        else
        {
            if (clipDictionary.ContainsKey(Application.loadedLevelName))
            {
                AudioClip newClip;
                clipDictionary.TryGetValue(Application.loadedLevelName, out newClip);
                if (GetComponent<AudioSource>().clip != newClip)
                {
                    GetComponent<AudioSource>().clip = newClip;
                    GetComponent<AudioSource>().Play();
                }
            }
        }
    }
}
