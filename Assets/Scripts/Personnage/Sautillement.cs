using UnityEngine;
using System.Collections;

public class Sautillement : MonoBehaviour {
	
	private float HAUTEURMIN = 0f;
	private float HAUTEURMAX = 0.005f;
	private float HAUTEUR;
	private float VITESSE = 0.25f;
	//private float VITESSE = 0.012f;//Valeur si on utilise pas le deltaTime
	private bool down =false;
	private bool up = true;


	// Use this for initialization
	void Start () {
		HAUTEUR = HAUTEURMIN;
	}
	
	// Update is called once per frame
	void Update () {
		//On est en dessous du sol ou au sol, on rebondit
		if ((HAUTEUR <= HAUTEURMIN && down) ||(HAUTEUR >= HAUTEURMAX && up))
		{
			if(HAUTEUR < HAUTEURMIN)
			{
				transform.localPosition = new Vector3(transform.localPosition.x, HAUTEURMIN, transform.localPosition.z);
			}

			if(HAUTEUR > HAUTEURMAX)
			{
				transform.localPosition = new Vector3(transform.localPosition.x, HAUTEURMAX, transform.localPosition.z);
			}
			VITESSE = -VITESSE;
			down = !down;
			up = !up;
		}


		transform.Translate (Vector3.up * VITESSE *Time.deltaTime);
		HAUTEUR = transform.localPosition.y;
	}
}
