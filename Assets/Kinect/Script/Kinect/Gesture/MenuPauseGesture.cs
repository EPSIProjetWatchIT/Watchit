using UnityEngine;
using System.Collections;

public class MenuPauseGesture : MonoBehaviour {

	public SkeletonWrapper sw;

	private Vector3[,] rawBonePos;

	private Vector3[,] bonePos;
	public bool isBreak=false;


	// Use this for initialization
	void Start () {

		bonePos = new Vector3[2, (int)Kinect.NuiSkeletonPositionIndex.Count];
	}
	
	// Update is called once per frame
	void Update () {
		MenuDetection ();
	}


	void MenuDetection()
	{
		isBreak = false;

	if (sw.pollSkeleton ()) {
			
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
