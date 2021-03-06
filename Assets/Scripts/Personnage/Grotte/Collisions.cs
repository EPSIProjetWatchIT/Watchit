﻿using UnityEngine;
using System.Collections;
using System;

public class Collisions : MonoBehaviour {

	public AudioSource sonCollision;
	private Perso personage;
	private static SupprimeEffet viragePrecedent = null;
	private Mouvement mouv;
	// Use this for initialization
	void Start () {
		personage = gameObject.GetComponent ("Perso") as Perso;
		mouv = gameObject.GetComponent ("Mouvement") as Mouvement;

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{

		if (other.gameObject.tag == "lifeChanger")
		{
			LifeChanges life = other.gameObject.GetComponent("LifeChanges") as LifeChanges;
			if(life.destruction)
				other.gameObject.SetActive(false);
			personage.AltereVie (life.variation);
			mouv.saut(false);
			sonCollision.Play();
		}

		if (other.gameObject.tag == "Droite") 
		{
			SupprimeEffet virage = other.gameObject.GetComponent ("SupprimeEffet") as SupprimeEffet;
			if (!virage.traverse) 
			{
				transform.Rotate (Vector3.up * 45f);
				transform.position = new Vector3(other.transform.parent.position.x,transform.position.y,other.transform.parent.position.z);
				if(viragePrecedent != null)
					viragePrecedent.traverse = false;
				viragePrecedent = virage;
				virage.traverse = true;
			}
		}
		else
		{
			if (other.gameObject.tag == "Gauche") {
				SupprimeEffet virage = other.gameObject.GetComponent ("SupprimeEffet") as SupprimeEffet;
				if (!virage.traverse)
				{
					transform.Rotate (Vector3.up * -45f);
					transform.position = new Vector3(other.transform.parent.position.x,transform.position.y,other.transform.parent.position.z);
					if(viragePrecedent != null)
						viragePrecedent.traverse = false;
					viragePrecedent = virage;
					virage.traverse = true;
				}
			}
		}
	}
}
