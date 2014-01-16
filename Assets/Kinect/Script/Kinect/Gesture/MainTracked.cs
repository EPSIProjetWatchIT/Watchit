using UnityEngine;
using System.Collections;
using Kinect;


public class MainTracked : MonoBehaviour {

	public SkeletonWrapper sw;

	private Vector3[,] rawBonePos;



	private Kinect.KinectInterface kinect;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {



		if (sw.pollSkeleton ()) {
			int handRight = (int)Kinect.NuiSkeletonPositionIndex.HandRight;
			//sw.bonePos[0,handRight];
						//rawBonePos [0, handRight] = kinect.getSkeleton ().SkeletonData [trackedPlayers [0]].SkeletonPositions [handRight];

			transform.position = new Vector3 (sw.bonePos[0,handRight].x, sw.bonePos[0,handRight].y, transform.position.z);
			//sphere.transform.position = 


		
				} else {
			transform.position=new Vector3(0,0,0);
				}
	
	}
}
