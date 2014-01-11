using UnityEngine;
using System.Collections;

public class StartParcour : MonoBehaviour {

	private const float VOIEG = -0.6f;
	private const float VOIED = 0.6f;
	private const float VOIEM = 0f;
	private const float DEBUTTUNEL = -3.5f;
	private const float FINTUNEL = 2.5f;
	private int probaElement = 20;
	private int nbTunelVide = 2;
	private float pas = 0.14f;

	private GameObject[] elements = new GameObject[5];



	public GameObject parcour1;
	public GameObject parcour2;

	// Use this for initialization
	void Start () {

		//elements = GameObject.FindGameObjectsWithTag ("lifeChanger");

		elements[0] = GameObject.Find("bat");
		elements[1] = GameObject.Find("PierreSolitaire");
		elements[2] = GameObject.Find("Stalagmite");
		elements[3] = GameObject.Find("Stalagtite");
		elements[4] = GameObject.Find("LigneDePierre");



		parcour1 = GameObject.Find("Parcour1");
		parcour2 = GameObject.Find("Parcour2");
		foreach(GameObject grotteEnCour in  GameObject.FindGameObjectsWithTag ("tunel"))
		{
			if(nbTunelVide == 0)
			{

			}
			else
			{
				nbTunelVide --;
			}
		}


		parcour1.SetActive (true);
		parcour2.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
