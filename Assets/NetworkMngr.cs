using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class NetworkMngr : MonoBehaviour {

	public class GyroPosition : MessageBase {
		public Quaternion gyro;
	}

	public const short toClient = 160;
	public static short fromClient = 150;
	
	public static string IP = Network.player.ipAddress;
	public static string PORT = "1188";



	public InstantGuiInputText IPText;

	public bool isAtStartup = true;

	void Start () {
		IPText.text = IP;
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		Input.gyro.enabled = true;
		Input.gyro.updateInterval = 0.01F;
		SetupServer();
	}
	void Update () 
	{
		if (!isAtStartup) {

			sendGyro();
		}
	}
	
	void OnGUI()
	{
//		GUI.Label (new Rect (2, 70, 500, 500), toEdit);
//		if (isAtStartup) {
//			IP = GUI.TextField(new Rect(2, 200, 450, 90), IP);
//			PORT = GUI.TextField(new Rect(2, 300, 450, 90), PORT);
//			if (GUI.Button(new Rect(2,40, 450, 120), "start server")) {
		//				SetupServer();
//			}
//			if (GUI.Button(new Rect(2, 350, 450, 120), "start client")) {
//				SetupClient();
//			}
//		}

	}   
	// Create a server and listen on a port
	public void SetupServer(){
		NetworkServer.Listen(int.Parse(PORT));
		NetworkServer.RegisterHandler(fromClient, onGyroMessage);
		isAtStartup = false;
	}
	
	// Create a client and connect to the server port
	public void SetupClient()
	{
		Application.LoadLevel (2);
	}	

	private void sendGyro() {
		var msg = new GyroPosition ();
		msg.gyro = Input.gyro.attitude;
		NetworkServer.SendToAll (toClient, msg);
	}

	private void onGyroMessage(NetworkMessage netMsg){
		Debug.Log ("gyroMessage");
//		var msg = netMsg.ReadMessage<NetworkMngr.GyroPosition>();
//		toEdit = msg.x.ToString ();
	}

}