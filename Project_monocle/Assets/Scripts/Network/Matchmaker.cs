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

		// pour test; a enlever
		CreateGame();
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

		Vector3 spawnPos;
		Quaternion spawnRot = Quaternion.identity;

		if(PhotonNetwork.isMasterClient)
		{
			spawnPos.x = GameObject.Find("Spawn 1").transform.position.x;
			spawnPos.y = GameObject.Find("Spawn 1").transform.position.y + 10;
			spawnPos.z = GameObject.Find("Spawn 1").transform.position.z;
		}
		else
		{
			spawnPos.x = GameObject.Find("Spawn 2").transform.position.x;
			spawnPos.y = GameObject.Find("Spawn 2").transform.position.y + 10;
			spawnPos.z = GameObject.Find("Spawn 2").transform.position.z;
		}

		GameObject player = PhotonNetwork.Instantiate("Player", spawnPos, spawnRot, 0);
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
