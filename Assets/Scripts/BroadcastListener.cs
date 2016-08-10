using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class BroadcastListener : NetworkDiscovery
{

	public override void OnReceivedBroadcast (string fromAddress, string data)
	{
		NetworkMngr.IP = fromAddress;
		Application.LoadLevel (2);
	}

}