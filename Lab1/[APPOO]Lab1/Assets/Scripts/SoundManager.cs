using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour 
{
	public AudioSource efxSource,spcSource,Q;		//Drag a reference to the audio source which will play the sound effects.
	public AudioSource musicSource;                 //Drag a reference to the audio source which will play the music.
	public static SoundManager instance = null;     //Allows other scripts to call functions from SoundManager.             
	public float lowPitchRange = .92f;              //The lowest a sound effect will be randomly pitched.
	public float highPitchRange = 1.07f;            //The highest a sound effect will be randomly pitched.


	void Awake ()
	{
		//Check if there is already an instance of SoundManager
		if (instance == null)
			//if not, set it to this.
			instance = this;
		//If instance already exists:
		else if (instance != this)
			//Destroy this, this enforces our singleton pattern so there can only be one instance of SoundManager.
			Destroy (gameObject);

		//Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
		//DontDestroyOnLoad (gameObject);
	}

	//Used to play single sound clips.
	public void PlayQuietSfx(params AudioClip[] clips)
	{
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
	public void PlayOtherSfx(params AudioClip[] clips)
	{
		//Generate a random number between 0 and the length of our array of clips passed in.
		int randomIndex = Random.Range(0, clips.Length);

		//Set the clip to the clip at our randomly chosen index.
		spcSource.clip = clips[randomIndex];

		//Set the pitch of the audio source to the randomly chosen pitch.
		spcSource.pitch = Random.Range(lowPitchRange, highPitchRange);


		//Play the clip.
		spcSource.Play ();
	}

	public void PlayRandSfx(params AudioClip[] clips)
	{
		//Generate a random number between 0 and the length of our array of clips passed in.
		int randomIndex = Random.Range(0, clips.Length);

		//Set the clip to the clip at our randomly chosen index.
		efxSource.clip = clips[randomIndex];

		//Set the pitch of the audio source to the randomly chosen pitch.
		efxSource.pitch = Random.Range(lowPitchRange, highPitchRange);


		//Play the clip.
		efxSource.Play ();
	}


	//RandomizeSfx chooses randomly between various audio clips and slightly changes their pitch.
	public void PlaySong (params AudioClip[] clips)
	{
		//Generate a random number between 0 and the length of our array of clips passed in.
		int randomIndex = Random.Range(0, clips.Length);

		//Set the clip to the clip at our randomly chosen index.
		musicSource.clip = clips[randomIndex];

		//Play the clip.
		musicSource.Play();
	}
}