using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class PlayerController : NetworkBehaviour {

	public Camera leftEye;
	public Camera rightEye;

	// Use this for initialization
	void Start () {
		if (isLocalPlayer) {
			return;
		}
		
		leftEye.enabled = false;
		rightEye.enabled = false;
	}
}
