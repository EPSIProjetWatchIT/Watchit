using UnityEngine;
using System.Collections;

public class Perso : MonoBehaviour {

	private const int VIEMAX = 100;
	private GameObject target;
	public int niveau;
	public bool Dieu=false;
	
	public int Vie
	{
		get{ return _vie;}
		set{ _vie = value;}
	}
	private int _vie;

	public int Score
	{
		get{ return (int) _score * 10;}
	}
	private float _score;

	public void addScore(float variation)
	{
		_score += variation;
	}


	public void AltereVie(int variation)
	{
		Vie = Vie + variation >= VIEMAX ? VIEMAX : Vie + variation <= 0 ? 0 : Vie + variation;
	}


	// Use this for initialization
	void Start () {
		Vie = VIEMAX;
		}
	
	// Update is called once per frame
	void Update () {
		if (Vie == 0) 
		{
			if (!Dieu)
				Mort(Score);
		}
	
	}

	private void EnregistreScore(int score)
	{
		Fichiers.setScore (score, niveau);
	}

	private void Mort(int score)
	{
		EnregistreScore (score);
		string scenego = niveau == 1 ? "GameOver" : "GameOverChateau";
		Application.LoadLevel(scenego);
	}

	private void Gagne(int score)
	{
		EnregistreScore (score);
		Application.LoadLevel ("Victoire");
	}
}
