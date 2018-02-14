using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Boundary : MonoBehaviour {
	public AudioClip lose1,lose2,lose3,lose4,lose5;
	ParticleSystem ps;

	void Start()
	{
		ps = this.GetComponentInChildren<ParticleSystem>();
	}

	void OnTriggerEnter(Collider other) {

		if(this.gameObject.tag == "WallL")
		{
			Score.instance.plusOneRight ();
			SoundManager.instance.PlayOtherSfx (lose1, lose2, lose3, lose4, lose5);
			ps.Play(true);
		}

		if(this.gameObject.tag == "WallR")
		{
			Score.instance.plusOneLeft ();
			SoundManager.instance.PlayOtherSfx (lose1, lose2, lose3, lose4, lose5);
			ps.Play(true);
		}

		if (Score.instance.getScoreL() > 9 || Score.instance.getScoreR() > 9) {
			GameController.instance.EndGame ();
		}

		StartCoroutine(DelayKill (1,other.gameObject));

	}

	IEnumerator DelayKill(int seconds, GameObject obj)
	{
		yield return new WaitForSeconds(seconds);
		Destroy (obj);
	}
}
