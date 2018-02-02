using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour {
	private float constantSpeed = 10f;

	void Start () {

		// Pause game before launching the ball
		UserInput.Instance.PauseGame ();

		// Granting random orientation to the ball launch
		this.GetComponent<Rigidbody> ().velocity = new Vector3(2f*Random.Range(1,3)-3f,0.9f*2f*Random.Range(1,3)-3f,0f);

	}

	void LateUpdate () {
		this.GetComponent<Rigidbody>().velocity = constantSpeed * (this.GetComponent<Rigidbody>().velocity.normalized);
	}
}
