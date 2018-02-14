using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour {
	public static Score instance;
	private Text scoreL,scoreR,textWinner;
	private string winText1,winText2;

	void Start()
	{
		// getting score text stored in vars
		scoreR = GameObject.FindGameObjectWithTag ("scoreR").GetComponent<Text>();
		scoreL = GameObject.FindGameObjectWithTag ("scoreL").GetComponent<Text>();
		textWinner = GameObject.Find("WinText").GetComponent<Text>();

		winText1 = "CONGRATULATIONS\n<< WINNER   ";
		winText2 = "CONGRATULATIONS\n   WINNER >>";
			
	}

	void Awake(){
		// making the script usable externally
		instance = this;
	}

	public void plusOneLeft()	{scoreL.text = (int.Parse (scoreL.text) + 1).ToString (); } // add +1 score to left player (#1)

	public void	plusOneRight()	{scoreR.text = (int.Parse (scoreR.text) + 1).ToString (); } // add +1 score to right player (#2)

	public int getScoreL () 	{ return int.Parse(scoreL.text);}

	public int getScoreR () 	{ return int.Parse(scoreR.text);}

	public int checkWinner() {
		if 		(getScoreR () > 9)	return 2;
		else if (getScoreL () > 9)  return 1;
		else 						return 0;
	}

	public void setWinnerUI(int player)	{
		
		//// error prevention with null pointer exception
		//if (textWinner == null){textWinner = GameObject.Find("WinText").GetComponent<Text>();}

		switch (player) {
		case 1:
			textWinner.text = winText1;
			break;
		case 2:
			textWinner.text = winText2;
			break;
		default:
			textWinner.text = "Nobody Wins!";
			break;
		}
	}
}
