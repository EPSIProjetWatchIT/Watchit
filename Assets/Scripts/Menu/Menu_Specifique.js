#pragma strict

var levelSuivant : String = "Quitter";

function OnMouseUp() { 
     if (levelSuivant == "Quitter") {
         Application.Quit();
         } else {
         Application.LoadLevel(levelSuivant); 
         }
}