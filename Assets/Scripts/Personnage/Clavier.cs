using UnityEngine;
using System.Collections;

public class Clavier : MonoBehaviour {


	private Mouvement mouv;
	private bool droite = false;
	private bool gauche = false;
	private bool saut = false;
	private bool appuieP = false;



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
		if (Input.GetKey (KeyCode.Space) && !saut) 
		{
			mouv.saut();
			saut = true;
		}
		if(Input.GetKey(KeyCode.Escape))
		{
			Application.Quit();
		}
		if(Input.GetKey(KeyCode.P) && !appuieP)
		{
			mouv.pause();
			appuieP = true;
		}


		gauche = Input.GetKey (KeyCode.LeftArrow);
		droite = Input.GetKey (KeyCode.RightArrow);
		saut = Input.GetKey (KeyCode.Space);
		appuieP = Input.GetKey (KeyCode.P);


		if (Input.GetKey (KeyCode.UpArrow))
		{
			mouv.BrasDroit (4f);
		}
		if (Input.GetKey (KeyCode.DownArrow))
		{
			mouv.BrasGauche (4f);
		}
	}
}
