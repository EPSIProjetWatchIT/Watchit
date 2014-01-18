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
	private float tempsInitail;
	
	
	// Use this for initialization
	void Start () {
		tempsInitail = Time.timeScale;
		mouv = gameObject.GetComponent ("Mouvement") as Mouvement;
		bonePos = new Vector3[2,(int)Kinect.NuiSkeletonPositionIndex.Count];
	}
	
	// Update is called once per frame
	void Update () {

		GoRightMouve = false;
		GoLeftMouve = false;

		if (sw.pollSkeleton ()) 
		{
			Vector3 shoulderRightGo = sw.bonePos [0, (int)Kinect.NuiSkeletonPositionIndex.ShoulderRight];
			Vector3 shoulderLeftGo = sw.bonePos [0, (int)Kinect.NuiSkeletonPositionIndex.ShoulderLeft];
			Vector3 handRight = sw.bonePos [0, (int)Kinect.NuiSkeletonPositionIndex.HandRight];
			Vector3 handLeft = sw.bonePos [0, (int)Kinect.NuiSkeletonPositionIndex.HandLeft];
			Vector3 hipCenter = sw.bonePos [0, (int)Kinect.NuiSkeletonPositionIndex.HipCenter];
			
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
			
			//Pause
			if ((handRight.y < hipCenter.y) && (handRight.x > hipCenter.x + 0.3)) 
			{
				isBreak = true;
				
			}
			else
			{
				isBreak = false;
			}
			if (isBreak && !gestPause) {
				mouv.pause ();
			}
			gestPause = isBreak;
			
			//MenuPendantPause
			if ((handLeft.y < hipCenter.y) && Time.timeScale == 0f && handRight.y > hipCenter.y) 
			{
				Time.timeScale = tempsInitail;
				Application.LoadLevel("MenuAvecMinion");
			}
				
				
		}
	}
	
}
