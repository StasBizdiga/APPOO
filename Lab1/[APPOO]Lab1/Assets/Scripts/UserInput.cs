using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour {

	public GameObject player1,player2;
	private float moveSpeed = 4f;

	void Start () {
		
	}

	void Update () {
		if (Input.GetKey("up") && player2.transform.position.y<3.5f)
		{
			player2.transform.Translate(Vector3.up * Time.deltaTime * moveSpeed, Space.World);
		}
		else if (Input.GetKey("down") && player2.transform.position.y>-3.5f)
		{
			player2.transform.Translate(Vector3.down * Time.deltaTime * moveSpeed, Space.World);
		}

		if (Input.GetKey("w") && player1.transform.position.y<3.5f)
		{
			player1.transform.Translate(Vector3.up * Time.deltaTime * moveSpeed, Space.World);
		}
		else if (Input.GetKey("s") && player1.transform.position.y>-3.5f)
		{
			player1.transform.Translate(Vector3.down * Time.deltaTime * moveSpeed, Space.World);
		}
	}
}
