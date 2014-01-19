using UnityEngine;
using System.Collections;

public class FinCine2 : MonoBehaviour {


	private float TempsDebut=0f;
	public float delais;
	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
		TempsDebut += Time.deltaTime;
		if (TempsDebut >= delais)
		{
			Application.LoadLevel("Scene_Chateau_2");
		}


	
	}
}
