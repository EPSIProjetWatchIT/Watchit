using UnityEngine;
using System.Collections;

public class KinectMebu : MonoBehaviour {

	private string[] options = {";  JOUER",";  OPTIONS",";  QUITTER"};
	private string[] suppl = {"  '","  +","  $"};
	private bool peuxValider = false;

	public AudioClip jouer;
	public AudioClip option;
	public AudioClip quitter;
	public AudioClip chateau;

	private float tallInit;

	private bool[] tableauBoolPos = {false, false, false};
	public SkeletonWrapper sw;
	[HideInInspector]
	public Vector3[,] bonePos;
	
	private bool pass;

	private bool jouerson1 = true;
	private bool jouerson2 = true;
	private bool jouerson3 = true;

	private bool niveauChateau = false;

	private GameObject[] menu = new GameObject[3];

	GameObject[] listeGui;
	GameObject guiChargement;

	// Use this for initialization
	void Start () {
		bonePos = new Vector3[2,(int)Kinect.NuiSkeletonPositionIndex.Count];
		menu [0] = GameObject.Find ("GUI Text Jouer");
		menu [1] = GameObject.Find ("GUI Text Option");
		menu [2] = GameObject.Find ("GUI Text Quitter");
		listeGui = GameObject.FindGameObjectsWithTag ("GuiMenu");
		guiChargement = GameObject.Find ("Affichage chargement");
		guiChargement.guiText.text = "";
		if (sw.pollSkeleton ()) 
		{
			 tallInit = sw.bonePos [0, (int)Kinect.NuiSkeletonPositionIndex.ShoulderRight].y;
		}
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
					audio.PlayOneShot(jouer);
					jouerson1 = false;
				}

				if(tableauBoolPos[1]&&jouerson2)
				{
					audio.Stop();
					audio.volume = 1;
					audio.PlayOneShot(option);
					jouerson2 = false;
				}

				if(tableauBoolPos[2]&&jouerson3)
				{
					audio.Stop();
					audio.volume = 1;
					audio.PlayOneShot(quitter);
					jouerson3 = false;
				}

				if(niveauChateau)
				{
					audio.Stop();
					audio.volume = 1;
					audio.PlayOneShot(chateau);
					foreach (GameObject gui in listeGui) {
						gui.SetActive(false);		
					}
					guiChargement.guiText.text = "Chargement...";
					Application.LoadLevel("Transition");

				}

			}

			if (pass && peuxValider)
			{
				if (tableauBoolPos[0]){
					foreach (GameObject gui in listeGui) {
						gui.SetActive(false);		
					}
					guiChargement.guiText.text = "Chargement...";
					Application.LoadLevel ("Scene_grotte");
				}

				if (tableauBoolPos[1])
					Application.LoadLevel("MenuOption");
				if (tableauBoolPos[2])
					Application.Quit();
			}
		}
	}
	
	
	void MenuDetection()
	{

		Vector3 handLeft = sw.bonePos [0, (int)Kinect.NuiSkeletonPositionIndex.HandLeft];
		Vector3 handRight = sw.bonePos [0, (int)Kinect.NuiSkeletonPositionIndex.HandRight];
		
		Vector3 shoulderLeft = sw.bonePos [0, (int)Kinect.NuiSkeletonPositionIndex.ShoulderLeft];
		Vector3 shoulderRight = sw.bonePos [0, (int)Kinect.NuiSkeletonPositionIndex.ShoulderRight];
		Vector3 head = sw.bonePos [0, (int)Kinect.NuiSkeletonPositionIndex.Head];

		Vector3 hipMiddle = sw.bonePos [0, (int)Kinect.NuiSkeletonPositionIndex.HipCenter];

		for (int i=0;i<=2; i++) {
			tableauBoolPos[i]=false;
				}
	
		// check
		if ((handLeft.y < hipMiddle.y)) 
			peuxValider = true;

		//MG > Epaule
		if ((handLeft.y > shoulderLeft.y))
			pass = peuxValider ? true : false;

		//main d au dessus ep
		if ((handRight.y > shoulderRight.y)) {
			tableauBoolPos [0] = true;
			jouerson3 = true;
			jouerson2 = true;
		}
		//Geste secret !!
		if (handRight.y > head.y) {

			if (shoulderRight.y < (tallInit / 2)) {
				niveauChateau = true;
				jouerson2 = true;
				jouerson1 = true;
				jouerson3 = true;
			}
		}

		//main d entre Ep et Hanche
		if ((handRight.y < shoulderRight.y) && (handRight.y > hipMiddle.y)) {
			tableauBoolPos [1] = true;
			jouerson1 = true;
			jouerson3 = true;
		}
		
		// main droite sous hanche
		if ((handRight.y < hipMiddle.y)) {
			tableauBoolPos [2] = true;
			jouerson2 = true;
			jouerson1 = true;
		}
		
	}
}
