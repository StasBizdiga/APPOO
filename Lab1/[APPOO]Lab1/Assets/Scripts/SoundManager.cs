using UnityEngine;
using System.Collections;


public class SoundManager : MonoBehaviour
{
	public AudioSource efxSource,spcSource,Q;		
	public AudioSource musicSource;                 
	public static SoundManager instance = null;            

	void Awake () {
			instance = this;
	}

	// utils
	public float RandomPitch(float a = .92f, float b = 1.07f){ return Random.Range(a, b); }

	AudioClip RandomPick(params AudioClip[] clips){	int randomIndex = Random.Range (0, clips.Length);
		return clips[randomIndex]; }

	void PlayAudio(AudioSource a, AudioClip clip, float pitch = 1f){
		a.clip = clip;
		a.pitch = pitch;
		a.Play ();
	}

	//Used to play single sound clips.
	public void PlayQuietSfx(params AudioClip[] clips) {
		PlayAudio (Q, RandomPick (clips), RandomPitch ());
	}

	public void PlaySfx(params AudioClip[] clips) {
		PlayAudio (spcSource, RandomPick (clips), RandomPitch ());
	}

	public void PlayRandSfx(params AudioClip[] clips) {
		PlayAudio (efxSource, RandomPick (clips), RandomPitch ());

	}
		
	public void PlaySong (params AudioClip[] clips){
		PlayAudio (musicSource,RandomPick (clips));

	}
}