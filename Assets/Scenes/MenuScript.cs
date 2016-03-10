using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;
using System;
public class MenuScript : MonoBehaviour
{
	public GameObject pause = null;
	public GameObject finish = null;

	public InputField IPField;
	public InputField MaskField;
	public bool connected;			// Статус подключения

	
	 void Start ()
	{
		IPField.text = "127.0.0.1";
		MaskField.text = "5300";	


	}
	public void StartGame(){
		MApplication.instance.isServer=true;
		MApplication.instance.MaskField=Convert.ToInt32(MaskField.text);
		Application.LoadLevel("Game");
	}	
	public void ShowGame(){
		MApplication.instance.isServer=false;
		MApplication.instance.MaskField= Convert.ToInt32(MaskField.text);
		MApplication.instance.IPField=IPField.text;
		Application.LoadLevel("Game");
	}
	public void ExitGame(){
		Application.Quit();
	}
    

    void OnApplicationFocus(bool focusStatus)
    {
       
        if (!focusStatus)
        {
            #if !UNITY_EDITOR
            showPause();
            #endif
        }
    }

	void Update(){
		if (Input.GetKeyDown(KeyCode.Escape)) OnBackClick();
	}

    void OnBackClick()
    {
		#if !UNITY_IPHONE
		Application.Quit();
		#endif
       
    }

}