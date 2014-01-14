using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]

public class Menu_ChangeSceneCollision : MonoBehaviour {
	
	float time = 0f;

	bool isOn = false;
	bool isOnJouer = false;
	bool isOnOption = false;
	bool isOnQuitter = false;
	bool isOnValiderOption = false;
	bool isOnEasy = false;
	bool isOnMedium = false;
	bool isOnHard = false;

	public AudioClip sonJouer;
	public AudioClip sonOption;
	public AudioClip sonQuitter;
	public AudioClip sonValiderOption;
	public AudioClip sonEasy;
	public AudioClip sonMedium;
	public AudioClip sonHard;

	void Update(){
		if (isOn){
			time += Time.deltaTime;
		}
	}

	void OnCollisionEnter(Collision collision) {
		isOn = true; 
		Debug.Log("OnCollisionEnter");

		if (collision.gameObject.name == "Cube Jouer") {
			isOnJouer = true;
			audio.PlayOneShot(sonJouer,0.9f);
				}
		if (collision.gameObject.name == "Cube Option") {
			isOnOption = true;
			audio.PlayOneShot(sonOption,0.9f);
		}
		if (collision.gameObject.name == "Cube Quitter") {
			isOnQuitter = true;
			audio.PlayOneShot(sonQuitter,0.9f);
		}
		if (collision.gameObject.name == "Cube ValiderOption") {
			isOnValiderOption = true;
			audio.PlayOneShot(sonValiderOption,0.9f);
		}
		if (collision.gameObject.name == "Cube Easy") {
			isOnEasy = true;
			audio.PlayOneShot(sonEasy,0.9f);
		}
		if (collision.gameObject.name == "Cube Medium") {
			isOnMedium = true;
			audio.PlayOneShot(sonMedium,0.9f);
		}
		if (collision.gameObject.name == "Cube Hard") {
			isOnHard = true;
			audio.PlayOneShot(sonHard,0.9f);
		}
	}

	void OnCollisionStay(Collision collision) {
		Debug.Log ("OnCollisionStay");

		if (time > 3f) {
			if (isOnJouer) {
				Application.LoadLevel ("Scene_Grotte"); 
			}
			if (isOnOption) {
				Application.LoadLevel ("MenuOption");
			}
			if (isOnQuitter) {
				Application.Quit ();
				
			}
			if (isOnValiderOption) {
				Application.LoadLevel ("MenuAvecMinion"); 
			}
			if (isOnEasy) {
				//TODO
 			}
			if (isOnMedium) {
				//TODO
			}
			if(isOnHard){
				//TODO
			}
		}
	}

	void OnCollisionExit(Collision collision) {
		Debug.Log ("OnCollisionExit");
		time = 0f;
		isOn = false;
		isOnJouer = false;
		isOnOption = false;
		isOnQuitter = false;
		isOnValiderOption = false;
		isOnEasy = false;
		isOnMedium = false;
		isOnHard = false;
		//audio.Stop();
	}

}
