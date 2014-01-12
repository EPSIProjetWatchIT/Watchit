using UnityEngine;
using System.Collections;

public class Affichage : MonoBehaviour {

	private Perso personnage;

	public SkeletonWrapper sw;
	// Use this for initialization
	void Start () {

		personnage = GameObject.Find("Personnage").GetComponent("Perso") as Perso;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (sw.pollSkeleton ()) {
						transform.FindChild ("Affichage Kinect").guiText.text = "true";
				} else {
			transform.FindChild ("Affichage Kinect").guiText.text = "false";
				}
		transform.FindChild ("Affichage Vie").guiText.text = personnage.Vie.ToString();
		transform.FindChild ("Affichage Score").guiText.text = personnage.Score.ToString();
	
	}
}
