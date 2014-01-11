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
			script.parcour1.SetActive(true);
			script.parcour2.SetActive(false);
		}
		else
		{
			script.parcour1.SetActive(false);
			script.parcour2.SetActive(true);
		}
	}
}
