/// <summary>
/// Client v2.
/// Разработанно командой Sky Games
/// sgteam.ru
/// </summary>
using UnityEngine;
using System.Collections;

public class Client: MonoBehaviour {
	
	public Camera cam;				// ссылка на нашу камеру


	private CharacterController controller;	// ссылка на контроллер
	
	private float lastSynchronizationTime = 0f;
	private float syncDelay = 0f;
	private float syncTime = 0f;
	private Vector3 syncStartPosition = Vector3.zero;
	private Vector3 syncEndPosition = Vector3.zero;

	// При создании объекта со скриптом
	void Awake () {
		cam = transform.GetComponentInChildren<Camera>().GetComponent<Camera>();
		
		controller = GetComponent<CharacterController>();
			

	
	}
	
	// на каждый кадр
	void Update () {
		if(GetComponent<NetworkView>().isMine) {
			
		
        	
		} else {
			if(cam.enabled) { 
				cam.enabled = false; 
				cam.gameObject.GetComponent<AudioListener>().enabled = false;
			}
			SyncedMovement();
		}
	}
	
	// Вызывается с определенной частотой. Отвечает за сереализицию переменных
	void OnSerializeNetworkView (BitStream stream, NetworkMessageInfo info) {
    	Vector3 syncPosition = Vector3.zero;
	    if (stream.isWriting) {
			
        	syncPosition = transform.position;
			
        	stream.Serialize(ref syncPosition);

    	} else {
        	stream.Serialize(ref syncPosition);

			


			

 
			// Расчеты для интерполяции
			
			// Находим время между текущим моментом и последней интерполяцией
        	syncTime = 0f;
        	syncDelay = Time.time - lastSynchronizationTime;
        	lastSynchronizationTime = Time.time;
 
        	syncStartPosition = transform.position;
        	syncEndPosition = syncPosition;
			Debug.Log(GetComponent<NetworkView>().viewID + " " + syncStartPosition + " " + syncEndPosition);
    	}
	}
	
	// Интерполяция
	private void SyncedMovement() {
    	syncTime += Time.deltaTime;
    	transform.position = Vector3.Lerp(syncStartPosition, syncEndPosition, syncTime / syncDelay);
	}
	

}
