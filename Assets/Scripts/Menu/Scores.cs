using UnityEngine;
using System.Collections;

public class Scores : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Fichiers.getScore ();
		for (int i=0; i<=4; i++) {
			int j = (i+1);
			GameObject scoresLabel = GameObject.Find("GUI Text S"+j.ToString());
			scoresLabel.guiText.text = Fichiers.SCORES[i].ToString();
				}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
