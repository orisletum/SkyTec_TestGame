using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;
//using System;
public class GameScript : MonoBehaviour
{
	public GameObject Player=null;

	public bool isServer=false;
	public int MaskField;
	public string IPField;
	public Text ScoreText=null;
	public int CurScore=0;
	public GameObject CurBall = null;
	public GameObject PrefabBall = null;
	public GameObject MenuUI = null;
	public Canvas CanvasUP = null;
	private int GameDifficulty = 0;
	static GameScript _instance;

	public static GameScript instance {
		get {
			if (_instance == null) {
				_instance = GameObject.FindObjectOfType<GameScript> ();
			}
			return _instance;
		}
	}


	void Start ()
	{
//		MenuUI.GetComponent<FinishScript>().IsHidden=false;
//		pause.GetComponent<MPause>().IsHidden=false;
		MApplication.instance.pause = false;
		ScoreUp(0);
		MaskField=MApplication.instance.MaskField;
		IPField=MApplication.instance.IPField;
		isServer=MApplication.instance.isServer;
		if(isServer) CreateServer();
		else 
			ConnectServer();
	}
	public void ScoreUp(int UpVal){
		CurScore+=UpVal;
		ScoreText.text="Score: "+CurScore.ToString();
		if(CurScore>(GameDifficulty*40+10) && GameDifficulty<3) GameDifficulty++;

	}
	void CreateServer(){
		Network.InitializeServer(10, MaskField, false);
	}
	void ConnectServer(){
		Network.Connect(IPField, MaskField);
	}
	void OnPlayerDisconnected (NetworkPlayer pl) {
		Network.RemoveRPCs(pl);
		Network.DestroyPlayerObjects(pl);
	}
	void OnSerializeNetworkView (BitStream stream, NetworkMessageInfo info) {
		Vector3 syncPosition = Vector3.zero;
		if (stream.isWriting) {

			syncPosition = Player.transform.position;

			stream.Serialize(ref syncPosition);




		} else {
			stream.Serialize(ref syncPosition);



		}
	}
	void DefaultBalls ()
	{

		GameObject Ball = Instantiate (PrefabBall) as GameObject;
		Vector3 ObjPos = CurBall.transform.position;
		Ball.GetComponent<SpriteRenderer> ().color = new Color (Random.Range (0f, 1f), Random.Range (0f, 1f), Random.Range (0f, 1f), 1);
		Ball.transform.position = new Vector3 (Random.Range (-2f, 2f), 10, ObjPos.z);
		Ball.GetComponent<Rigidbody2D> ().gravityScale = 0.5f;
		Ball.name = "Ball1";
		Ball.GetComponent<BallScript>().BallType=1;
		CurBall.GetComponent<BallScript> ().DestroyBall ();
		CurBall = Ball;
	}

	void SecondTypeBalls ()
	{

		GameObject Ball = Instantiate (PrefabBall) as GameObject;
		Vector3 ObjPos = CurBall.transform.position;
		Ball.GetComponent<SpriteRenderer> ().color = new Color (Random.Range (0f, 1f), Random.Range (0f, 1f), Random.Range (0f, 1f), 1);
		Ball.transform.position = new Vector3 (0, 10, ObjPos.z);
		Ball.name = "Ball2";
		Ball.GetComponent<Rigidbody2D> ().gravityScale = 0;
		Ball.GetComponent<BallScript>().BallType=2;
		Ball.transform.DOLocalMoveY (-Random.Range (-3f, 0f), 1).OnComplete (
			delegate() {
				Ball.GetComponent<BallScript> ().MoveXAgain ();
			}
		);
		CurBall.GetComponent<BallScript> ().DestroyBall ();
		CurBall = Ball;
	}
	void ThirdTypeBalls ()
	{

		GameObject Ball = Instantiate (PrefabBall) as GameObject;
		Vector3 ObjPos = CurBall.transform.position;
		Ball.GetComponent<SpriteRenderer> ().color = new Color (Random.Range (0f, 1f), Random.Range (0f, 1f), Random.Range (0f, 1f), 1);
		Ball.transform.position = new Vector3 (Random.Range (-2f, 2f), 10, ObjPos.z);
		Ball.GetComponent<Rigidbody2D> ().gravityScale = 0.5f;
		Ball.name = "Ball3";
		Ball.GetComponent<BallScript>().BallType=1;
		Ball.GetComponent<BallScript>().AlphaChangerAgain(0);
		CurBall.GetComponent<BallScript> ().DestroyBall ();
		CurBall = Ball;
	}
	void FourthTypeBalls ()
	{

		GameObject Ball = Instantiate (PrefabBall) as GameObject;
		Vector3 ObjPos = CurBall.transform.position;
		Ball.GetComponent<SpriteRenderer> ().color = new Color (Random.Range (0f, 1f), Random.Range (0f, 1f), Random.Range (0f, 1f), 1);
		Ball.transform.position = new Vector3 (0, 10, ObjPos.z);
		Ball.name = "Ball4";
		Ball.GetComponent<Rigidbody2D> ().gravityScale = 0;
		Ball.GetComponent<BallScript>().BallType=2;
		Ball.transform.DOLocalMoveY (-Random.Range (-3f, 0f), 1).OnComplete (
			delegate() {
				Ball.GetComponent<BallScript> ().MoveXAgain ();
			}
		);
		Ball.GetComponent<BallScript>().AlphaChangerAgain(0);
		CurBall.GetComponent<BallScript> ().DestroyBall ();
		CurBall = Ball;
	}
	public void TypeBall ()
	{
		switch (Random.Range (GameDifficulty, 5)) {
		case 0:
			DefaultBalls ();
			break;
		case 1:
			SecondTypeBalls ();
			break;
		case 2:
			ThirdTypeBalls();
			break;
		case 3:
			SecondTypeBalls ();
			break;
		case 4:
			 FourthTypeBalls();
			break;
		default:
			DefaultBalls ();
			break;
		}
	}

	public void ExitGame ()
	{
		Application.LoadLevel ("Menu");
	}

	void showPause ()
	{
		if (MPause.shown || FinishScript.shown)
			return;
		GameObject p = Instantiate (MenuUI) as GameObject;
		MPause c = p.GetComponent<MPause> ();
	}

	void showFinish (string text)
	{
		
//        if (MFinish.shown || MPause.shown) return;
		MenuUI.GetComponent<FinishScript> ().IsHidden = true;
		Debug.Log ("123");
		FinishScript c = MenuUI.GetComponent<FinishScript> ();
		c.label.text = text;
	}

	public void Complete (bool complete, int stars)
	{
		showFinish (Localization.getText (complete ? "win" : "lose"));

		if (complete) {
			//Событие выигрыша этого уровня
            
			//GameObject.Find("win").GetComponent<MSound>().play();
			MApplication.instance.profile.levels = MApplication.instance.currentLevel + 1;

		} else {
			//GameObject.Find("lose").GetComponent<MSound>().play();
		

//			if(MApplication.instance.profile.LvlCharacter>1) MApplication.instance.profile.LvlCharacter--;
		}
	}

	void OnApplicationFocus (bool focusStatus)
	{
       
		if (!focusStatus) {
			#if !UNITY_EDITOR
            showPause();
			#endif
		}
	}

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Escape))
			OnBackClick ();
	}

	void OnBackClick ()
	{
        
		if (!MApplication.instance.pause)
			showPause ();
	}

}