using UnityEngine;
using System.Collections;

public class MenuPauseGesture : MonoBehaviour {

	public SkeletonWrapper sw;

	private Vector3[,] bonePos;
	public bool isBreak=false;

	private Mouvement mouv;


	// Use this for initialization
	void Start () {
		mouv = gameObject.GetComponent ("Mouvement") as Mouvement;
		bonePos = new Vector3[2, (int)Kinect.NuiSkeletonPositionIndex.Count];
	}
	
	// Update is called once per frame
	void Update () {
		MenuDetection ();
		if (isBreak) {
			mouv.pause();
				}

	}


		void MenuDetection()
		{
		if (sw.pollSkeleton ()) {
				
				Vector3 handRight = bonePos [0, (int)Kinect.NuiSkeletonPositionIndex.HandRight];
				Vector3 handLeft = bonePos [0, (int)Kinect.NuiSkeletonPositionIndex.HandLeft];
				Vector3 hipCenter = bonePos [0, (int)Kinect.NuiSkeletonPositionIndex.HipCenter];
				Vector3 elbowRight = bonePos [0, (int)Kinect.NuiSkeletonPositionIndex.ElbowRight];

							// Left and right hands below hip
							if (handLeft.y < hipCenter.y && handRight.y < hipCenter.y) {
									// left hand 0.3 to left of center hip
									if (handRight.x < hipCenter.x - 0.3) {
											// left hand 0.2 to left of left elbow
											if (handRight.x > elbowRight.x - 0.2) {
												isBreak=true;
											}
									}
				
							}
			
							
					}
			}
}
