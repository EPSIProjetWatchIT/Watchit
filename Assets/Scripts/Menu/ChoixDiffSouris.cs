using UnityEngine;
using System.Collections;

public class ChoixDiffSouris : MonoBehaviour {

	public int niveau;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseUp()
	{
		Fichiers.setDifficulte (niveau);
		Application.LoadLevel ("MenuAvecMinion");
	}
}
