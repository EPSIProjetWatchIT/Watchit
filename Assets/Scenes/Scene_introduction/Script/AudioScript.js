#pragma strict
@script RequireComponent(AudioSource)
function Start() {
	audio.Play();
	// Delay a clip by 1 sec (44100 samples)
	audio.Play(44100);
}