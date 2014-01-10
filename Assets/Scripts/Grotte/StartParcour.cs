using UnityEngine;
using System.Collections;

public class StartParcour : MonoBehaviour {

	public GameObject parcour1;
	public GameObject parcour2;

	// Use this for initialization
	void Start () {
		parcour1 = GameObject.Find("Parcour1");
		parcour2 = GameObject.Find("Parcour2");

		parcour1.SetActive (true);
		parcour2.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
