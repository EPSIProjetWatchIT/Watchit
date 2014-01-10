using UnityEngine;
using System.Collections;

public class Sautillement : MonoBehaviour {

	private const float HAUTEURMAX = 0.002f;
	//private const float VITESSESAUTILLEMENT = 0.004f;
	private const float VITESSESAUTILLEMENT = 3f;
	private Vector3 Saut =new Vector3 (0f, 1f, 0f);


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		//Sautillement
		if((transform.localPosition.y > HAUTEURMAX) || (transform.localPosition.y < 0 ))
			Saut = Saut * -1f;

		transform.Translate(Saut * VITESSESAUTILLEMENT * Time.deltaTime);
	}
}
