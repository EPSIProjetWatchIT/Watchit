using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {

	
	private int maxHealth = 100;
	private int tailleScore = 150;
	private int curHealth;
	private float healthBarlenght;
	private float scoreBarlenght;
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

		GUIStyle currentStyle = new GUIStyle( GUI.skin.box );

		if (curHealth > 60f) {
						currentStyle.normal.background = MakeTex (2, 2, new Color (0, 100, 0, 255f));
				}
		if (curHealth <= 60f) {
						currentStyle.normal.background = MakeTex (2, 2, new Color (255, 69, 0, 255f));
				}
		if (curHealth <= 30f) {
						currentStyle.normal.background = MakeTex (2, 2, new Color (255,0,0, 255f));
				}

		GUI.contentColor = Color.black;
		GUI.Box(new Rect(10, 10, healthBarlenght, 20), curHealth + "/" + maxHealth, currentStyle);
		GUI.Label (new Rect (Screen.width - tailleScore, 10, tailleScore, 30), "Score : " + personnage.Score.ToString());
	}
	
private Texture2D MakeTex( int width, int height, Color col )
	
{
	Color[] pix = new Color[width * height];	
	for( int i = 0; i < pix.Length; ++i )
	{
		pix[ i ] = col;	
	}
	
	Texture2D result = new Texture2D( width, height );
	result.SetPixels( pix );
	result.Apply();
	return result;
}

		
}
