using UnityEngine;
using System.Collections;

public class StartParcour : MonoBehaviour {

	private const float SOL = -0.8f;
	private const float PLAFOND = 1f;
	private const float VOIEG = -0.6f;
	private const float VOIED = 0.6f;
	private const float VOIEM = 0f;
	private const float DEBUTTUNEL = -3.5f;
	private const float FINTUNEL = 2.5f;
	private const int PROBAINIT = 70;
	private const int PROBADEUXPARLIGNE = 30;
	private int nbTunelVide = 2;
	private float pas = 2f;
	private int obstacleParLigne = 1;

	private GameObject[] elements = new GameObject[5];
	private float[] voies = {VOIEG,VOIEM,VOIED};
	public GameObject parcour1;
	public GameObject parcour2;
	private int probabiliteObstacle;
	private GameObject elementCopie;
	private GameObject nouvelElement;

	// Use this for initialization
	void Start () {

		probabiliteObstacle = PROBAINIT;

		elements[0] = GameObject.Find("Bat");
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
				for( float zone = DEBUTTUNEL;zone<=FINTUNEL;zone+=pas)
				{
					if(Random.Range(1,100) <= probabiliteObstacle )
					{
						obstacleParLigne = Random.Range (1,100) <= PROBADEUXPARLIGNE ? 2 : 1;

						int voieChoisie = Random.Range(0,2); //Voie ou l'on pose l'obstacle si il n'y en a qu'un, voie libre si il y en a deux
						int voie1 = 0;
						int voie2 = 0;
						int elementDispo = 5; //Nombre d'element dans lesquels choisir l'obstacle.

						if (obstacleParLigne == 2)
						{
							voie1 = voieChoisie == 0 ? 1 : 0;
							voie2 = voieChoisie == 1 ? 2 : 1;
						}

						for (int obstacle = 1; obstacle <= obstacleParLigne;obstacle++)
						{
							int hasard = Random.Range (0,elementDispo - 1);
							elementCopie = elements[hasard];
							nouvelElement = Instantiate(elementCopie,Vector3.zero, Quaternion.Euler(0f,0f,0f)) as GameObject;
							nouvelElement.transform.parent = grotteEnCour.transform;
							if(obstacleParLigne == 2)
							{
								voieChoisie = obstacle == 1 ? voie1 : voie2;
							}

							switch(hasard)
							{
							case 0 : //Bat
								nouvelElement.transform.localPosition = new Vector3(-PLAFOND + 0.5f,zone,voies[voieChoisie]);
								nouvelElement.transform.localRotation = Quaternion.Euler(90f, -90f,0f);
								elementDispo--; //On supprime la ligne de pierres si on a deja un élément a placer
								break;
							case 1: //PierreSolitaire
								nouvelElement.transform.localPosition = new Vector3(-SOL,zone,voies[voieChoisie]);
								nouvelElement.transform.localRotation = Quaternion.Euler(0f, 0f,0f);
								elementDispo--; //On supprime la ligne de pierres si on a deja un élément a placer
								break;
							case 2: //Stalagmite
								nouvelElement.transform.localPosition = new Vector3(-SOL,zone,voies[voieChoisie]);
								nouvelElement.transform.localRotation = Quaternion.Euler(0f, -90f,0f);
								elementDispo--; //On supprime la ligne de pierres si on a deja un élément a placer
								break;
							case 3: //Stalagtite
								nouvelElement.transform.localPosition = new Vector3(-PLAFOND,zone,voies[voieChoisie]);
								nouvelElement.transform.localRotation = Quaternion.Euler(0f, 90f,0f);
								break;
							case 4 : //Ligne de pierre
								obstacle++; //On force le placement d'un seul element si on a deja placé une ligne de pierres qui prend tous les emplacement
								nouvelElement.transform.localRotation = Quaternion.Euler(0f, 0f,0f);
								nouvelElement.transform.localPosition = new Vector3(SOL,zone,VOIEM);
								break;
							default :
								break;
							}
						}


						//On réinitialise la probabilité d'avoir un obstacle
						probabiliteObstacle  = PROBAINIT;
					}
					else
					{
						probabiliteObstacle += 10;
					}
				}
			}
			else
			{
				nbTunelVide --;
			}
		}
		for (int i=0; i<=4; i++)
		{
			elements[i].SetActive(false);
		}


		parcour1.SetActive (true);
		parcour2.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
