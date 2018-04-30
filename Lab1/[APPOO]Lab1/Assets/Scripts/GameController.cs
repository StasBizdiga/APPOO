using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerObject;

public class GameController : MonoBehaviour {
	public static GameController instance;
	
	public static bool isPlayer1AI,isPlayer2AI;
	private static bool isGameOn;
	private static bool isGameOver;

	public GameObject ball;
	public AudioClip song1,song2,song3,song4;
	public AudioClip win1,win2,win3;
	public AudioClip ballthrow,start;

	public string[] controlsP1,controlsP2,controlsP3; 
	public PaddlePlayer player1,player2;
	public Spectator spectator;



	void Start () {
		// play some music!
		SoundManager.instance.PlaySong (song1, song2, song3, song4);

		// init default controls
		setGameControls ();

		// init players
		setPlayers();

		// set the initial game state (not started, nor over)
		isGameOver = false;
		isGameOn = false;
	}

	void Awake(){ // making the script usable externally
		instance = this;
	}

	void Update () {
		if (isGameOn && !isGameOver) {
			// Check for any ball existence
			if (GameObject.FindWithTag ("Ball") == null) {
				ResetGame ();
			}
		}
	}

	public void ResetGame() {
		// destroy any balls if they exist
		while (GameObject.FindWithTag ("Ball") != null) {		
			Destroy (GameObject.FindWithTag ("Ball"));
		}
		Instantiate (ball); // create new ball

		// Letting AI take control by default
		isPlayer1AI = true;
		isPlayer2AI = true;

	}
	public void PauseGame()	{
		Time.timeScale = 0;
	} 

	public void ResumeGame() {
		SoundManager.instance.PlayQuietSfx (ballthrow);
		Time.timeScale = 1;
	}

	public void EndGame() {
		isGameOver = true;
		SoundManager.instance.PlaySong (win1,win2,win3);
		VfxController.instance.enableWinVFX (Score.instance.checkWinner());
	}

	// play gong sound once
	public void playGong() { SoundManager.instance.PlaySfx (start); } 

	void setGameControls(){
		controlsP1 = new string[]{ "w", "s", "a", "d" };
		controlsP2 = new string[]{ "up", "down", "right", "left" };
		controlsP3 = new string[]{ "i", "k", "l", "j" , "u" , "o" };
	}


	void setPlayers (){
		PaddleFactory PF = new PaddleFactory();
		SpectatorFactory SF = new SpectatorFactory ();
		player1 = PF.getInstance(1,controlsP1);
		player2 = PF.getInstance(2,controlsP2);
		spectator = SF.getInstance (controlsP3);
	}

	// game state getters and setters
	public bool getGameOn()			{ return isGameOn;	}
	public bool getGameOver()		{ return isGameOver;}
	public void setGameOn(bool b)	{ isGameOn = b; 	}
	public void setGameOver(bool b)	{ isGameOver = b;	}

}
