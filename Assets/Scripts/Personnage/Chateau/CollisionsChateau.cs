using UnityEngine;
using System.Collections;
using System;

public class CollisionsChateau : MonoBehaviour {
	
	public AudioSource sonCollision;
	public AudioSource sonBonus;
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
			personage.AltereVie (life.variation);
			if(life.variation < 0)
			{
				mouv.saut(false);
				sonCollision.Play();
			}
			else
			{
				sonBonus.Play();
			}

		}
		
		if (other.gameObject.tag == "Droite") 
		{
			SupprimeEffet virage = other.gameObject.GetComponent ("SupprimeEffet") as SupprimeEffet;
			if (!virage.traverse) 
			{
				transform.Rotate (Vector3.up * 90f);
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
					transform.Rotate (Vector3.up * -90f);
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
