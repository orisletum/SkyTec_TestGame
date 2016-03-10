using UnityEngine;
using System.Collections;

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
		Application.LoadLevel("Game");
	}
   	

     void OnBackClick()
    {
		
        Application.LoadLevel("Menu");
    }
}