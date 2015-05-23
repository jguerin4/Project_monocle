using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	private float mousePosX;
	private float mousePosY;
	private PhotonView pv;

	public float speed;

	// Use this for initialization
	void Start () 
	{
		speed = 0.1f;
		pv = PhotonView.Get(this);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(pv.isMine)
		{
			mousePosX = Input.mousePosition.x;
			mousePosY = Input.mousePosition.y;

			if(mousePosX >= (Screen.width - Screen.width * 0.25))
			{
				transform.Translate(transform.right * speed);
			}
			if(mousePosX <= (Screen.width * 0.25))
			{
				transform.Translate(-transform.right * speed);
			}
			if(mousePosY >= (Screen.height - Screen.height * 0.25))
			{
				transform.Translate(transform.forward * speed);
			}
			if(mousePosY <= (Screen.height * 0.25))
			{
				transform.Translate(-transform.forward * speed);
			}
		}

		//Debug.Log ("X: " + mousePosX + " Y: " + mousePosY + " screen x: " + Screen.width + " screen y: " + Screen.height);
	}
}
