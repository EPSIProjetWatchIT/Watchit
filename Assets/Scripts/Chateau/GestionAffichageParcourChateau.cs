using UnityEngine;
using System.Collections;

public class GestionAffichageParcourChateau : MonoBehaviour {
	public int nbToursPourTerminer = 4;
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
		StartParcourChateau script = GameObject.Find ("Parcour").GetComponent<StartParcourChateau>() as StartParcourChateau;
		if (this.gameObject.name == "DisplayParcour1") 
		{
			script.parcour2.SetActive(false);
			script.parcour1.SetActive(true);
		}
		else
		{
			if(nbToursFaits < nbToursPourTerminer)
			{
				script.parcour1.SetActive(false);
				script.parcour2.SetActive(true);
				nbToursFaits++;
			}
			else
			{
				Fichiers.setScore(joueur.Score, 2);
				Application.LoadLevel("VictoireChateau");
			}

		}
	}
}
