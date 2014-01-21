using UnityEngine;
using System.Collections;

public class GestionAffichageParcour : MonoBehaviour {

	public int nbToursPourTerminer = 1;
	private int nbToursFaits = 0;
	private Perso joueur;

	// Use this for initialization
	void Start () {
		joueur = GameObject.Find ("Personnage").GetComponent ("Perso") as Perso;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		//StartParcour script = GameObject.Find ("Parcour").GetComponent<StartParcour>() as StartParcour;
		//if (this.gameObject.name == "DisplayParcour1") 
		if (this.gameObject.name == "DisplayParcour2") 
		{
			nbToursFaits++;
			if(nbToursFaits == nbToursPourTerminer)
			{
				Fichiers.setScore(joueur.Score, joueur.niveau);
				Application.LoadLevel("Victoire");
			}
		}
	}
}
