using UnityEngine;
using System.Collections;
using Kinect;

public class GestureMouv : MonoBehaviour {


	private Kinect.KinectInterface kinect;
	[HideInInspector]
	public Kinect.NuiSkeletonTrackingState[] players;
	[HideInInspector]
	public int[] trackedPlayers;
	private Vector3[,] rawBonePos;
	public DeviceOrEmulator devOrEmu;
	public SkeletonWrapper sw;
	[HideInInspector]
	public Vector3[,] bonePos;
	public double tallInit;
	public bool GoLeftMouve=false;
	public bool GoRightMouve=false;
	public bool GoJump=false;

	// Use this for initialization
	void Start () {
		kinect = devOrEmu.getKinect();
		players = new Kinect.NuiSkeletonTrackingState[Kinect.Constants.NuiSkeletonCount];
		trackedPlayers = new int[Kinect.Constants.NuiSkeletonMaxTracked];
		trackedPlayers[0] = -1;



		bonePos = new Vector3[2,(int)Kinect.NuiSkeletonPositionIndex.Count];
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void GoLeft(){
		if (kinect.pollSkeleton ()) {
						Vector3 shoulderRightGo = bonePos [0, (int)Kinect.NuiSkeletonPositionIndex.ShoulderRight];
						Vector3 shoulderLeftGo = bonePos [0, (int)Kinect.NuiSkeletonPositionIndex.ShoulderLeft];
						if ((shoulderRightGo.y > shoulderLeftGo.y)) {
								GoLeftMouve = true;
						}
				}

	}

	void GoRight()
	{
		if (kinect.pollSkeleton ()) {
			Vector3 shoulderRightGo = bonePos [0, (int)Kinect.NuiSkeletonPositionIndex.ShoulderRight];
			Vector3 shoulderLeftGo = bonePos [0, (int)Kinect.NuiSkeletonPositionIndex.ShoulderLeft];
			if ((shoulderLeftGo.y > shoulderRightGo.y)) {
				GoRightMouve = true;
			}
		}
	}
	void GetInitSkeleton ()
	{
		
		Vector3 shoulderCenterInit = bonePos [0, (int)Kinect.NuiSkeletonPositionIndex.ShoulderCenter];
		Vector3 footLeftInit = bonePos [0, (int)Kinect.NuiSkeletonPositionIndex.FootLeft];
		Vector3 footRightInit = bonePos [0, (int)Kinect.NuiSkeletonPositionIndex.FootRight];


		tallInit = shoulderCenterInit.y - footLeftInit.y;
	}

	void GetJump()
	{
		if (kinect.pollSkeleton ()) {
			Vector3 shoulderRight = bonePos [0, (int)Kinect.NuiSkeletonPositionIndex.ShoulderRight];
			Vector3 footRight = bonePos [0, (int)Kinect.NuiSkeletonPositionIndex.FootRight];
			if ((shoulderRight.y-footRight.y) > (tallInit+tallInit*0.3)) {
				GoJump = true;
			}
		}
		}
}
