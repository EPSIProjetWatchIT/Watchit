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
