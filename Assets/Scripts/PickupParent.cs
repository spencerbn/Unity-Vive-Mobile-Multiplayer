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
	}

	void OnTriggerStay(Collider col){
		Debug.Log ("Colliding with " + col.name);

		if (col.tag == "Player")
		{
			//Debug.Log("Colliding with Player");
			PlayerController colController = col.GetComponent<PlayerController>();

			//If holding down the trigger, then move the object
			if (device.GetPress(SteamVR_Controller.ButtonMask.Trigger))
			{
				//Should be making a network call to change the objects position
				colController.RpcSetPosition(this.gameObject.transform.position);
			}
		}
	}
}
