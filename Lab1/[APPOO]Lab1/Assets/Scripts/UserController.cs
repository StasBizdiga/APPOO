using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using PlayerObject;

public class UserController : MonoBehaviour {
	public PaddlePlayer player1,player2;

	void Start () {
		player1 = new PaddlePlayer(1);
		player2 = new PaddlePlayer(2);
		}

	void allowMovement(Movement mov, Rotation rot){ // listens to user input and performs the movement
		mov.moveY(); // Move controls 
		rot.turnZ(); // Rotation controls
	}

	void Update () {
		if (GameController.instance.getGameOn() && !GameController.instance.getGameOver()) {

			allowMovement(player1,player1);
			allowMovement(player2,player2);

			if (GameObject.FindWithTag ("Ball")) { // AI movement
				if (GameController.isPlayer1AI) {
					player1.autoFollow (GameObject.FindWithTag ("Ball"));
				}
				if (GameController.isPlayer2AI) {
					player2.autoFollow (GameObject.FindWithTag ("Ball"));
				}
			}

			// Unpause (round) when w,s,up or down keys are pressed
			if (Time.timeScale == 0 && (Input.GetKey ("w") || Input.GetKey ("s") || Input.GetKey ("down") || Input.GetKey ("up"))) {
				GameController.instance.ResumeGame ();
			}
			// setting players turn off AI upon taking key control
			if (Input.GetKey ("w") || Input.GetKey ("s")) 
			{GameController.isPlayer1AI = false;}
			if ( Input.GetKey ("down") || Input.GetKey ("up")) 
			{GameController.isPlayer2AI = false;}
		}

		// Reset button
		if (Input.GetKey ("r")) {
			Application.LoadLevel (0);
			GameController.instance.setGameOn(true); // solves the bug of freezing title animation when spamming the R button
		}
		// Quit button
		if (Input.GetKey (KeyCode.Escape)) {
			Application.Quit();
		}

		// Any button : Turn off title screen
		if (Input.anyKey && !GameController.instance.getGameOn() && !GameController.instance.getGameOver()) {
			VfxController.instance.setStartScreen (false);

			// start the game
			GameController.instance.ResetGame ();
			GameController.instance.setGameOn(true);
			GameController.instance.playGong();
			}
	}
}

