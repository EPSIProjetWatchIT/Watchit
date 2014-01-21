using UnityEngine;
using System.Collections;

public class StartParcourChateau : MonoBehaviour {

	private const int DUR = 2;
	private const int MOYEN = 1;
	private const int FACILE = 0;
	private const float SOL = 0.035f;
	private const float PLAFOND = 1f;
	private const float VOIEG = 0.8f;
	private const float VOIED = -0.8f;
	private const float VOIEM = 0f;
	private const float DEBUTTUNEL = -3.2f;
	private const float FINTUNEL = 3.2f;
	private const int PROBAINIT = 30;
	private const int PROBADEUXPARLIGNE = 0;
	private float pas = 1f;
	private int obstacleParLigne = 1;
	private System.Random aleatoire = new System.Random ();
	private GameObject[] elements = new GameObject[4];
	private float[] voies = {VOIEG,VOIEM,VOIED};
	public GameObject parcour1;
	public GameObject parcour2;
	private int probabiliteObstacle;
	private GameObject elementCopie;
	private GameObject nouvelElement;
	private GameObject[] GROTTES;
	private GameObject[] grottesParcours1;
	private GameObject[] grottesParcours2;
	private int compteurParcours1 = 0;
	private int compteurParcours2 = 0;
	private int tampon=0;
	private bool ParcoursComplets = false;
	GameObject[] morceau = new GameObject[4];
	int ajoute = 0;
	public bool avance = false;
	private int difficulte = 1;
		
