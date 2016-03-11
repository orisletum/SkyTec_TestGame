using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;
using System;
using UnityEngine.Networking;

public class MenuScript : MonoBehaviour
{
	

	public InputField IPField;
	public InputField MaskField;


	
	void Start ()
	{
		IPField.text = "127.0.0.1";
		MaskField.text = "5300";	


	}

	public void StartGame ()
	{
		MApplication.instance.isServer=true;
		GameObject.Find ("NetworkCommander").GetComponent<NetworkManager> ().networkPort = Convert.ToInt32 (MaskField.text);
		GameObject.Find ("NetworkCommander").GetComponent<NetworkManager> ().StartServer ();
	}

	public void ShowGame ()
	{
		MApplication.instance.isServer=false;
		GameObject.Find ("NetworkCommander").GetComponent<NetworkManager> ().networkAddress = IPField.text;
		GameObject.Find ("NetworkCommander").GetComponent<NetworkManager> ().networkPort = Convert.ToInt32 (MaskField.text);
		GameObject.Find ("NetworkCommander").GetComponent<NetworkManager> ().StartClient ();
		Application.LoadLevel ("Game");
	}

	public void ExitGame ()
	{
		Application.Quit ();
	}


   
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Escape))
			OnBackClick ();
	}

	void OnBackClick ()
	{
		#if !UNITY_IPHONE
		Application.Quit ();
		#endif
       
	}

}