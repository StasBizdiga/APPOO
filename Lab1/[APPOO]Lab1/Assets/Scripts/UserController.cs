using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using PlayerObject;


public class UserController : MonoBehaviour {

	static GameController Game;
	void allowMovement(Movement mov, Rotation rot){ // listens to user input and performs the movement
		mov.move(); // Move controls 
		rot.turn(); // Rotation controls
	}

	void Update () {

		GameController Game = GameController.instance;		// synonime (for clearer code)

		if (Game.getGameOn () && !Game.getGameOver ()) {

			allowMovement (Game.player1, Game.player1);
			allowMovement (Game.player2, Game.player2);
			allowMovement (Game.spectator, Game.spectator);


			if (GameObject.FindWithTag ("Ball")) { // AI movement
				if (GameController.isPlayer1AI) {
					Game.player1.autoFollow (GameObject.FindWithTag ("Ball"));
				}
				if (GameController.isPlayer2AI) {
					Game.player2.autoFollow (GameObject.FindWithTag ("Ball"));
				}

			}

			// Unpause (round) when w,s,up or down keys are pressed
			if (Time.timeScale == 0 && (Input.GetKey ("space") || Input.GetKey ("w") || Input.GetKey ("s") || Input.GetKey ("down") || Input.GetKey ("up"))) {
				Game.ResumeGame ();
			}
			// setting players turn off AI upon taking key control
			if (Input.GetKey ("w") || Input.GetKey ("s")) {
				GameController.isPlayer1AI = false;
			}
			if (Input.GetKey ("down") || Input.GetKey ("up")) {
				GameController.isPlayer2AI = false;
			}
		}


		// Reset button
		if (Input.GetKey ("r")) {
			Application.LoadLevel (0);
			Game.setGameOn(true); // solves the bug of freezing title animation when spamming the R button
		}
		// Quit button
		if (Input.GetKey (KeyCode.Escape)) {
			Application.Quit();
		}

		// Any button : Turn off title screen
		if (Input.anyKey && !Game.getGameOn() && !Game.getGameOver()) {
			VfxController.instance.setStartScreen (false);

			// start the game
			Game.ResetGame ();
			Game.setGameOn(true);
			Game.playGong();
			}
	}
}

