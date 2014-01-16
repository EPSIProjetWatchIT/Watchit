using UnityEngine;
using System.Collections;

public class FinCine : MonoBehaviour {


	private float TempsDebut=0f;
	public float delais = 5f;
	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
		TempsDebut += Time.deltaTime;
		if (TempsDebut >= delais)
		{
			Application.LoadLevel("MenuAvecMinion");
		}


	
	}
}
