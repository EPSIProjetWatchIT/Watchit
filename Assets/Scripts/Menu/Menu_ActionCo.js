#pragma strict

var couleurEntrer : Color = Color.green;
var couleurSortie : Color = Color.white;
var tailleEntrer : float = 45;
var tailleSortie : float = 45;
var son : AudioClip;

function OnMouseEnter() {
    guiText.material.color = couleurEntrer;
    guiText.fontSize = tailleEntrer;
    
    audio.volume = 1;	
    audio.PlayOneShot(son);
}

function OnMouseExit() {
    guiText.material.color = couleurSortie;
    guiText.fontSize = tailleSortie;
    audio.Stop();
}

@script RequireComponent (AudioSource)