using UnityEngine;
using System.Collections;

public class SimpleMove : MonoBehaviour {

	private float speed;
	private PhotonView pv;

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
			if(Input.GetKey(KeyCode.W))
			{
				transform.Translate(transform.forward * speed);
			}
			if(Input.GetKey(KeyCode.S))
			{
				transform.Translate(-transform.forward * speed);
			}
			if(Input.GetKey(KeyCode.D))
			{
				transform.Translate(transform.right * speed);
			}
			if(Input.GetKey(KeyCode.A))
			{
				transform.Translate(-transform.right * speed);
			}
		}
	}
}
