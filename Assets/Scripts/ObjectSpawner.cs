using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class ObjectSpawner : NetworkBehaviour {
	public GameObject objectPrefab;
	public GameObject vrPlayer;
	// Use this for initialization
	void Start () {
		//Create a bunch of prefab objects
		for (int i = 0; i < 10; i++) {
			var spawnPosition = new Vector3 (Random.Range(-12.0f, 12.0f), Random.Range(0f, 5.0f), Random.Range(-12.0f, 12.0f));
			var spawnRotation = Quaternion.Euler (0, 0, 0);
			var column = (GameObject)Instantiate (objectPrefab, spawnPosition, spawnRotation);
			NetworkServer.Spawn(column);
		}
		//Spawn the Vive player at launch -- the object spawner will only be launched by the server
		var vive = (GameObject)Instantiate(vrPlayer, new Vector3(0,0,0), Quaternion.Euler(0,0,0));
		NetworkServer.Spawn (vive);
	}
}
