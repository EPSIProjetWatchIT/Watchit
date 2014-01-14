using UnityEngine;
using System.Collections;

public class Perso : MonoBehaviour {
	
	private const int VIEMAX = 100;
	
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
			Mort(Score);
		}
	
	}

	private void Mort(int score)
	{
		Application.LoadLevel("GameOver");
		GameObject.Destroy (GameObject.Find ("KinectPrefab"));
	}
}