		// Use this for initialization
	void Start () {
		difficulte = Fichiers.getDifficulte ();

		probabiliteObstacle = difficulte == FACILE ? PROBAINIT - 10 : difficulte == MOYEN ? PROBAINIT : PROBAINIT + 10;
		
		//Instanciation des variables avant desactivation, pour garder une trace.
		elements[0] = GameObject.Find("Vase");
		elements[1] = GameObject.Find("Armure");
		elements[2] = GameObject.Find("Commode");
		elements[3] = GameObject.Find("Coffre");
		
		//On desactive les obstacles de bases pour ne pas les avoir a l'écran
		for (int i=0; i<=3; i++)
		{
			elements[i].SetActive(false);
		}
		
		//On enregistre les parcours 
		parcour1 = GameObject.Find("Parcour1");
		parcour2 = GameObject.Find("Parcour2");
		

		
		//On recherches les grottes du jeu
		GROTTES = GameObject.FindGameObjectsWithTag ("tunel");
		grottesParcours1 = new GameObject[GROTTES.Length]; //On a un tableau pour le parcours 1 a générer en premier
		grottesParcours2 = new GameObject[GROTTES.Length];//Et un tableau pour le parcours 2, qui se génerera pendant le parcour 1
		
		//Si on est en mode tuto
		
		
		//On trie les grottes entre les deux parcour
		foreach (GameObject g in GROTTES) {
			if(g.transform.parent.gameObject.name == "Parcour1")
			{
				grottesParcours1[compteurParcours1] = g;
				compteurParcours1++;
			}
			else
			{
				grottesParcours2[compteurParcours2] = g;
				compteurParcours2++;
			}
		}
		//On génère uniquement les obstacles de la partie 1 avant le jeu
		genererObstacles (grottesParcours1, compteurParcours1);
		avance = true;
		//On désactive le parcours 2 pour ne pas avoir trop de calcul a faire.
		parcour1.SetActive (true);
		//parcour2.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
		//Ici on génère le parcours 2 pendant qu'on cours
		if (!ParcoursComplets && avance) 
		{
			ajoute = 0;
			for (int i = 0; i<=3; i++) 
			{
				if (tampon < compteurParcours2) {
					morceau[i] = grottesParcours2 [tampon];
					tampon++;
					ajoute++;
				}
				else
				{
					ParcoursComplets = true;
				}
			}
			genererObstacles (morceau, ajoute);
		}

		
	}
	
	
	
	
	
	
	
	
	void genererObstacles(GameObject[] GROTTES, int tailleGrotte)
	{
		GameObject grotteEnCour;
		for(int compteur = 0; compteur < tailleGrotte; compteur++  )
		{
			grotteEnCour = GROTTES[compteur];
			
			for( float zone = DEBUTTUNEL;zone<=FINTUNEL;zone+=pas)
			{
				//if(Random.Range(1,101) <= probabiliteObstacle )
				if(aleatoire.Next(0,100) <= probabiliteObstacle )
				{
					//obstacleParLigne = Random.Range (1,101) <= PROBADEUXPARLIGNE ? 2 : 1;
					obstacleParLigne = aleatoire.Next (0,100) <= PROBADEUXPARLIGNE ? 2 : 1;
					
					//int voieChoisie = Random.Range(0,3); //Voie ou l'on pose l'obstacle si il n'y en a qu'un, voie libre si il y en a deux
					int voieChoisie = aleatoire.Next(0,3); //Voie ou l'on pose l'obstacle si il n'y en a qu'un, voie libre si il y en a deux
					int voie1 = 0;
					int voie2 = 0;
					int elementDispo = 5; //Nombre d'element dans lesquels choisir l'obstacle +1
					
					if (obstacleParLigne == 2)
					{
						voie1 = voieChoisie == 0 ? 1 : 0;
						voie2 = voieChoisie == 1 ? 2 : 1;
					}
					
					for (int obstacle = 1; obstacle <= obstacleParLigne;obstacle++)
					{
						//int hasard = Random.Range (0,elementDispo - 1);
						int hasard = aleatoire.Next (0,elementDispo - 1);
						
						elementCopie = elements[hasard];
						nouvelElement = Instantiate(elementCopie,Vector3.zero, Quaternion.Euler(0f,0f,0f)) as GameObject;
						nouvelElement.transform.parent = grotteEnCour.transform;
						nouvelElement.SetActive(true);
						if(obstacleParLigne == 2)
						{
							voieChoisie = obstacle == 1 ? voie1 : voie2;
						}
						
						switch(hasard)
						{
						case 0 : //Vase
							nouvelElement.transform.localPosition = new Vector3(zone,0f,voies[voieChoisie]);
							nouvelElement.transform.localRotation = Quaternion.Euler(270f, 0f,0f);
							break;
						case 1: //Armure
							nouvelElement.transform.localPosition = new Vector3(zone,-0.93f,voies[voieChoisie]);
							float rotationArmure = 0f;

							if (voies[voieChoisie] == VOIEG)
								rotationArmure = -90f;

							if (voies[voieChoisie] == VOIED)
								rotationArmure = 90f;
								
							if (voies[voieChoisie] == VOIEM)
								rotationArmure = 0f;
								
							nouvelElement.transform.localRotation = Quaternion.Euler(0f, rotationArmure,0f);
							break;
						case 2: //Commonde
							nouvelElement.transform.localPosition = new Vector3(zone,-0.54f,voies[voieChoisie]);
							float rotationCommode = 0f;

							if (voies[voieChoisie] == VOIEG)
								rotationCommode = 1800f;
								
							if (voies[voieChoisie] == VOIED)
								rotationCommode = 0f;
								
							if (voies[voieChoisie] == VOIEM)
								rotationCommode = 90f;
								
							nouvelElement.transform.localRotation = Quaternion.Euler(270f, rotationCommode,0f);
							break;
						case 3: //Coffre
							nouvelElement.transform.localPosition = new Vector3(zone, -0.5f,voies[voieChoisie]);
							break;
						default :
							break;
						}
					}
					//On réinitialise la probabilité d'avoir un obstacle
					probabiliteObstacle = difficulte == FACILE ? PROBAINIT - 10 : difficulte == MOYEN ? PROBAINIT : PROBAINIT + 10;
				}
				else
				{
					probabiliteObstacle += 5;
				}
			}
		}
	}
}
