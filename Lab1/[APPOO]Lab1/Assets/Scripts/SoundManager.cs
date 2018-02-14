using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour 
{
	public AudioSource efxSource,spcSource,Q;		
	public AudioSource musicSource;                 
	public static SoundManager instance = null;                  
	public float lowPitchRange = .92f;              
	public float highPitchRange = 1.07f;            

	void Awake () {
			instance = this;
	}

	//Used to play single sound clips.
	public void PlayQuietSfx(params AudioClip[] clips) {
		//Generate a random number between 0 and the length of our array of clips passed in.
		int randomIndex = Random.Range(0, clips.Length);
		//Set the clip to the clip at our randomly chosen index.
		Q.clip = clips[randomIndex];
		//Set the pitch of the audio source to the randomly chosen pitch.
		Q.pitch = Random.Range(lowPitchRange, highPitchRange);
		//Play the clip.
		Q.Play ();
	}

	//Used to play single sound clips.
	public void PlayOtherSfx(params AudioClip[] clips) {
		//Generate a random number between 0 and the length of our array of clips passed in.
		int randomIndex = Random.Range(0, clips.Length);
		//Set the clip to the clip at our randomly chosen index.
		spcSource.clip = clips[randomIndex];
		//Set the pitch of the audio source to the randomly chosen pitch.
		spcSource.pitch = Random.Range(lowPitchRange, highPitchRange);
		//Play the clip.
		spcSource.Play ();
	}

	public void PlayRandSfx(params AudioClip[] clips) {
		//Generate a random number between 0 and the length of the array of clips passed in.
		int randomIndex = Random.Range(0, clips.Length);
		//Set the clip to the clip at our randomly chosen index.
		efxSource.clip = clips[randomIndex];
		//Set the pitch of the audio source to the randomly chosen pitch.
		efxSource.pitch = Random.Range(lowPitchRange, highPitchRange);
		//Play the clip.
		efxSource.Play ();
	}
		
	public void PlaySong (params AudioClip[] clips){
		//Generate a random number between 0 and the length of our array of clips passed in.
		int randomIndex = Random.Range(0, clips.Length);
		//Set the clip to the clip at our randomly chosen index.
		musicSource.clip = clips[randomIndex];
		//Play the clip.
		musicSource.Play();
	}

	//overloading PlayOtherSfx for a specified audiosource and audioclip
	public void PlayOtherSfx(AudioSource a, AudioClip c)
	{
		a.clip = c;  // insert audioclip in audiosource
		a.Play();	 // play it
	}
}