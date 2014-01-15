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
	bool isOnRecommencerGrotte = false;
	bool isOnQuitterGameOver = false;

	public AudioSource sonJouer;
	public AudioClip sonOption;
	public AudioClip sonQuitter;
	public AudioClip sonValiderOption;
	public AudioClip sonEasy;
	public AudioClip sonMedium;
	public AudioClip sonHard;
	public AudioClip sonRecommencerGrotte;
	public AudioClip sonQuitterGameOver;

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
			//audio.PlayOneShot(sonJouer,0.9f);
			sonJouer.Play();
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
		if (collision.gameObject.name == "Cube RecommencerGrotte") {
			isOnRecommencerGrotte = true;
			audio.PlayOneShot(sonRecommencerGrotte,0.9f);
		}
		if (collision.gameObject.name == "Cube QuitterGameOver") {
			isOnQuitterGameOver = true;
			audio.PlayOneShot(sonQuitterGameOver,0.9f);
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
								Fichiers.setDifficulte (1);
						}
						if (isOnMedium) {
								Fichiers.setDifficulte (2);
						}
						if (isOnHard) {
								Fichiers.setDifficulte (3);
						}
						if (isOnRecommencerGrotte) {
								Application.LoadLevel ("Scene_Grotte");
						}
						if (isOnQuitterGameOver) {
								Application.LoadLevel ("MenuAvecMinion"); 
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
		isOnRecommencerGrotte = false;
		isOnQuitterGameOver = false;
		//audio.Stop();
	}

}
