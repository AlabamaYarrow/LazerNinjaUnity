using UnityEngine;
using UnityEngine.Networking;


public class MasterMsgTypes
{
	public enum NetworkMasterServerEvent
	{
		RegistrationFailedGameName, // Registration failed because an empty game name was given.
		RegistrationFailedGameType, // Registration failed because an empty game type was given.
		RegistrationFailedNoServer, // Registration failed because no server is running.
		RegistrationSucceeded, // Registration to master server succeeded, received confirmation.
		UnregistrationSucceeded, // Unregistration to master server succeeded, received confirmation.
		HostListReceived, // Received a host list from the master server.
	}

	// -------------- client to masterserver Ids --------------

	public const short RegisterHostId = 150;
	public const short UnregisterHostId = 151;
	public const short RequestListOfHostsId = 152;

	// -------------- masterserver to client Ids --------------

	public const short RegisteredHostId = 160;
	public const short UnregisteredHostId = 161;
	public const short ListOfHostsId = 162;
	

	// -------------- client to server messages --------------

	public class RegisterHostMessage : MessageBase
	{
		public string gameTypeName;
		public string gameName;
		public string comment;
		public bool passwordProtected;
		public int playerLimit;
		public int hostPort;
	}

	public class UnregisterHostMessage : MessageBase
	{
		public string gameTypeName;
		public string gameName;
	}

	public class RequestHostListMessage : MessageBase
	{
		public string gameTypeName;
	}

	// -------------- server to client messages --------------

	public struct Room
	{
		public string name;
		public string comment;
		public bool passwordProtected;
		public int playerLimit;
		public string hostIp;
		public int hostPort;
		public int connectionId;
	}

	public class ListOfHostsMessage : MessageBase
	{
		public int resultCode;
		public Room[] hosts;
	}

	public class RegisteredHostMessage : MessageBase
	{
		public int resultCode;
	}
}
