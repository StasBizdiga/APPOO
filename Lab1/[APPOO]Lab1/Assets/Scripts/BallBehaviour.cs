using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour {
	public float constantSpeed = 10f;
	private Vector3 velocity;
	private Rigidbody rb;

	void Start () {
		// Reset init params
		constantSpeed = 10f;

		// storing the rigidbody in a var for code cleanliness
		rb = this.GetComponent<Rigidbody> ();

		// Pause game before launching the ball
		GameController.instance.PauseGame ();


		// Granting random orientation(angle) to the ball launch
		rb.velocity = 
			new Vector3(2f * Random.Range(1,3) - 3f, 		// -1 or 1 on X
						2f * 0.9f * Random.Range(1,3) - 3f, // -0.9 or 0.9 on Y
						0f );

	}

	void LateUpdate () {
		
		// every frame set the speed of the ball to remain constant
		rb.velocity = constantSpeed * (rb.velocity.normalized);

		// portion to avoid straight horizontal line infinity loop
		if (rb.velocity.y == 0f)  
		{
			// adding some spice (velocity on y axis)
			rb.velocity = 
				new Vector3(rb.velocity.x,
					2f * 0.9f * Random.Range(1,3) - 3f, //here
					0f ); 
		}
	}

	private void addSpeed()
	{
		constantSpeed += 0.25f;
	}

	void OnTriggerEnter (Collider other)
	{
		ScreenShake.Shake (0.1f,0.005f, rb.velocity.x, rb.velocity.y);
		addSpeed ();
	}
}
