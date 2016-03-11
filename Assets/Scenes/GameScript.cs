using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;
//using System;
public class GameScript : MonoBehaviour
{
	public GameObject Player=null;

	public bool isServer;
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

		MApplication.instance.pause = false;
		ScoreUp(0);

		if(!MApplication.instance.isServer) {
			Destroy(CurBall,0);
			GameObject.Find("LeftButton").SetActive(false);
			GameObject.Find("RightButton").SetActive(false);
		}

	}
	public void ScoreUp(int UpVal){
		CurScore+=UpVal;
		ScoreText.text="Score: "+CurScore.ToString();
		if(CurScore>(GameDifficulty*40+10) && GameDifficulty<3) GameDifficulty++;

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
		if(MApplication.instance.isServer) 
		GameObject.Find("NetworkCommander").GetComponent<NetworkManager>().StopServer();
		else
		GameObject.Find("NetworkCommander").GetComponent<NetworkManager>().StopClient();
	}




	public void Complete ()
	{
		
		MenuUI.GetComponent<FinishScript> ().IsHidden = true;
		Debug.Log ("123");
		FinishScript c = MenuUI.GetComponent<FinishScript> ();
		c.label.text = Localization.getText ("lose");
	}


	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Escape))
			OnBackClick ();
	}

	void OnBackClick ()
	{
        
		if (!MApplication.instance.pause)
			Complete();
	}

}