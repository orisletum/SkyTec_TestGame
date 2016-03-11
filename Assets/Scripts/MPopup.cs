using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;
public class MPopup : MonoBehaviour
{
	public Text label;
	public Image back;
	public Button menuBtn = null;
	public Button resumeBtn = null;
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
		if(MApplication.instance.isServer) 
			GameObject.Find("NetworkCommander").GetComponent<NetworkManager>().StopServer();
		else
			GameObject.Find("NetworkCommander").GetComponent<NetworkManager>().StopClient();
	}


	protected virtual  void InitGui()
    {
       

        MApplication.instance.pause = true;

       
        Vector3 pos = Camera.main.transform.position;
        pos.z = transform.position.z;
        transform.position = pos;
      


       

    }

}