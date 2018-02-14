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
		EndScreen = GameObject.FindGameObjectWithTag ("ENDSCREEN");

		setEndScreen   (false);
	}

	void Awake(){
		// making the script usable externally
		instance = this;
	}

	public void setStartScreen(bool b)	{ StartScreen.SetActive (b); }
		
	public void setEndScreen(bool b)		{ EndScreen.SetActive (b); }

	public void enableWinVFX(int player)	{
		switch (player) {
		case 1:
			setEndScreen (true);
			pFX1.SetActive (true);
			pFX2.SetActive (false);
			Score.instance.setWinnerUI(1);
			break;
		case 2:
			setEndScreen (true);
			pFX2.SetActive (true);
			pFX1.SetActive (false);
			Score.instance.setWinnerUI(2);
			break;
		default:
			break;
		}
	}

}
