#pragma strict

var levelSuivant : String = "Quitter";

function OnMouseUp() { 
     if (levelSuivant == "Quitter") {
         Application.Quit();
         } else {
         Application.LoadLevel(levelSuivant); 
         }
}

function OnCollisionEnter(col : Collision){
	//if(col.collider.name == "Sphere"){
	//	print("collision");
	//}
	   if (levelSuivant == "Quitter") {
         Application.Quit();
         } else {
         Application.LoadLevel(levelSuivant); 
         }
	}
function OnTriggerEnter(collision : Collider) {
  if (levelSuivant == "Quitter") {
         Application.Quit();
         } else {
         Application.LoadLevel(levelSuivant); 
         }
} 
	
	