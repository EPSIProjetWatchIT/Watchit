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
		StartParcour script = GameObject.Find ("Parcour").GetComponent<StartParcour>() as StartParcour;
		if (this.gameObject.name == "DisplayParcour1") 
		{
			nbToursFaits++;
			if(nbToursFaits < nbToursPourTerminer)
			{
				script.parcour2.SetActive(false);
				script.parcour1.SetActive(true);
			}
			else
			{
				Fichiers.setScore(joueur.Score, 1);
				Application.LoadLevel("Victoire");
			}
		}
		else
		{
			script.parcour1.SetActive(false);
			script.parcour2.SetActive(true);
		}
	}
}
