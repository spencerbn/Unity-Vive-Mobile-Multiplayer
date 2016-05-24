using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class PlayerController : NetworkBehaviour {

	public Camera leftEye;
	public Camera rightEye;

	[SyncVar]
	Vector3 playerPosition = new Vector3(0,2,0);

	// Use this for initialization
	void Start () {
		if (isLocalPlayer) {
			return;
		}
		
		leftEye.enabled = false;
		rightEye.enabled = false;
	}

	void Update()
	{
		if (!isLocalPlayer)
		{
			return;
		}

		this.gameObject.transform.position = playerPosition;
		Debug.Log(this.gameObject.transform.position);
	}

	[ClientRpc]
	public void RpcSetPosition(Vector3 position)
	{
		playerPosition = position;
	}
}
