using UnityEngine;
using System.Collections;

public class KinectMouv : MonoBehaviour {
	private Mouvement mouv;
	private GestureMouv GKinectMouv;
	private bool droite = false;
	private bool gauche = false;
	
	// Use this for initialization
	void Start () {
		mouv = gameObject.GetComponent ("Mouvement") as Mouvement;
		GKinectMouv = new GestureMouv ();
	}
	
	// Update is called once per frame
	void Update () {
		if (GKinectMouv.GoRightMouve && !droite)
		{
			mouv.Droite ();
			droite = true;
		}
		if ((GKinectMouv.GoLeftMouve) && !gauche)
		{
			mouv.Gauche ();
			gauche = true;
		}
		GKinectMouv.GoLeftMouve = false;
		GKinectMouv.GoRightMouve = false;
		
		gauche = GKinectMouv.GoLeftMouve;
		droite = GKinectMouv.GoRightMouve;
		
		
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
