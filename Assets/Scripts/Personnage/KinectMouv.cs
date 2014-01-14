using UnityEngine;
using System.Collections;
using Kinect;

public class KinectMouv : MonoBehaviour {
	private Mouvement mouv;
	public float ECARTEPAULES = 0.06f;
	public float HAUTEURSAUT = 0.06f;
	private bool droite = false;
	private bool gauche = false;
	public SkeletonWrapper sw;
	[HideInInspector]
	public Vector3[,] bonePos;
	public float tallInit = 0;
	public bool GoLeftMouve=false;
	public bool GoRightMouve=false;
	public bool GoJump=false;
	public bool saut=false;
	public bool isBreak;
	public bool gestPause = false;
	
	
	// Use this for initialization
	void Start () {

		mouv = gameObject.GetComponent ("Mouvement") as Mouvement;
		bonePos = new Vector3[2,(int)Kinect.NuiSkeletonPositionIndex.Count];
	}
	
	// Update is called once per frame
	void Update () {

		GoRightMouve = false;
		GoLeftMouve = false;

		if (sw.pollSkeleton ()) {
						Vector3 shoulderRightGo = sw.bonePos [0, (int)Kinect.NuiSkeletonPositionIndex.ShoulderRight];
						Vector3 shoulderLeftGo = sw.bonePos [0, (int)Kinect.NuiSkeletonPositionIndex.ShoulderLeft];

						print ("y Droite : " + shoulderRightGo.y.ToString ());
						print ("y Gauche : " + shoulderLeftGo.y.ToString ());
						print ("G - D : " + (shoulderLeftGo.y - shoulderRightGo.y).ToString ());
						print ("D - G : " + (shoulderRightGo.y - shoulderLeftGo.y).ToString ());


						//Penché
						if ((Mathf.Abs (shoulderLeftGo.y - shoulderRightGo.y)) >= ECARTEPAULES) {

								GoRightMouve = shoulderRightGo.y < shoulderLeftGo.y ? true : false;
								GoLeftMouve = shoulderLeftGo.y < shoulderRightGo.y ? true : false;
						} else {
								tallInit = tallInit == 0 ? (shoulderLeftGo.y + shoulderRightGo.y) / 2 : tallInit;
						}
			
						if (GoRightMouve && !droite) {
								mouv.Droite ();
						}
						if (GoLeftMouve && !gauche) {
								mouv.Gauche ();
						}
						gauche = GoLeftMouve;
						droite = GoRightMouve;


						//Sauté
						if ((shoulderLeftGo.y + shoulderRightGo.y) / 2 > (tallInit + HAUTEURSAUT)) {
								GoJump = true;
						} else {
								GoJump = false;
						}

						if (GoJump && !saut)
								mouv.saut ();

						saut = GoJump;
						
						MenuDetection ();
						if (isBreak && !gestPause) {
							mouv.pause ();
						}
						gestPause = isBreak;
				}
	}


	void MenuDetection()
	{
		Vector3 handRight = sw.bonePos [0, (int)Kinect.NuiSkeletonPositionIndex.HandRight];
		Vector3 handLeft = sw.bonePos [0, (int)Kinect.NuiSkeletonPositionIndex.HandLeft];
		Vector3 hipCenter = sw.bonePos [0, (int)Kinect.NuiSkeletonPositionIndex.HipCenter];
		Vector3 shoulderRight = sw.bonePos [0, (int)Kinect.NuiSkeletonPositionIndex.ElbowRight];

		print("handRight Y : "+handRight.y.ToString());
		print("handRight X : "+handRight.x.ToString());

		print("handLeft Y: "+handLeft.y.ToString());
		print ("handleft X : " + handLeft.x.ToString ());
		
		// Left and right hands below hip  &&    left hand 0.3 to left of center hip
		if ((handRight.y < hipCenter.y) && (handRight.x > hipCenter.x + 0.3)) 
		{
			isBreak = true;

		}
		else
		{
			isBreak = false;
		}
	}
}
