using UnityEngine;
using System.Collections;

public class GestureGoRight : MonoBehaviour {
	
	private Vector3[,] rawBonePos;
	
	public SkeletonWrapper sw;
	[HideInInspector]
	public Vector3[,] bonePos;
	public double tallInit;

	public bool GoRightMouve=false;
	// Use this for initialization
	void Start () {
		bonePos = new Vector3[2,(int)Kinect.NuiSkeletonPositionIndex.Count];
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void GoRight()
	{
		if (sw.pollSkeleton ()) {
			Vector3 shoulderRightGo = bonePos [0, (int)Kinect.NuiSkeletonPositionIndex.ShoulderRight];
			Vector3 shoulderLeftGo = bonePos [0, (int)Kinect.NuiSkeletonPositionIndex.ShoulderLeft];
			if ((shoulderLeftGo.y > shoulderRightGo.y)) {
				GoRightMouve = true;
			}
		}
	}
}
