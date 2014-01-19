#pragma strict
@script RequireComponent(AudioSource)
function Start() {
	var impact : AudioClip;
	audio.PlayOneShot(impact,1);
}