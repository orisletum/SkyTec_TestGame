using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
public class FinishScript : MPopup 
{

    public static bool shown = false;

    protected override void InitGui()
    {
        base.InitGui();

		shown = true;

       
       
    }
	public void ResumeBtnDown(){
		Sound.play();
		MApplication.instance.pause = false;
		GameScript.instance.TypeBall();
		this.gameObject.SetActive(false);
	}
   	

     void OnBackClick()
    {
		
		if(MApplication.instance.isServer) 
			GameObject.Find("NetworkCommander").GetComponent<NetworkManager>().StopServer();
		else
			GameObject.Find("NetworkCommander").GetComponent<NetworkManager>().StopClient();
    }
}