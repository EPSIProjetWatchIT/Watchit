using UnityEngine;
using System.Collections;


public class Mouvement : MonoBehaviour {
	
	private const float VITESSE = 5f;
	private float HAUTEURINIT;
	private const float VITESSEROTATION = 50f;
	private const float VITESSECHANGEMENTVOIE = 2f;
	private const float GRAVITE = 0.5f;
	private const float VOIEG = -0.08f;
	private const float VOIED = 0.08f;
	private const float VOIEM = 0f;
	private const float ANGLEMAXSUP = -80f;
	private const float ANGLEMAXINF = 65f;
	private bool sautEnCour = false;
	private float _positionCible = VOIEM;
	private float _positionActuelle = VOIEM;
	private float VITESSESAUT = 0f;
	private Perso personnage;
	private GameObject minion;
	public AudioSource sonSaut;
	private bool Estpause = false;
	private GameObject pauseText;
	private GameObject PauseContinuerText;
	private GameObject PauseQuitterText;
	private float timeScaleDeBase;
	//NBR, Ajout MinionPause et MinionQuitter
	private GameObject minionPause;
	private GameObject minionQuitter;
	
    // Use this for initialization
    void Start()
    {
		personnage = gameObject.GetComponent ("Perso") as Perso;
		HAUTEURINIT = transform.position.y;
		minion = transform.FindChild ("Minion").gameObject;
		pauseText = GameObject.Find ("GuiPause");
		PauseQuitterText = GameObject.Find ("GuiQuitter");
		PauseContinuerText = GameObject.Find ("GuiContinuer");
		timeScaleDeBase = Time.timeScale;
		//NBR, ajout gameObject MinionPause
		minionPause = transform.FindChild ("Minion_Indy_Menu_pause").gameObject;
		minionQuitter = transform.FindChild ("MinionQuitter").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
		//Déplacement vers l'avant
		transform.Translate(Vector3.forward * VITESSE * Time.deltaTime);
		//Déplacement vertical (sauts)
		if (sautEnCour) 
		{
			transform.Translate (Vector3.up * VITESSESAUT * Time.deltaTime);
			VITESSESAUT = VITESSESAUT - GRAVITE;
			if (transform.position.y <= HAUTEURINIT) 
			{
				VITESSESAUT = 0f;
				transform.position = new Vector3 (transform.position.x, HAUTEURINIT, transform.position.z);
				sautEnCour = false;
			}
		}
		 

		//Calcul du score
		personnage.addScore (Time.deltaTime * VITESSE);

		//Changements de voies
		if ((_positionCible == VOIED && _positionActuelle == VOIEM) || (_positionCible == VOIEM && _positionActuelle == VOIEG)) 
		{
			minion.transform.Translate (Vector3.right * VITESSECHANGEMENTVOIE * Time.deltaTime);
			if(_positionCible <= minion.transform.localPosition.x)
			{
				_positionActuelle = _positionCible;
				minion.transform.localPosition = new Vector3(_positionActuelle,minion.transform.localPosition.y, minion.transform.localPosition.z);
			}

			//_positionActuelle = _positionActuelle==VOIEG?VOIEM:VOIED;
		}
		else if ((_positionCible == VOIEG && _positionActuelle == VOIEM) || (_positionCible == VOIEM && _positionActuelle == VOIED)) 
		{
			minion.transform.Translate (Vector3.left * VITESSECHANGEMENTVOIE * Time.deltaTime);
			if(_positionCible >= minion.transform.localPosition.x)
			{
				_positionActuelle = _positionCible;
				minion.transform.localPosition = new Vector3( _positionActuelle,minion.transform.localPosition.y, minion.transform.localPosition.z);
			}
			//_positionActuelle = _positionActuelle == VOIED?VOIEM:VOIEG; 
		}
    }

	public void Droite()
	{
		if(_positionCible == VOIEM)
			_positionCible = VOIED;
		if(_positionCible == VOIEG)
			_positionCible = VOIEM;
	}

	public void Gauche()
	{
		if(_positionCible == VOIEM)
			_positionCible = VOIEG;
		if(_positionCible == VOIED)
			_positionCible = VOIEM;
	}

	public void BrasDroit(float degres)
	{
		GameObject brasDroit = GameObject.Find ("DroitEpaule");
		brasDroit.transform.Rotate (0f, 0f, -brasDroit.transform.rotation.z);
		brasDroit.transform.Rotate (0f, 0f, degres);
	}

	public void BrasGauche(float degres)
	{
		GameObject brasGauche = GameObject.Find ("GaucheEpaule");
		brasGauche.transform.Rotate (0f, 0f, -brasGauche.transform.rotation.z);
		brasGauche.transform.Rotate (0f, 0f, degres);
	}

	public void saut(bool son = true)
	{
		if (!sautEnCour)
		{
			VITESSESAUT = VITESSE;
			sautEnCour = true;
			if (son)
				sonSaut.Play();
		}
	}

	public void pause()
	{
		Estpause= !Estpause;
		Time.timeScale = Estpause ? 0 : timeScaleDeBase;
		pauseText.guiText.text = Estpause ? "Pause" : "";
		PauseContinuerText.guiText.text = Estpause ? "Continuer" : ""; 
		PauseQuitterText.guiText.text = Estpause ? "Quitter" : "";
		Camera.main.farClipPlane = Estpause ? 0.2f : 20f;
		//NBR, Affichage mvt
		if (Estpause) {
			minionPause.SetActive (true);
			minionQuitter.SetActive(true);
		} 
		else {
			minionPause.SetActive (false);
			minionQuitter.SetActive(false);
		}
	}
	
}
