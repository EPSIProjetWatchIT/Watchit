using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {

	
	private int maxHealth = 100;
	public int curHealth = 100;
	private float healthBarlenght;
	private Perso personnage;
	
	void Start(){
		healthBarlenght = Screen.width / 2;
	    personnage = GameObject.Find("Personnage").GetComponent("Perso") as Perso;
			
	}

	void Update(){
		curHealth = personnage.Vie;
		healthBarlenght = (Screen.width / 2) * (curHealth / (float)maxHealth);
	}

	void OnGUI () {
		GUI.Box(new Rect(10, 10, healthBarlenght, 20), curHealth + "/" + maxHealth);
	}
		
}
