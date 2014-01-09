using UnityEngine;
using System.Collections;
using System;

public class Collisions : MonoBehaviour {

	private Perso personage;
	private DateTime dernierVirage;
	// Use this for initialization
	void Start () {
		personage = gameObject.GetComponent ("Perso") as Perso;
	
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
		}

		if (other.gameObject.tag == "Droite") {
						SupprimeEffet virage = other.gameObject.GetComponent ("SupprimeEffet") as SupprimeEffet;
						if (!virage.traverse) {
								transform.Rotate (Vector3.up * 45f);
				transform.position = new Vector3(other.transform.parent.position.x,transform.position.y,other.transform.parent.position.z);
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
					virage.traverse = true;
				}
			}
		}
	}
}
