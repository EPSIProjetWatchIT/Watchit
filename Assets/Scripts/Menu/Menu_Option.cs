using UnityEngine;
using System.Collections;

public class Menu_Option : MonoBehaviour {

	float vitesse = 0;
	GameObject camera;
	int compt = 0;

	// Use this for initialization
	void Start () {
		camera = GameObject.Find ("Main Camera").gameObject;
	}
	
	// Update is called once per frame
	void Update () {

		if (compt <= 100) {
			camera.transform.Translate (Vector3.right * vitesse * Time.deltaTime);
			compt ++;
		} else {
			vitesse = 0;
		}
	}

	void OnMouseUp(){
		//vitesse = 1;
		GameObject.Find ("Main Camera").SetActive (false);
		GameObject.Find ("Camera Option").SetActive (true);
	}
}
