using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour {
	private float constantSpeed = 10f;
	private int direction;
	void Start () {
		//random direction orientation (ball-launch)
		this.GetComponent<Rigidbody> ().velocity = new Vector3(2f*Random.Range(1,3)-3f,0.9f*2f*Random.Range(1,3)-3f,0f);
	}

	// Update is called once per frame
	void LateUpdate () {
		this.GetComponent<Rigidbody>().velocity = constantSpeed * (this.GetComponent<Rigidbody>().velocity.normalized);
	}
}
