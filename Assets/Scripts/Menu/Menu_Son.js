#pragma strict

var son : AudioClip;


function OnMouseUp() { 
         audio.PlayOneShot(son);
}

@script RequireComponent (AudioSource)