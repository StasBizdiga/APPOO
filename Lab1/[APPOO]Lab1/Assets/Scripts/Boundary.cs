using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Boundary : MonoBehaviour {
	public GameObject ball,pFX1,pFX2;
	public AudioClip lose1,lose2,lose3,lose4,lose5,win1,win2,win3;
	public Text scoreL,scoreR,textWinner;
	void Start () {
		// closing the particle effects
		pFX1.SetActive (false);
		pFX2.SetActive (false);

		// getting score text stored in vars
		scoreR = GameObject.FindGameObjectWithTag ("scoreR").GetComponent<Text>();
		scoreL = GameObject.FindGameObjectWithTag ("scoreL").GetComponent<Text>();
	}

	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		Destroy(other.gameObject);
		Debug.Log (this.gameObject);

		if(this.gameObject.tag == "WallL")
		{scoreR.text = (int.Parse (scoreR.text) + 1).ToString (); 
			SoundManager.instance.PlayOtherSfx (lose1, lose2, lose3, lose4, lose5);}

		if(this.gameObject.tag == "WallR")
		{scoreL.text = (int.Parse (scoreL.text) + 1).ToString (); 
			SoundManager.instance.PlayOtherSfx (lose1, lose2, lose3, lose4, lose5);}

		if (int.Parse (scoreL.text) > 9) {
			textWinner.text = "CONGRATULATIONS\n<< WINNER   ";
			UserInput.Instance.EndGame ();
			pFX1.SetActive (true);
			SoundManager.instance.PlaySong (win1,win2,win3);
		} else if (int.Parse (scoreR.text) > 9) {
			textWinner.text = "CONGRATULATIONS\n   WINNER >>";
			UserInput.Instance.EndGame ();
			SoundManager.instance.PlaySong (win1,win2,win3);
			pFX2.SetActive (true);
		}

	}
}
