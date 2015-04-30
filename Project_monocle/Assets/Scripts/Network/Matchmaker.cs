using UnityEngine;
using System.Collections;

public class Matchmaker : MonoBehaviour 
{
	private int playerCount;

	void Start()
	{
		PhotonNetwork.ConnectUsingSettings("v1.0");

		PhotonView.DontDestroyOnLoad(this.gameObject);
	}

	void OnGUI()
	{
		GUILayout.Label(PhotonNetwork.connectionState.ToString());
	}

	void OnJoinedLobby()
	{
		Debug.Log("Joined lobby");
	}

	void OnPhotonRandomJoinFailed()
	{
		Debug.Log ("Can't join random room");
	}

	void OnCreatedRoom()
	{
		Debug.Log ("room created");
		//PhotonNetwork.LoadLevel("GameTest");
	}

	void OnJoinedRoom()
	{
		Debug.Log ("room joined");

		Destroy(GameObject.Find("Canvas"));

		GameObject player = PhotonNetwork.Instantiate("Player", Vector3.zero, Quaternion.identity, 0);
		Camera camera = player.transform.Find("Camera").GetComponent<Camera>();
		camera.enabled = true;
	}

	public void CreateGame()
	{
		RoomOptions options = new RoomOptions();
		options.maxPlayers = 2;
		options.isOpen = true;
	
		PhotonNetwork.CreateRoom(null, options, null);
	}

	public void JoinGame()
	{
		PhotonNetwork.JoinRandomRoom();
	}

	void OnLevelWasLoaded()
	{

	}
}
