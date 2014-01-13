using UnityEngine;
using System.Collections;
using System.IO;

public class Fichiers : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
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

	public static void setTutoMode(int value=0)
	{
		StreamWriter file = new StreamWriter ("tutoMode.txt");
		file.WriteLine (value.ToString ());
		file.Close ();
	}

	public static int getTutoMode()
	{
		int value = 0;
		StreamReader file = new StreamReader ("tutoMode.txt");
		value = int.Parse(file.ReadLine());
		file.Close ();
		return value;
	}
}
