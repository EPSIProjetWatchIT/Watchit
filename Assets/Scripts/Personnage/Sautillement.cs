using UnityEngine;
using System.Collections;

public class Sautillement : MonoBehaviour {
	
	private const float HAUTEURINIT = 0;
	private const float GRAVITE = 3f;
	private float VITESSESAUT = 5f;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.up * VITESSESAUT * Time.deltaTime);
		VITESSESAUT = VITESSESAUT - GRAVITE;
		if (transform.localPosition.y < HAUTEURINIT)
		{
			transform.localPosition = new Vector3 (transform.localPosition.x, HAUTEURINIT, transform.localPosition.z);
		}
	}
}
