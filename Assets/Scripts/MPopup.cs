using UnityEngine;
using System.Collections;

using UnityEngine.UI;
public class MPopup : MonoBehaviour
{
	public Text label;
	public Image back;
	public Button menuBtn = null;
	public Button resumeBtn = null;
	public Button replayBtn = null;
	public SoundScript Sound=null;
	public GameObject setting = null;
	private bool _isHidden=false;
	void Start(){
		InitGui();
	}

	public bool IsHidden
	{
		get
		{
			return _isHidden;
		}
		set
		{
			_isHidden = value ;
			this.gameObject.SetActive(value);
		}
	}
	public void MenuBtnDown(){
		Sound.play();
		Application.LoadLevel("Menu");
	}
	public void ReplayBtnDown(){
		Sound.play();
		Application.LoadLevel(Application.loadedLevelName);
	}
	public void SettingBtnDown(){
		Sound.play();
		setting.SetActive(true);
	}
	protected virtual  void InitGui()
    {
       

        MApplication.instance.pause = true;

        // установка попапа по центру главной камеры
        Vector3 pos = Camera.main.transform.position;
        pos.z = transform.position.z;
        transform.position = pos;
      


       

    }

}