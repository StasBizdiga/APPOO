using UnityEngine;
using System;
using System.Collections;
	
namespace PlayerObject{
	
	public interface Movement{
		void moveY();
	}	
	
	public interface Rotation{
		void turnZ();
	}
	
public abstract class PlayerDefault{
		
	protected GameObject player;
	protected float moveSpeed = 8f;	// paddle speed	
	protected float yLimit = 3.5f; 	// y axis boundary (amplitude)
	
	public abstract void allowMovement ();
}

public class Player1 : PlayerDefault, Movement, Rotation {

	public Player1(){
			player = GameObject.FindGameObjectWithTag ("Player1"); // alternatively could instantiate from prefab
		}

	public override void allowMovement(){ //(<-left player)
		// P1 Move controls 
		moveY();
		// P1 Rotation controls
		turnZ();
	}

	public void moveY(){
		if (Input.GetKey ("w") && player.transform.position.y < yLimit) {
		player.transform.Translate (Vector3.up * Time.deltaTime * moveSpeed, Space.World);
		} 
		else if (Input.GetKey ("s") && player.transform.position.y > -yLimit) {
		player.transform.Translate (Vector3.down * Time.deltaTime * moveSpeed, Space.World);
		}
	}
	public void turnZ(){
		if (Input.GetKey ("d")) {
			player.transform.rotation = Quaternion.Euler (0f, 0f, -15f);
		} else if (Input.GetKey ("a")) {
			player.transform.rotation = Quaternion.Euler (0f, 0f, 15f);
		} else { 
			player.transform.rotation = Quaternion.Euler (0f, 0f, 0f);
		}
	}
}


public class Player2 : PlayerDefault, Movement, Rotation {
		public Player2(){ 
			player = GameObject.FindGameObjectWithTag ("Player2"); 
		}

	public override void allowMovement(){ //(right player->)
		// P2 Move controls 
		moveY();
		// P2 Rotation controls
		turnZ();
	}

	public void moveY(){
			if (Input.GetKey ("up") && player.transform.position.y < yLimit) {
			player.transform.Translate (Vector3.up * Time.deltaTime * moveSpeed, Space.World);
			} else if (Input.GetKey ("down") && player.transform.position.y > -yLimit) {
			player.transform.Translate (Vector3.down * Time.deltaTime * moveSpeed, Space.World);
		}
	}

	public void turnZ(){
		if (Input.GetKey ("right")) {
			player.transform.rotation =  Quaternion.Euler(0f,0f,-15f);
		} else if (Input.GetKey ("left")) {
			player.transform.rotation = Quaternion.Euler(0f,0f,15f);
		} else { 
			player.transform.rotation = Quaternion.Euler (0f, 0f, 0f);
		}
	}
}

			
}