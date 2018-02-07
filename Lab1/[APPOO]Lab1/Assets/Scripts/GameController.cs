using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	public static GameController Instance;
	public GameObject player1,player2,scrn_start,scrn_end,ball;
	public AudioClip ballthrow,start,song1,song2,song3,song4;
	private Vector3 p1_pos, p2_pos;
	private float moveSpeed = 8f;
	static bool isGameOn;
	static bool isGameOver;


	void Start () {
		// bring some music!
		SoundManager.instance.PlaySong(song1,song2,song3,song4);

		// show the title screen
		scrn_start.SetActive (true);

		// set the initial position of the paddles
		p1_pos = new Vector3(-10f, 0f, 0f);
		p2_pos = new Vector3(10f, 0f, 0f);
		isGameOver = false;
		isGameOn = false;
	}

	void Awake(){
		// making the script usable externally
		Instance = this;
	}

	void Update () {
		if (isGameOn && !isGameOver) {
			// P2 Move controls (->)
			if (Input.GetKey ("up") && player2.transform.position.y < 3.5f) {
				player2.transform.Translate (Vector3.up * Time.deltaTime * moveSpeed, Space.World);
			} else if (Input.GetKey ("down") && player2.transform.position.y > -3.5f) {
				player2.transform.Translate (Vector3.down * Time.deltaTime * moveSpeed, Space.World);
			}
			// P2 Rotation controls
			if (Input.GetKey ("right")) {
				player2.transform.rotation =  Quaternion.Euler(0f,0f,-15f);
			} else if (Input.GetKey ("left")) {
				player2.transform.rotation = Quaternion.Euler(0f,0f,15f);
			} else { // normalize
				player2.transform.rotation = Quaternion.Euler (0f, 0f, 0f);
			}

			// P1 Move controls (<-)
			if (Input.GetKey ("w") && player1.transform.position.y < 3.5f) {
				player1.transform.Translate (Vector3.up * Time.deltaTime * moveSpeed, Space.World);
			} else if (Input.GetKey ("s") && player1.transform.position.y > -3.5f) {
				player1.transform.Translate (Vector3.down * Time.deltaTime * moveSpeed, Space.World);
			}
			// P1 Rotation controls
			if (Input.GetKey ("d")) {
				player1.transform.rotation = Quaternion.Euler (0f, 0f, -15f);
			} else if (Input.GetKey ("a")) {
				player1.transform.rotation = Quaternion.Euler (0f, 0f, 15f);
			} else { // normalize
				player1.transform.rotation = Quaternion.Euler (0f, 0f, 0f);
			}


			// Unpause (round) when w,s,up or down keys are pressed
			if (Time.timeScale == 0 && (Input.GetKey ("w") || Input.GetKey ("s") || Input.GetKey ("down") || Input.GetKey ("up"))) {
				ResumeGame ();
			}

			// Check for the ball existence
			if (GameObject.FindWithTag ("Ball") == null) {
				ResetGame ();
			}
		}

		// Reset button
		if (Input.GetKey ("r")) {
			Application.LoadLevel (0);
			isGameOn = true; // solves the bug of freezing title animation when spamming the R button
		}
		// Quit button
		if (Input.GetKey (KeyCode.Escape)) {
			Application.Quit();
		}

		// Any button : Turn off title screen
		if (Input.anyKey && !isGameOn && !isGameOver) {
			scrn_start.SetActive (false);

			// start the game
			ResetGame ();
			isGameOn = true;

			SoundManager.instance.PlayOtherSfx (start); // gong sound
		}
	}

	protected void ResetGame()
	{
		// destroy any balls if they exist
		while (GameObject.FindWithTag ("Ball") != null) 
		{		
			Destroy (GameObject.FindWithTag ("Ball"));
		}

		// reset paddles
		//player1.transform.position = p1_pos;
		//player2.transform.position = p2_pos;

		// create new ball
		Instantiate (ball);
	}
	public void PauseGame()
	{
		Time.timeScale = 0;
	} 

	public void ResumeGame()
	{
		SoundManager.instance.PlayQuietSfx (ballthrow);
		Time.timeScale = 1;
	}

	public void EndGame()
	{
		isGameOver = true;
		scrn_end.SetActive (true);
	}


}
