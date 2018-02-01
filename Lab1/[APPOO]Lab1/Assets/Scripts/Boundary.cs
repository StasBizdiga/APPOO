using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Boundary : MonoBehaviour {
	public GameObject ball;
	public Text scoreL,scoreR;
	void Start () {
		scoreR = GameObject.FindGameObjectWithTag ("scoreR").GetComponent<Text>();
		scoreL = GameObject.FindGameObjectWithTag ("scoreL").GetComponent<Text>();
	}

	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		Destroy(other.gameObject);
		Debug.Log (this.gameObject);

		if(this.gameObject.tag == "WallL")
		{scoreL.text = (int.Parse (scoreL.text) + 1).ToString (); }

		if(this.gameObject.tag == "WallR")
		{scoreR.text = (int.Parse (scoreR.text) + 1).ToString (); }

		Instantiate (ball, new Vector3 (0f, 0f, 0f), transform.rotation);
	}
}
