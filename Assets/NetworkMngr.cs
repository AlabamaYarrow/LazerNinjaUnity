using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class NetworkMngr : MonoBehaviour {

	public class GyroPosition : MessageBase {
		public int x;
	}

	public const short toClient = 160;
	public static short fromClient = 150;
	
	public static string IP = "127.0.0.1";
	public static string PORT = "1488";



	public string toEdit;

	public bool isAtStartup = true;

	void Start () {
		Input.gyro.enabled = true;
		Input.gyro.updateInterval = 0.01F;
	}
	void Update () 
	{
		if (!isAtStartup) {
			toEdit = Input.gyro.attitude.ToString();

		}
	}
	
	void OnGUI()
	{
		GUI.Label (new Rect (2, 70, 200, 200), toEdit);
		if (isAtStartup)
		{
			IP = GUI.TextField(new Rect(2, 30, 150, 30), IP);
			PORT = GUI.TextField(new Rect(2, 70, 150, 30), PORT);
			if (GUI.Button(new Rect(2,10, 150, 15), "start server")) {
				SetupServer();
			}
			if (GUI.Button(new Rect(2, 110, 150, 15), "start client")) {
				SetupClient();
			}
		}

	}   
	// Create a server and listen on a port
	public void SetupServer()
	{
		NetworkServer.Listen(int.Parse(PORT));
		NetworkServer.RegisterHandler(fromClient, onGyroMessage);
		isAtStartup = false;
	}
	
	// Create a client and connect to the server port
	public void SetupClient()
	{
		Application.LoadLevel (1);
	}	

	private void onGyroMessage(NetworkMessage netMsg){
		Debug.Log ("gyroMessage");
		var msg = netMsg.ReadMessage<NetworkMngr.GyroPosition>();
		toEdit = msg.x.ToString ();
	}

}