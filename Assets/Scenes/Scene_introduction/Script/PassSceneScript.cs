using UnityEngine;
using System.Collections;

public class PassSceneScript : MonoBehaviour {

	void Update()
	{
		if (Input.GetKey(KeyCode.Escape))
		{
			Application.LoadLevel("MenuAvecMinion");
		}
	}

	void OnMouseOver ()
	{
		Application.LoadLevel("MenuAvecMinion");
	}


}
