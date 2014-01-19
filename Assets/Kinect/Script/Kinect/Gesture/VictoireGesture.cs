using UnityEngine;
using System.Collections;

public class VictoireGesture : MonoBehaviour {
	
	private string[] options = {";  SUIVANT",";  QUITTER"};
	private string[] suppl = {"  '","  $"};
	private bool peuxValider = false;
	private bool jouerson1 = true;
	private bool jouerson2 = true;

	private string scene = "Transition";

	public AudioClip recommencer;
	public AudioClip quitter;
	
	private bool[] tableauBoolPos = {false, false};
	public SkeletonWrapper sw;
	[HideInInspector]
	public Vector3[,] bonePos;
	
	private bool pass;
	
	
	
	
	private GameObject[] menu = new GameObject[2];
	
	
	
	// Use this for initialization
	void Start () {
		bonePos = new Vector3[2,(int)Kinect.NuiSkeletonPositionIndex.Count];
		menu [0] = GameObject.Find ("GUI Text Suivant");
		menu [1] = GameObject.Find ("GUI Text Quitter");
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (sw.pollSkeleton ()) {
			MenuDetection ();
			

				menu[0].guiText.text = tableauBoolPos[0] ? options[0]+suppl[0] : options[0];
				menu[1].guiText.text = tableauBoolPos[1] ? options[1]+suppl[1] : options[1];

				if(tableauBoolPos[0] && jouerson1)
				{
					//audio.Stop();
					audio.volume = 1;
					audio.PlayOneShot(recommencer);
					jouerson1 = false;
				}
				
				if(tableauBoolPos[1] && jouerson2)
				{
					//audio.Stop();
					audio.volume = 1;
					audio.PlayOneShot(quitter);
					jouerson2 = false;
				}
			
				

			
			if (pass && peuxValider)
			{
				if (tableauBoolPos[0])
					Application.LoadLevel(scene);
				if (tableauBoolPos[1])
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
		
		for (int i=0;i<=1; i++) {
			tableauBoolPos[i]=false;
		}
		
		// check
		if ((handLeft.y < hipMiddle.y)) 
			peuxValider = true;
		
		//MG > Epaules
		if ((handLeft.y > shoulderLeft.y))
		{
			pass = peuxValider ? true : false;
		}
		
		//main d au dessus ep
		if ((handRight.y > shoulderRight.y)) {
			tableauBoolPos [0] = true;
			jouerson2 = true;
		}
		
		//main d entre Ep et Hanche
		if ((handRight.y < shoulderRight.y) && (handRight.y > hipMiddle.y)) {
			tableauBoolPos [1] = true;
			jouerson1 = true;
		}
	
	}
}
