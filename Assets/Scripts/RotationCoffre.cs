using UnityEngine;
using System.Collections;

public class RotationCoffre : MonoBehaviour {

	public float angle = 1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.up * angle);
	
	}
}
