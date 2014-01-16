using UnityEngine;
using System.Collections;
using System.IO;

public class Fichiers : MonoBehaviour {

	public static int[] SCORES = {0,0,0,0,0};


	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
	}

	public static void getScore()
	{
		int i = 0;
		string sc = "";
		StreamReader file = new StreamReader ("score.txt");
		while ((sc = file.ReadLine()) != null)
		{
			SCORES[i] = int.Parse(sc);
			i++;
		}
		file.Close ();
	}

	public static void setScore(int score)
	{
		StreamWriter file = new StreamWriter ("score.txt");

		for (int i =4; i>=0; i--) {
			SCORES[i] =  i== 0 ? score : SCORES[i-1];
				}

		foreach (int i in SCORES)
		{
			file.WriteLine(i.ToString());
		}
		file.Close ();
	}

	 public static int getDifficulte()
	{
		int value = 0;
		StreamReader file = new StreamReader ("difficulte.txt");
		value = int.Parse(file.ReadLine());
		file.Close ();
		return value;
	}

	public static void setDifficulte(int value=0)
	{
		StreamWriter file = new StreamWriter ("difficulte.txt");
		file.WriteLine (value.ToString ());
		file.Close ();
	}

	public static void setTutoMode(bool value=false)
	{
		int mode = value ? 1 : 0;
		StreamWriter file = new StreamWriter ("tutoMode.txt");
		file.WriteLine (mode.ToString ());
		file.Close ();
	}

	public static bool getTutoMode()
	{
		bool value = false;
		StreamReader file = new StreamReader ("tutoMode.txt");
		value = (int.Parse (file.ReadLine ())) == 1 ? true : false;
		file.Close ();
		return value;
	}
}
