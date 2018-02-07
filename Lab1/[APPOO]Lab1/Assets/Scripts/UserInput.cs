using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour {
	public static UserInput Instance;
	public GameObject player1,player2,scrn_start,scrn_end,ball;
	public AudioClip ballthrow,start,song1,song2,song3,song4;
	private Vector3 p1_pos, p2_pos;
	private float moveSpeed = 4f;
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
			// Right player controls
			if (Input.GetKey ("up") && player2.transform.position.y < 3.5f) {
				player2.transform.Translate (Vector3.up * Time.deltaTime * moveSpeed, Space.World);
			} else if (Input.GetKey ("down") && player2.transform.position.y > -3.5f) {
				player2.transform.Translate (Vector3.down * Time.deltaTime * moveSpeed, Space.World);
			}

			// Left player controls
			if (Input.GetKey ("w") && player1.transform.position.y < 3.5f) {
				player1.transform.Translate (Vector3.up * Time.deltaTime * moveSpeed, Space.World);
			} else if (Input.GetKey ("s") && player1.transform.position.y > -3.5f) {
				player1.transform.Translate (Vector3.down * Time.deltaTime * moveSpeed, Space.World);
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
		// Press any key... to turn off the title screen
		if (Input.anyKey && !isGameOn && !isGameOver) {
			scrn_start.SetActive (false);

			// start the game
			ResetGame ();
			isGameOn = true;

			SoundManager.instance.PlayQuietSfx (start); // gong sound
		}

		// Reset button
		if (Input.GetKey ("r")) {
			Application.LoadLevel (0);
		}
		// Quit button
		if (Input.GetKey (KeyCode.Escape)) {
			Application.Quit();
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
		player1.transform.position = p1_pos;
		player2.transform.position = p2_pos;

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
