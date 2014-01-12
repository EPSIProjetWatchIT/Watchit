#pragma strict

var son : AudioClip;


function OnMouseUp() {
		 audio.volume = 0.5;	 
         audio.PlayOneShot(son);
}

function OnMouseExit() { 
         audio.Stop();
}

@script RequireComponent (AudioSource)