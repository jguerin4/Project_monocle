using UnityEngine;
using System.Collections;

public class SimpleMove : MonoBehaviour 
{

	private float speed;
	private PhotonView pv;

	// Use this for initialization
	void Start () 
	{
		transform.GetComponent<Renderer>().material.color = Color.red;

		speed = 0.1f;
		pv = PhotonView.Get(this);

		PhotonView.DontDestroyOnLoad(this.gameObject);
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
			if(Input.GetKeyDown(KeyCode.E))
			{
				this.pv.RPC ("ChangeScene", PhotonTargets.All);
			}
		}
	}

	[RPC]
	public void ChangeColor()
	{
		if(transform.GetComponent<Renderer>().material.color == Color.red)
		{
			transform.GetComponent<Renderer>().material.color = Color.blue;
		}
		else
		{
			transform.GetComponent<Renderer>().material.color = Color.red;
		}
	}

	[RPC]
	public void ChangeScene()
	{
		PhotonNetwork.LoadLevel("GameTest");
	}
}
