using UnityEngine;
using System.Collections;
using DG.Tweening;
public class BallScript : MonoBehaviour
{
	public int BallType = 1;

	void OnCollisionEnter2D (Collision2D kk)
	{
		if (kk.gameObject.name == "player")
			GameScript.instance.TypeBall ();
		else if (kk.gameObject.name == "GameOver")
			GameScript.instance.Complete (false, 0);
	}


	public void MoveXAgain ()
	{
		
		transform.DOMoveX (transform.position.x + Random.Range (-0.5f, 0.5f), 0.2f).OnComplete (MoveYAgain);
	}

	public void MoveYAgain ()
	{
		
		transform.DOMoveY (transform.position.y - Random.Range (1f, 2f), 0.4f).OnComplete (MoveXAgain);
	}

	public void AlphaChangerAgain (float val)
	{
		GetComponent<SpriteRenderer> ().material.DOFade (val, 1f).OnComplete (
			delegate {
				AlphaChangerAgain ((val ==  0.5f) ? 1 : 0.5f);
			}
		);
	}

	public void DestroyBall ()
	{
		GameScript.instance.ScoreUp (BallType);
		transform.DOPause ();
		GetComponent<SpriteRenderer> ().material.DOPause();
		GetComponent<Rigidbody2D>().isKinematic=true;
		Destroy (GetComponent<CircleCollider2D> (), 0.1f);
		GetComponent<SpriteRenderer> ().material.DOFade (0, 1).OnComplete (
			delegate() {
				Destroy (this.gameObject, 1);
			} 
		);
	}
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
