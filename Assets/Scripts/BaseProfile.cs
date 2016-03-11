using UnityEngine;
using System.Collections;

public class BaseProfile
{

	/**
	 * Максимальное количество уровней
	 */
	public int maxLevels = 20;
	public float XMin;
	public float XMax;
	public BaseProfile () 
	{
	}
	
	
	public string wings
	{
		get
		{
			if (!PlayerPrefs.HasKey("wings"))
			{
				PlayerPrefs.SetString("wings", "wings1");
				save ();
			}
			return PlayerPrefs.GetString("wings");
		}
		set
		{
			PlayerPrefs.SetString("wings", value);
			save ();
		}
	}
	
//	public Color HairColor
//	{
//		get
//		{
//			if (!PlayerPrefs.HasKey("HairColorR"))
//			{
//				PlayerPrefs.SetFloat("HairColorR",  1);
//				save ();
//			}
//			if (!PlayerPrefs.HasKey("HairColorG"))
//			{
//				PlayerPrefs.SetFloat("HairColorG",  1);
//				save ();
//			}
//			if (!PlayerPrefs.HasKey("HairColorB"))
//			{
//				PlayerPrefs.SetFloat("HairColorB",  1);
//				save ();
//			}
//			return new Color(PlayerPrefs.GetFloat("HairColorR"),
//			                 PlayerPrefs.GetFloat("HairColorG"),
//			                  PlayerPrefs.GetFloat("HairColorB"),1);
//		}
//		set
//		{
//			PlayerPrefs.SetFloat("HairColorR", value.r);
//			PlayerPrefs.SetFloat("HairColorG", value.g);
//			PlayerPrefs.SetFloat("HairColorB",value.b);
//			save ();
//		}
//	}

	
	

	

	
	/**
	 * Звук
	 */
	public bool isSound
	{
		get
		{
			if (!PlayerPrefs.HasKey("isSound"))
			{
				PlayerPrefs.SetInt("isSound", 1);
				save ();
			}
			return PlayerPrefs.GetInt("isSound") == 1;
		}
		set
		{
			PlayerPrefs.SetInt("isSound", value?1:0);
			save ();
		}
	}
	
	/**
	 * Музыка
	 */
	public bool isMusic
	{
		get
		{
			if (!PlayerPrefs.HasKey("isMusic"))
			{
				PlayerPrefs.SetInt("isMusic", 1);
				save ();
			}
			return PlayerPrefs.GetInt("isMusic") == 1;
		}
		set
		{
			PlayerPrefs.SetInt("isMusic", value?1:0);
			save ();
		}
	}
	
	/**
	 * Громкость звуков
	 */
	public float soundVolume
	{
		get
		{
			if (!PlayerPrefs.HasKey("soundVolume"))
			{
				PlayerPrefs.SetFloat("soundVolume", 1);
				save ();
			}
			return PlayerPrefs.GetFloat("soundVolume");
		}
		set
		{
			PlayerPrefs.SetFloat("soundVolume", value);
			save ();
		}
	}

	/**
	 * Громкость музыки
	 */
	public float musicVolume
	{
		get
		{
			if (!PlayerPrefs.HasKey("musicVolume"))
			{
				PlayerPrefs.SetFloat("musicVolume", 1);
				save ();
			}
			return PlayerPrefs.GetFloat("musicVolume");
		}
		set
		{
			PlayerPrefs.SetFloat("musicVolume", value);
			save ();
		}
	}
	
	
	
	/**
	 * score
	 */
	public int score
	{
		get
		{
			if (!PlayerPrefs.HasKey("score"))
			{
				PlayerPrefs.SetInt("score", 0);
				save ();
			}
			return PlayerPrefs.GetInt("score");
		}
		set
		{
			PlayerPrefs.SetInt("score", value);
			save ();
		}
	}
	
	/**
	 * gold
	 */
	public int gold
	{
		get
		{
			if (!PlayerPrefs.HasKey("gold"))
			{
				PlayerPrefs.SetInt("gold", 0);
				save ();
			}
			return PlayerPrefs.GetInt("gold");
		}
		set
		{
			PlayerPrefs.SetInt("gold", value);
			save ();
		}
	}

    public int getStars(int id)
    {     
        if (!PlayerPrefs.HasKey("level" + id))
        {
            PlayerPrefs.SetInt("level" + id, 0);
            save();
        }
        return PlayerPrefs.GetInt("level" + id);
    }

    public void setStars(int id, int value)
    {
        PlayerPrefs.SetInt("level" + id, value);
        save();
    }

    public int levels
    {
        get
        {
            if (!PlayerPrefs.HasKey("maxLevel"))
            {
                PlayerPrefs.SetInt("maxLevel", 1);
                
                save();
            }
            return PlayerPrefs.GetInt("maxLevel");
        }
        set
        {
            if (!PlayerPrefs.HasKey("maxLevel") || levels <= value)
            {
                Debug.Log("save");
                PlayerPrefs.SetInt("maxLevel", value+1);
                save();
            }
        }
    }

	/**
	 * Сохранить данные
	 */
	public void save ()
	{
		PlayerPrefs.Save ();
	}
}