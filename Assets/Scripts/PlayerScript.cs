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
		if((dis<0 && LastXPos<-3) || (dis>0 && LastXPos>3))
			dis*=-1;
		LastXPos+=dis;
		transform.DOMoveX(LastXPos,1);

	}

}
