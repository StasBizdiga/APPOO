using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class VfxController : MonoBehaviour {
	public static VfxController instance;
	private GameObject pFX1,pFX2,EndScreen,StartScreen;

	void Start () {
		// storing the particle effects in variables
		pFX1 = GameObject.FindGameObjectWithTag ("pFX1");
		pFX2 = GameObject.FindGameObjectWithTag ("pFX2");

		// storing title screens in variables
		StartScreen = GameObject.FindGameObjectWithTag ("STARTSCREEN");
		EndScreen = GameObject.FindGameObjectWithTag     ("ENDSCREEN");

		setEndScreen   (false);
	}

	void Awake(){
		// making the script usable externally
		instance = this;
	}

	public void setStartScreen(bool b)	  { StartScreen.SetActive (b); }
		
	public void setEndScreen(bool b)		{ EndScreen.SetActive (b); }

	public void enableWinVFX(int player)	{
		setEndScreen (true);
		Score.instance.setWinnerUI (player);
		switch (player) {
		case 1:
			pFX1.SetActive (true);
			pFX2.SetActive (false);
			break;
		case 2:
			pFX1.SetActive (false);
			pFX2.SetActive (true);
			break;
		default:
			break;
		}
	}

}
