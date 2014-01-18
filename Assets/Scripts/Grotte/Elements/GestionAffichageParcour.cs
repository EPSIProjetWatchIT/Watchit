using UnityEngine;
using System.Collections;

public class GestionAffichageParcour : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		StartParcour script = GameObject.Find ("Parcour").GetComponent<StartParcour>() as StartParcour;
		if (this.gameObject.name == "DisplayParcour1") 
		{
			script.parcour2.SetActive(false);
			script.parcour1.SetActive(true);
		}
		else
		{
			script.parcour1.SetActive(false);
			script.parcour2.SetActive(true);
		}
	}
}
