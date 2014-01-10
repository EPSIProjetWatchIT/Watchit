#pragma strict

var couleurEntrer : Color = Color.green;
var couleurSortie : Color = Color.white;
var tailleEntrer : float = 45;
var tailleSortie : float = 45;

function OnMouseEnter() {
    guiText.material.color = couleurEntrer;
    guiText.fontSize = tailleEntrer;
}

function OnMouseExit() {
    guiText.material.color = couleurSortie;
    guiText.fontSize = tailleSortie;
}