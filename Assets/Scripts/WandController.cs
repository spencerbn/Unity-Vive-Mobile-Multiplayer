using UnityEngine;
using System.Collections;

public class WandController : MonoBehaviour {

	//This particular wand
	private SteamVR_TrackedObject trackedObj;
	private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input ((int)trackedObj.index);}}

			// Use this for initialization
	void Start () {
		trackedObj = GetComponent<SteamVR_TrackedObject>();
	}
	
	// Update is called once per frame
	void Update () {
		if (controller == null) {
			Debug.Log ("No Controller Found.");
			return;
		}
	}
}
