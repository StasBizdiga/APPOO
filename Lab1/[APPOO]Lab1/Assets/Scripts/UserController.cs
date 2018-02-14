using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using PlayerObject;

public class UserController : MonoBehaviour {
	private float moveSpeed = 8f;
	Player1 player1;
	Player2 player2;

	void Start () {
		player1 = new Player1();
		player2 = new Player2();
		}

	void Update () {
		if (GameController.instance.getGameOn() && !GameController.instance.getGameOver()) {
			player1.allowMovement();
			player2.allowMovement();

			// Unpause (round) when w,s,up or down keys are pressed
			if (Time.timeScale == 0 && (Input.GetKey ("w") || Input.GetKey ("s") || Input.GetKey ("down") || Input.GetKey ("up"))) {
				GameController.instance.ResumeGame ();
			}
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
