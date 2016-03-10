using UnityEngine;
using System.Collections;

public class MPause : MPopup 
{

    public static bool shown = false;

    protected override void InitGui()
    {
        base.InitGui();

        shown = true;

        

		label.GetComponent<LabelScript>().text = Localization.getText("pause");

    }
	public void ResumeBtnDown(){
		Sound.play();
		Destroy(gameObject);
	}
    void OnDestroy()
    {
        shown = false;
        MApplication.instance.pause = false;
    }

    void OnBackClick()
    {
      
        Destroy(gameObject);
    }
}