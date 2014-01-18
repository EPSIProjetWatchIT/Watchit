using UnityEngine;
using System.Collections;

public class SautillementChateau: MonoBehaviour {
	
	private float HAUTEURMIN = 0f;
	private float HAUTEURMAX = 0.005f;
	private float HAUTEUR;
	private float VITESSE = 0.25f;
	//private float VITESSE = 0.012f;//Valeur si on utilise pas le deltaTime
	private bool down =false;
	private bool up = true;
	public AudioSource footstep;
	
	
	
	private GameObject brasGauche;
	private float VitesseBras = 500f;
	private bool BGForward = true;
	private float LimiteMax = 50f;
	private float LimiteMin = -30f;
	
	
	// Use this for initialization
	void Start () {
		HAUTEUR = HAUTEURMIN;
		brasGauche = GameObject.Find ("GaucheEpaule");
		
	}
	
	// Update is called once per frame
	void Update () {
		//SAUTILLEMENT
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
		
		//BRAS
		if ((brasGauche.transform.localRotation.x >= LimiteMax && BGForward) || (brasGauche.transform.localRotation.x <= LimiteMin && !BGForward)) 
		{
			VitesseBras = -VitesseBras;
			BGForward = !BGForward;
		}
		brasGauche.transform.Rotate (Vector3.up * VitesseBras * Time.deltaTime);
		
		
	}
	
	/*public void BrasDroit(float degres)
	{

		brasDroit.transform.Rotate (0f, 0f, -brasDroit.transform.rotation.z);
		brasDroit.transform.Rotate (0f, 0f, degres);
	}
	
	public void BrasGauche(float degres)
	{
		GameObject brasGauche = GameObject.Find ("GaucheEpaule");
		brasGauche.transform.Rotate (0f, 0f, -brasGauche.transform.rotation.z);
		brasGauche.transform.Rotate (0f, 0f, degres);
	}
*/
	
}
