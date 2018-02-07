using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour {
	public float constantSpeed = 10f;
	private Vector3 velocity;

	void Start () {
		// Reset init params
		constantSpeed = 10f;

		// Pause game before launching the ball
		GameController.Instance.PauseGame ();

		// Granting random orientation to the ball launch
		this.GetComponent<Rigidbody> ().velocity = new Vector3(2f*Random.Range(1,3)-3f,0.9f*2f*Random.Range(1,3)-3f,0f);

		// Storing the vel in a var for comfort
		velocity = this.GetComponent<Rigidbody>().velocity;

	}

	void LateUpdate () {

		this.GetComponent<Rigidbody>().velocity = constantSpeed * (this.GetComponent<Rigidbody>().velocity.normalized);
		if (this.GetComponent<Rigidbody> ().velocity.y == 0f)  // to avoid straight horizontal line infinity loop
		{
			// adding some spice (velocity on y axis)
			this.GetComponent<Rigidbody> ().velocity = 
				new Vector3(this.GetComponent<Rigidbody>().velocity.x,0.9f*2f*Random.Range(1,3)-3f,0f); 
		}
		velocity = this.GetComponent<Rigidbody> ().velocity;
	}

	private void addSpeed()
	{
		constantSpeed += 0.25f;
	}

	void OnTriggerEnter (Collider other)
	{
		ScreenShake.Shake (0.1f,0.005f, velocity.x, velocity.y);
		addSpeed ();
	}
}
