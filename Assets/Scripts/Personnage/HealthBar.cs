using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {

	
	private int maxHealth = 100;
	public int curHealth = 100;
	public int adj;
	private float healthBarlenght;
	private Perso personnage;
	
	void Start(){
		healthBarlenght = Screen.width / 2;
	    personnage = GameObject.Find("Personnage").GetComponent("Perso") as Perso;
			
	}

	void Update(){
		AdjustcurHealth (0) ;
	}

	void OnGUI () {
		GUI.Box(new Rect(10, 10, healthBarlenght, 20), curHealth + "/" + maxHealth);
	}
		
	public void AdjustcurHealth(int adj) {
		curHealth += adj;
		
		if(curHealth < 0)
			curHealth = 0;
		
		if(curHealth > maxHealth)
			curHealth = maxHealth;
		
		if(maxHealth < 1)
			maxHealth = 1;
		
		healthBarlenght = (Screen.width / 2) * (curHealth / (float)maxHealth);
	}
}
