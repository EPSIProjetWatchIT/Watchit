using UnityEngine;
using System.Collections;

public class CollisionGameOver : MonoBehaviour {

	private float delais = 3f;
	private float selectionDepuis = 0f;
	private bool selection = false;
	private string scene;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (selection) 
		{
			selectionDepuis += Time.deltaTime;
			if(selectionDepuis >= delais)
				Application.LoadLevel(scene);
		}
		else 
		{
			selectionDepuis = 0f;
		}

	}

	void OnTriggerEnter(Collider other)
	{
		selection = true;
		if (other.gameObject.tag == "Grotte") 
		{
			scene = "Scene_grotte";
		}
		else 
		{
			scene = "MenuAvecMinion";
		}
	}

	void OnTriggerExit(Collider other)
	{
			selection = false;
	}
}
