using UnityEngine;
using System.Collections;

[RequireComponent (typeof(SteamVR_TrackedObject))]
public class PickupParent : MonoBehaviour {

	SteamVR_TrackedObject trackedObj;
	SteamVR_Controller.Device device;
	void Awake () {
		trackedObj = GetComponent<SteamVR_TrackedObject> ();
	}

	void Update(){
		
	}

	void FixedUpdate () {
		device = SteamVR_Controller.Input ((int)trackedObj.index);
		if (device.GetPressDown (SteamVR_Controller.ButtonMask.Trigger)) {
			Debug.Log ("Touch down the trigger");
		}
	}

	void OnTriggerStay(Collider col){
		Debug.Log ("Colliding with " + col.name);

		if (device.GetPressDown (SteamVR_Controller.ButtonMask.Trigger)) {
			col.attachedRigidbody.isKinematic = true;
			col.transform.position = this.gameObject.transform.position;
		}
	}
}
