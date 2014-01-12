using UnityEngine;
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
		kinect = devOrEmu.getKinect();
		players = new Kinect.NuiSkeletonTrackingState[Kinect.Constants.NuiSkeletonCount];
		trackedPlayers = new int[Kinect.Constants.NuiSkeletonMaxTracked];
		trackedPlayers[0] = -1;



	}
	
	// Update is called once per frame
	void Update () {

		int handRight = (int)Kinect.NuiSkeletonPositionIndex.HandRight;
		if (sw == null) {
			return;
		}
		if (sw.pollSkeleton ()) {
			
			rawBonePos[0, handRight] = kinect.getSkeleton().SkeletonData[trackedPlayers[0]].SkeletonPositions[handRight];


		}
	
	}
}
