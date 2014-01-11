#pragma strict

var couleurEntrer : Color = Color.green;
var couleurSortie : Color = Color.white;
var tailleEntrer : float = 45;
var tailleSortie : float = 45;
var son : AudioClip;

function OnMouseEnter() {
    guiText.material.color = couleurEntrer;
    guiText.fontSize = tailleEntrer;
    audio.PlayOneShot(son);
}

function OnMouseExit() {
    guiText.material.color = couleurSortie;
    guiText.fontSize = tailleSortie;
}

@script RequireComponent (AudioSource)