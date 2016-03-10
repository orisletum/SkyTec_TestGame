using UnityEngine;
using System.Collections;

public class MApplication
{
	public BaseProfile profile;
	public int currentLevel = 0;
	private int curScore;
	public bool isServer=false;
	public int MaskField;
	public string IPField;
	public int CurScore {
		get {
			return curScore;
		}
		set {
			curScore = value;
		}
	}

	public bool pause {
		get {
			return Time.timeScale == 0;
		}
		set {
			Time.timeScale = value ? 0 : 1;
		}
	}

	static MApplication _instance;

	public static MApplication instance {
		get {
			if (_instance == null) {
				_instance = new MApplication ();
			
			}
			return _instance;
		}
	}

	private MApplication ()
	{
        

		profile = new BaseProfile ();

		SoundScript.volume = profile.soundVolume;
		MusicScript.volume = profile.musicVolume;

		Localization.setDictionary ("xml/localisation");
		Localization.setLanguage ("language");

		Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}

   





	public static bool GetValueFromFile (string fileName)
	{
		try {
			string filename = fileName;
			TextAsset text = Resources.Load (filename) as TextAsset;

			return bool.Parse (text.text);
		} catch {
			Debug.LogError ("File " + fileName + " not found");

			return false;
		}
	}
}