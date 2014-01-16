#pragma strict

var son : AudioClip;


function OnMouseUp() {
		 audio.volume = 1;	 
         audio.PlayOneShot(son);
}

function OnMouseExit() { 
         audio.Stop();
}

@script RequireComponent (AudioSource)