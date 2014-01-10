using UnityEngine;
using System.Collections;

public class Clavier : MonoBehaviour {


	private Mouvement mouv;

	private bool droite = false;
	private bool gauche = false;

	// Use this for initialization
	void Start () {
		mouv = gameObject.GetComponent ("Mouvement") as Mouvement;

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.RightArrow) && !droite)
		{
			mouv.Droite ();
			droite = true;
		}
		if (Input.GetKey (KeyCode.LeftArrow) && !gauche)
		{
			mouv.Gauche ();
			gauche = true;
		}


		gauche = Input.GetKey (KeyCode.LeftArrow);
		droite = Input.GetKey (KeyCode.RightArrow);


		if (Input.GetKey (KeyCode.UpArrow))
		{
			mouv.BrasDroit (2f);
		}
		if (Input.GetKey (KeyCode.DownArrow))
		{
			mouv.BrasGauche (4f);
		}
	}
}
