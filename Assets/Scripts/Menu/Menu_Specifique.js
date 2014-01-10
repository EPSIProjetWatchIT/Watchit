#pragma strict

var son : AudioClip;
var levelSuivant : String = "Quitter";

function OnMouseUp() { 
     if (levelSuivant == "Quitter") {
         Application.Quit();
         audio.PlayOneShot(son);
         } else {
         Application.LoadLevel(levelSuivant); 
         }
}

@script RequireComponent (AudioSource)