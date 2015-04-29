using UnityEngine;
using System.Collections;

public class NetworkCharacter : Photon.MonoBehaviour 
{
	private Vector3 playerPos;
	private Quaternion playerRot;

	void Update()
	{
		if(!photonView.isMine)
		{
			transform.position = Vector3.Lerp(transform.position, this.playerPos, Time.deltaTime * 5);
			transform.rotation = Quaternion.Lerp(transform.rotation, this.playerRot, Time.deltaTime * 5);
		}
	}

	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if(stream.isWriting)
		{
			// Data that we send to other player
			stream.SendNext(transform.position);
			stream.SendNext(transform.rotation);
		}
		else
		{
			// Data that we receive from the other player
			this.playerPos = (Vector3) stream.ReceiveNext();
			this.playerRot = (Quaternion) stream.ReceiveNext();
		}
	}
}
