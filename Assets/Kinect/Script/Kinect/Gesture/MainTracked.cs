﻿using UnityEngine;
using System.Collections;
using Kinect;


public class MainTracked : MonoBehaviour {

	private SkeletonWrapper sw;
	[HideInInspector]
	public Kinect.NuiSkeletonTrackingState[] players;
	[HideInInspector]
	public int[] trackedPlayers;
	private Vector3[,] rawBonePos;
	public DeviceOrEmulator devOrEmu;

	private Kinect.KinectInterface kinect;
	// Use this for initialization
	void Start () {
	
		players = new Kinect.NuiSkeletonTrackingState[Kinect.Constants.NuiSkeletonCount];
		trackedPlayers = new int[Kinect.Constants.NuiSkeletonMaxTracked];
		trackedPlayers[0] = -1;


	}
	
	// Update is called once per frame
	void Update () {



		if (sw.pollSkeleton ()) {
			int handRight = (int)Kinect.NuiSkeletonPositionIndex.HandRight;
			//sw.bonePos[0,handRight];
						//rawBonePos [0, handRight] = kinect.getSkeleton ().SkeletonData [trackedPlayers [0]].SkeletonPositions [handRight];
			transform.position = new Vector3 (sw.bonePos[0,handRight].x, sw.bonePos[0,handRight].y, transform.position.z);


		
				} else {
			transform.position=new Vector3(0.82f,0.38f,1f);
				}
	
	}
}
