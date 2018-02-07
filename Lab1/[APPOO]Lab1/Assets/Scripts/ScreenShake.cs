using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour {
	public static ScreenShake instance;
	private Vector3 originalPos = new Vector3(0f,0f,-10f);
	private float timeAtCurrentFrame;
	private float timeAtLastFrame;
	private float dynamicDelta;

	void Awake()
	{
		instance = this;
	}

	void Update() {
		// Calculate delta time, to screenShake while paused.
		timeAtCurrentFrame = Time.realtimeSinceStartup;
		dynamicDelta = timeAtCurrentFrame - timeAtLastFrame;
		timeAtLastFrame = timeAtCurrentFrame; 
	}

	public static void Shake (float duration, float amount, float xcoeff, float ycoeff) {
		instance.StartCoroutine (instance.cShake (duration,amount, xcoeff, ycoeff));
	}

	public IEnumerator cShake (float duration,float amount, float xcoeff, float ycoeff) {

		while (duration > 0) {
			Vector3 pos = this.transform.position;
			float shakeAmtx = -xcoeff*(Random.value)*amount;
			float shakeAmty = -ycoeff*(Random.value)*amount;
			this.transform.localPosition = originalPos + new Vector3 (shakeAmtx,shakeAmty,0f);

			duration -= dynamicDelta;

			yield return null;
		}

		transform.localPosition = originalPos;
	}
}
