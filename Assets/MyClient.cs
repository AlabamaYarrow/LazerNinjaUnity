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
		myClient.RegisterHandler (NetworkMngr.toClient, OnGyro);
		myClient.Connect(NetworkMngr.IP, int.Parse(NetworkMngr.PORT));
		DontDestroyOnLoad (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
//		x = x + 1;
//		var msg = new NetworkMngr.GyroPosition();
//		msg.x = x;
//		myClient.Send (NetworkMngr.fromClient, msg);
//		Debug.Log (msg);
	}

	private void OnGyro(NetworkMessage netMsg) {
		var msg = netMsg.ReadMessage<NetworkMngr.GyroPosition>();

		Quaternion transQuat = Quaternion.identity; //Adjust Unity output quaternion as per android SensorManager 
		transQuat.w = msg.gyro.x; 
		transQuat.x = msg.gyro.y; 
		transQuat.y = msg.gyro.z; 
		transQuat.z = msg.gyro.w; 

		transQuat = transQuat * Quaternion.Euler(0, 0, -90);//change axis around 
		transQuat = transQuat * Quaternion.Euler(90, 0, 0);

		Quaternion q = Quaternion.Euler (msg.gyro.eulerAngles.y, msg.gyro.eulerAngles.z, -msg.gyro.eulerAngles.x);
		//Quaternion q = Quaternion.Euler (-msg.gyro.eulerAngles.y, msg.gyro.eulerAngles.z, msg.gyro.eulerAngles.x);
		//q = Quaternion.Euler (0, 0, -90) * q;

		q = Quaternion.Euler (0, -90, 0) * q;
		//q = q * Quaternion.Euler (0, 0, 90);

		//q.eulerAngles.x = msg.gyro.eulerAngles.y;
		//q.eulerAngles.y = msg.gyro.eulerAngles.z;
		//q.eulerAngles.z = msg.gyro.eulerAngles.x;


		transform.localRotation = q;//transQuat;//msg.gyro;//transQuat;
		Debug.Log("X: " + transQuat.eulerAngles.x + " Y: " + transQuat.eulerAngles.y + " z: " + transQuat .eulerAngles.z);
	}

	public void OnConnected(NetworkMessage netMsg)
	{
		Debug.Log("Connected to server");

	}
}
