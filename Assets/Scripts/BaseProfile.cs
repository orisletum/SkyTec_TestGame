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
	
	public Color HairColor
	{
		get
		{
			if (!PlayerPrefs.HasKey("HairColorR"))
			{
				PlayerPrefs.SetFloat("HairColorR",  1);
				save ();
			}
			if (!PlayerPrefs.HasKey("HairColorG"))
			{
				PlayerPrefs.SetFloat("HairColorG",  1);
				save ();
			}
			if (!PlayerPrefs.HasKey("HairColorB"))
			{
				PlayerPrefs.SetFloat("HairColorB",  1);
				save ();
			}
			return new Color(PlayerPrefs.GetFloat("HairColorR"),
			                 PlayerPrefs.GetFloat("HairColorG"),
			                  PlayerPrefs.GetFloat("HairColorB"),1);
		}
		set
		{
			PlayerPrefs.SetFloat("HairColorR", value.r);
			PlayerPrefs.SetFloat("HairColorG", value.g);
			PlayerPrefs.SetFloat("HairColorB",value.b);
			save ();
		}
	}

	
	

	

	
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
	 * Уровни
	 */
	/*
	public var levels(get_levels, null):Array<Int>;
	function get_levels ():Array<Int>
	{
		if (_so.data.levels == null)
		{
			_so.data.levels = new Array<Int>();
			_so.data.levels.push(1);
			save();
		}
		return _so.data.levels;
	}
	*/
	
	/**
	 * Добавить пройеднный уровень к списку
	 * @param	level - номер уровня
	 */
	/*
	public function addLevel (level:Int):Void
	{
		if (Utils.indexOf(levels, level) == -1)
		{
			_so.data.levels.push(level);
			
			save();
		}
	}
	*/
	
	/**
	 * Сохранить количество звёзд за уровень
	 * @param	level - номер уровня
	 * @param	stars - количество звезд: -1 звезды не используются, 0 - не пройден, 1,2,3 - пройден
	 */
	/*
	public function setStars(level:Int, stars:Int = -1):Void
	{
		if (_so.data.stars == null)
		{
			_so.data.stars = new Array<Int>();
			var l:Int = maxLevels + 1;
			for (i in 0...l) {
				_so.data.stars.push(0);
			}
		}
		if (stars > _so.data.stars[level]) _so.data.stars[level] = stars;
		save();
	}
	public var stars(get_stars, null):Array<Int>;
	function get_stars ():Array<Int>
	{
		if (_so.data.stars == null)
		{
			_so.data.stars = new Array<Int>();
			var l:Int = maxLevels + 1;
			for (i in 0...l) {
				_so.data.stars.push(0);
			}
			//_so.data.stars[1] = 0;
			save();
		}
		return _so.data.stars;
	}
	
	/**
	 * Инвентарь
	 */
	/*
	public var items(get_items, null):Array<Int>;
	function get_items ():Array<Int>
	{
		if (_so.data.items == null)
		{
			_so.data.items = new Array<Int>();
			save();
		}
		return _so.data.items;
	}
	
	function get_invertAccelerometer():Bool 
	{
		if (_so.data.invertAccelerometer == null) _so.data.invertAccelerometer = false;
		return _so.data.invertAccelerometer;
	}
	
	function set_invertAccelerometer(value:Bool):Bool 
	{
		_so.data.invertAccelerometer = value;
		save();
		return value;
	}
	
	/**
	 * Инвертировать управление акселерометром
	 */
	/*
	public var invertAccelerometer(get_invertAccelerometer, set_invertAccelerometer):Bool;
	
	function get_tutorials():Array<String> 
	{
		if (_so.data.tutorials == null) {
			_so.data.tutorials = new Array<String> ();
		}
		return _so.data.tutorials;
	}
	/**
	 * Список имен завершенных туториалов
	 */
	//public var tutorials(get_tutorials, null):Array<String>;
	/**
	 * Сохранить шаг туториала
	 * @param	id - имя туториала
	 */
	/*
	public function saveTutorial(id:String):Void {
		if (Utils.indexOf(tutorials, id) < 0) {
			_so.data.tutorials.push(id);
			save();
		}
	}
	/**
	 * Сброс всех сохранений туториала
	 */
	/*
	public function resetTutorial():Void {
		_so.data.tutorials = new Array<String> ();
		save();
	}
	/**
	 * Добавить предмет в инвентарь
	 * @param	itemId идентификатор товара в магазине
	 */
	/*
	public function addItem (itemId:Int):Void
	{
		if (items[itemId] > 0) items[itemId]++;
		else items[itemId] = 1;
		save();
	}
	
	/**
	 * Сохранить данные
	 */
	public void save ()
	{
		PlayerPrefs.Save ();
	}
}