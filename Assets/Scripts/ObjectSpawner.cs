using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class ObjectSpawner : MonoBehaviour {
	public GameObject objectPrefab;

	// Use this for initialization
	void Start () {
		//Create a bunch of prefab objects
		for (int i = 0; i < 10; i++) {
			var spawnPosition = new Vector3 (Random.Range(-12.0f, 12.0f), Random.Range(0f, 5.0f), Random.Range(-12.0f, 12.0f));
			var spawnRotation = Quaternion.Euler (0, 0, 0);
			var column = (GameObject)Instantiate (objectPrefab, spawnPosition, spawnRotation);
			NetworkServer.Spawn(column);
		}
	}
}
