//version=1.0;type=2d
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Localization {
	
	public const int KEY = 0;
	public const int RU = 1;
	public const int EN = 2;
	public const int IT = 3;
	public const int ES = 4;
	public const int PO = 5;
	public const int JP = 6;
	public const int CN = 7;
	public const int DE = 8;
	public const int FR = 9;
	public const int KR = 10;
	public const int BR = 11;
	public const int PL = 12;
	public const int TW = 13;
	
	
	public static int[] langs = new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13};
	public static string[] langMap = new string[] {"", "ru", "en", "it", "es", "po", "jp", "cn", "de", "fr", "kr", "br", "pl", "tw"};
	
	private List<string> lastFound = null;
	
	private static List<List<string>> _dictionary = null;
	
	private Localization() { 
		
	}
	
	private  static  Localization _instance;       
	
	public  static  Localization instance
	{
		get {
			if (_instance == null) {
				_instance = new  Localization ();
			}
			return _instance;
		}
	}
	public static List<List<string>> dictionary{
		get {return _dictionary;}
	}
	public static void setDictionary(List<List<string>> data){
		_dictionary = data;
	}
	
	public static void setDictionary(string csvName){
		CSVReader csv = new CSVReader (csvName);
		
		_dictionary = csv.data;
	}
	
	public static void setLanguage(string assetName)
	{
		//TextAsset text = Resources.Load(assetName) as TextAsset;
		string lng="multi";
		//string lng = text.text.ToLower();
		
		if (lng == "ko") lng = "kr";
		if (lng == "ch") lng = "cn";
		
		if (lng == "multi")
		{
			switch (Application.systemLanguage.ToString())
			{
			case "German":
				Localization.instance.lang = Localization.DE;
				break;
			case "Polish":
				Localization.instance.lang = Localization.PL;
				break;
			case "Portuguese":
				Localization.instance.lang = Localization.BR;
				break;
			case "Spanish":
				Localization.instance.lang = Localization.ES;
				break;
			case "French":
				Localization.instance.lang = Localization.FR;
				break;
			case "Chinese":
				Localization.instance.lang = Localization.CN;
				break;
			case "Japanese":
				Localization.instance.lang = Localization.JP;
				break;
			case "Italian":
				Localization.instance.lang = Localization.IT;
				break;
			case "Korean":
				Localization.instance.lang = Localization.KR;
				break;
			case "Russian":
				Localization.instance.lang = Localization.RU;
				break;
			default:
				Localization.instance.lang = Localization.EN;
				break;
			}
		}
		else {
			int index = -1;
			for (int i = 0; i < langMap.Length; i++) {
				if (langMap[i] == lng)
				{
					index = i;
					break;
				}
			}
			if (index <= 0) index = Localization.EN;
			Localization.instance.lang = index;
		}
		
	}
	
	public string getLangNameById(int id){
		switch (id) {
		case RU: return "РУС";
		case EN: return "EN";
		case IT: return "IT";
		case ES: return "ES";
		case PO: return "PO";
		case JP: return "JP";
		case CN: return "CN";
		case DE: return "DE";
		case FR: return "FR";
		case KR: return "KR";
		case BR: return "BR";
		case PL: return "PL";
		case TW: return "TW";
		default: return "EN";
		}
		
	}
	public int getLangIndexById (int id)	{
		for (int i = 0; i < langs.Length; i++) if (langs[i] == id) return i;
		return -1;
	}
	public static void determineSystemLanguage (){
		// по умолчанию english
		instance.lang = EN;
	}
	public static string getText (string key)
	{
		return instance.getTextByKey(key);
	}
	public string getTextByKey (string key){
		List<string> found = lastFound;
		
		if (checkFound(found, key)) return found[lang];
		found = find(key);
		if (found != null && found[lang] != null) return found[lang];
		return key;
	}
	
	private bool checkFound(List<string> item, string text)
	{
		if (item == null) return false;
		return (item.Count >= lang && item[0] == text);
	}
	
	private List<string> find(string text)
	{
		if (dictionary != null){
			
			for(int i = 0; i < dictionary.Count; i++){
				List<string> item = dictionary[i];
				if (checkFound(item, text))
				{
					lastFound = item;
					return lastFound;
				}
			}
		}
		return null;
	}
	
	private int _lang = 0;
	public int lang{
		get {return _lang;}
		set { 
			_lang = value;

		}
		
	}
	
}
