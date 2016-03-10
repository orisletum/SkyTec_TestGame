using UnityEngine;
using System.Collections;
using DG.Tweening;
public class PlayerScript : MonoBehaviour {
	private float LastXPos=0,DistancePos=0;
	// Use this for initialization
	void Start () {
		LastXPos=transform.position.x;
	}
	public void MovePlayer(float dis){
		LastXPos+=dis;
		transform.DOMoveX(LastXPos,1);

	}
	// Update is called once per frame
//	void FixedUpdate () {
//		if (!MApplication.instance.pause){
//			
//			DistancePos=Mathf.Abs(LastXPos-Camera.main.ScreenToWorldPoint(Input.mousePosition).x);
////			if(DistancePos>0.2f){
//				LastXPos=Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
//				transform.DOMoveX(LastXPos,DistancePos/2f);
//
////			}
//		}
//	}
}
