using UnityEngine;
using System.Collections;

public class MenuPauseGesture : MonoBehaviour {

	private SkeletonWrapper sw;
	[HideInInspector]
	public Kinect.NuiSkeletonTrackingState[] players;
	[HideInInspector]
	public int[] trackedPlayers;
	private Vector3[,] rawBonePos;
	public DeviceOrEmulator devOrEmu;
	private Vector3[,] bonePos;
	public bool isBreak=false;
	private Kinect.KinectInterface kinect;

	// Use this for initialization
	void Start () {
		kinect = devOrEmu.getKinect();
		players = new Kinect.NuiSkeletonTrackingState[Kinect.Constants.NuiSkeletonCount];
		trackedPlayers = new int[Kinect.Constants.NuiSkeletonMaxTracked];
		trackedPlayers[0] = -1;

		
		bonePos = new Vector3[2, (int)Kinect.NuiSkeletonPositionIndex.Count];
	}
	
	// Update is called once per frame
	void Update () {
		MenuDetection ();
	}


	void MenuDetection()
	{
		isBreak = false;

	if (kinect.pollSkeleton ()) {
			
			Vector3 handRight = bonePos [0, (int)Kinect.NuiSkeletonPositionIndex.HandRight];
			Vector3 handLeft = bonePos [0, (int)Kinect.NuiSkeletonPositionIndex.HandLeft];
			Vector3 hipCenter = bonePos [0, (int)Kinect.NuiSkeletonPositionIndex.HipCenter];
			Vector3 elbowLeft = bonePos [0, (int)Kinect.NuiSkeletonPositionIndex.ElbowLeft];

						// Left and right hands below hip
						if (handLeft.y < hipCenter.y && handRight.y < hipCenter.y) {
								// left hand 0.3 to left of center hip
								if (handLeft.x < hipCenter.x - 0.3) {
										// left hand 0.2 to left of left elbow
										if (handLeft.x < elbowLeft.x - 0.2) {
											isBreak=true;
										}
								}
			
						}
		
						
				}
		}
}
