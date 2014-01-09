#pragma strict

function Start () {

}

function Update () {

}

var son : AudioClip;
var levelSuivant : String = "Quitter";

function OnMouseUp() { 
     audio.PlayOneShot(son);
     if (levelSuivant == "Quitter")
         Application.Quit();
     else
         Application.LoadLevel(levelSuivant);
}

@script RequireComponent (AudioSource)