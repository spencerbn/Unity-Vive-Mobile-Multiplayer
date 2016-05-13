using System;
using UnityEngine;
using System.Collections;

public class CameraStereo : MonoBehaviour
{
	public float Distance = 0.1f;
	public float Degree = 0f;

	private GameObject _cameraLeft;
	private GameObject _cameraRight;
	private float leftCameraX;
	private float leftCameraDegree;
	private float rightCameraX;
	private float rightCameraDegree;

	// Use this for initialization
	void Start () {
		// Disable screen dimming
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		_cameraLeft=GameObject.Find("LeftSight");
		_cameraRight=GameObject.Find("RightSight");
	}

	void Awake()
	{
		// Disable screen dimming
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}

	// Update is called once per frame
	void Update ()
	{
		leftCameraX = -Distance / 2;
		rightCameraX = Distance / 2;
		leftCameraDegree = Degree / 2;
		rightCameraDegree = -Degree / 2;
		const double tolerance = 0.000000000000000001;
		// Adjust rotations
		if (Math.Abs(leftCameraDegree - _cameraLeft.transform.localRotation.y) > tolerance)
			_cameraLeft.transform.localRotation = new Quaternion(_cameraLeft.transform.localRotation.x, leftCameraDegree, _cameraLeft.transform.localRotation.z, _cameraLeft.transform.localRotation.w);
		if (Math.Abs(rightCameraDegree - _cameraRight.transform.localRotation.y) > tolerance)
			_cameraRight.transform.localRotation = new Quaternion(_cameraRight.transform.localRotation.x, rightCameraDegree, _cameraRight.transform.localRotation.z, _cameraRight.transform.localRotation.w);
		// Adjust x positions of cameras
		if (Math.Abs(leftCameraX - _cameraLeft.transform.localPosition.x) > tolerance)
			_cameraLeft.transform.localPosition = new Vector3(leftCameraX,_cameraLeft.transform.localPosition.y, _cameraLeft.transform.localPosition.z);
		if (Math.Abs(rightCameraX - _cameraRight.transform.localPosition.x) > tolerance)
			_cameraRight.transform.localPosition = new Vector3(rightCameraX, _cameraRight.transform.localPosition.y, _cameraRight.transform.localPosition.z);
	}
}
