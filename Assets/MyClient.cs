using UnityEngine;
using System.Collections;
using UnityEngine.Networking;


public class MyClient : MonoBehaviour {
	NetworkClient myClient;

	private int x;
	// Use this for initialization
	void Start () {
		x = 0;
		if (myClient != null) {
			return;
		}
		myClient = new NetworkClient();
		myClient.RegisterHandler(MsgType.Connect, OnConnected);     
		myClient.Connect(NetworkMngr.IP, int.Parse(NetworkMngr.PORT));
		DontDestroyOnLoad (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		x = x + 1;
		var msg = new NetworkMngr.GyroPosition();
		msg.x = x;
		myClient.Send (NetworkMngr.fromClient, msg);
//		Debug.Log (msg);
	}

	public void OnConnected(NetworkMessage netMsg)
	{
		Debug.Log("Connected to server");

	}
}
