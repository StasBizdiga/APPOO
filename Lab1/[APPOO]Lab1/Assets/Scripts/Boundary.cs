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
			Score.instance.addScore (2);
			SoundManager.instance.PlayOtherSfx (lose1, lose2, lose3, lose4, lose5);
			ps.Play(true);
		}

		if(this.gameObject.tag == "WallR")
		{
			Score.instance.addScore (1);
			SoundManager.instance.PlayOtherSfx (lose1, lose2, lose3, lose4, lose5);
			ps.Play(true);
		}

		if (Score.instance.getScore(1) > 9 || Score.instance.getScore(2) > 9) {
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
