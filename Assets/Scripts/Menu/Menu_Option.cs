using UnityEngine;
using System.Collections;

public class Menu_Option : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnMouseUp(){
		GameObject.Find ("Main Camera").SetActive (false);
		GameObject.Find ("Camera Option").SetActive (true);
	}
}
