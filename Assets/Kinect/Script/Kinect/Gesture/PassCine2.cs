using UnityEngine;
using System.Collections;

public class PassCine2 : MonoBehaviour {
	public SkeletonWrapper sw;
	[HideInInspector]
	public Vector3[,] bonePos;




	
	
	// Use this for initialization
	void Start () {
		bonePos = new Vector3[2,(int)Kinect.NuiSkeletonPositionIndex.Count];
	}
	
	// Update is called once per frame
	void Update () {
		if (sw.pollSkeleton ()) {
		
			Vector3 shoulderLeftGo = sw.bonePos [0, (int)Kinect.NuiSkeletonPositionIndex.ShoulderLeft];
			
	
			print ("y Gauche : " + shoulderLeftGo.y.ToString ());
	
					
					
			if (MenuDetection ()) {
				Application.LoadLevel("Scene_Chateau_2");
			}

		}
	}
	
	
	bool MenuDetection()
	{
		bool pass=false;
		Vector3 handLeft = sw.bonePos [0, (int)Kinect.NuiSkeletonPositionIndex.HandLeft];

		Vector3 shoulderLeft = sw.bonePos [0, (int)Kinect.NuiSkeletonPositionIndex.ShoulderRight];
		

		
		print("handLeft Y: "+handLeft.y.ToString());
		print ("handleft X : " + handLeft.x.ToString ());
		
		// Left and right hands below hip  &&    left hand 0.3 to left of center hip
		if ((handLeft.y > shoulderLeft.y)) 
			pass=true;

			return pass;

	}
}
