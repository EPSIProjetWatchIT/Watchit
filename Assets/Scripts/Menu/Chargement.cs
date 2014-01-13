using UnityEngine;
using System.Collections;

public class Chargement : MonoBehaviour {
	GameObject[] listeGui;
	GameObject guiChargement;

	// Use this for initialization
	void Start () {
		listeGui = GameObject.FindGameObjectsWithTag ("GuiMenu");
		guiChargement = GameObject.Find ("Affichage chargement");
		guiChargement.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseUp()
	{
		foreach (GameObject gui in listeGui) {
			gui.SetActive(false);		
		}
		guiChargement.SetActive (true);
	}
}
