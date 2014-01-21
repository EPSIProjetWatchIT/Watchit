using UnityEngine;
using System.Collections;

public class Niveau2FromMebu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.G))
			Application.LoadLevel ("Scene_Chateau_2");
	
	}
}
