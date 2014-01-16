using UnityEngine;
using System.Collections;

public class KinectMenuOption : MonoBehaviour {
	
	private string[] options = {";  Facile",";  Moyen",";  Mortel"};
	private string[] suppl = {"  '","  +","  $"};

	private bool peuxValider = false;

	public bool[] tableauBoolPos = {false, false, false};
	public SkeletonWrapper sw;
	[HideInInspector]
	public Vector3[,] bonePos;

	public AudioClip facile;
	public AudioClip moyen;
	public AudioClip difficile;
	
	private bool pass;
	
	private bool jouerson1 = true;
	private bool jouerson2 = true;
	private bool jouerson3 = true;
	
	
	private GameObject[] menu = new GameObject[3];

	
	// Use this for initialization
	void Start () {
		bonePos = new Vector3[2,(int)Kinect.NuiSkeletonPositionIndex.Count];
		menu [0] = GameObject.Find ("GUI Text Easy");
		menu [1] = GameObject.Find ("GUI Text Medium");
		menu [2] = GameObject.Find ("GUI Text Hard");
	}
	
	// Update is called once per frame
	void Update () {
		
		if (sw.pollSkeleton ()) {
			MenuDetection ();
			
			for(int i=0;i<=2;i++)
			{
				menu[i].guiText.text = tableauBoolPos[i] ? options[i]+suppl[i] : options[i];

				if(tableauBoolPos[0]&&jouerson1)
				{
					audio.Stop();
					audio.volume = 1;
					audio.PlayOneShot(facile);
					jouerson1 = false;
				}
				
				if(tableauBoolPos[1]&&jouerson2)
				{
					audio.Stop();
					audio.volume = 1;
					audio.PlayOneShot(moyen);
					jouerson2 = false;
				}
				
				if(tableauBoolPos[2]&&jouerson3)
				{
					audio.Stop();
					audio.volume = 1;
					audio.PlayOneShot(difficile);
					jouerson3 = false;
				}
			}
			
			if (pass)
			{
				if (tableauBoolPos[0])
					Application.LoadLevel("MenuAvecMinion");
				if (tableauBoolPos[1])
					Application.LoadLevel("MenuAvecMinion");
				if (tableauBoolPos[2])
					Application.LoadLevel("MenuAvecMinion");
			}
		}
	}
	
	
	void MenuDetection()
	{
		
		Vector3 handLeft = sw.bonePos [0, (int)Kinect.NuiSkeletonPositionIndex.HandLeft];
		Vector3 handRight = sw.bonePos [0, (int)Kinect.NuiSkeletonPositionIndex.HandRight];
		
		Vector3 shoulderLeft = sw.bonePos [0, (int)Kinect.NuiSkeletonPositionIndex.ShoulderLeft];
		Vector3 shoulderRight = sw.bonePos [0, (int)Kinect.NuiSkeletonPositionIndex.ShoulderRight];
		
		Vector3 hipMiddle = sw.bonePos [0, (int)Kinect.NuiSkeletonPositionIndex.HipCenter];
		
		for (int i=0;i<=2; i++) {
			tableauBoolPos[i]=false;
		}
		
		// check
		if ((handLeft.y > shoulderLeft.y)) 
			pass = peuxValider ? true : false;
		
		//main d au dessus ep
		if ((handRight.y > shoulderRight.y)) {
						tableauBoolPos [0] = true;
			jouerson2=true;
			jouerson3=true;
				}
		
		
		//main d entre Ep et Hanche
		if ((handRight.y < shoulderRight.y) && (handRight.y > hipMiddle.y))
		{
						tableauBoolPos [1] = true;
			jouerson1=true;
			jouerson3=true;
				}
		
		// main droite sous hanche
		if ((handRight.y < hipMiddle.y)) {
						tableauBoolPos [2] = true;
			jouerson1=true;
			jouerson2=true;
				}

		//MG < Hanche
		if ((handLeft.y < hipMiddle.y))
		{
			peuxValider = true;
		}
		
	}
}
