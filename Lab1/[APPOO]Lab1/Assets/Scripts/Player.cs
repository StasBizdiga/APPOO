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
	protected string[] controls; 
	
	//public abstract void allowMovement (Movement mov, Rotation rot);
}

public class PaddlePlayer : PlayerDefault, Movement, Rotation {
		
		protected float moveSpeed = 8f;	// paddle speed	
		protected float yLimit = 3.5f; 	// y axis boundary (amplitude)

		public PaddlePlayer(int ID){
			controls = new string[4]; 	// [w,a,s,d]
			switch(ID){
			case 1:
				player = GameObject.FindGameObjectWithTag ("Player1"); // alternatively could instantiate from prefab
				// defining controls
				controls[0] = "w";
				controls[1] = "s";
				controls[2] = "d";
				controls[3] = "a";
				break;
			case 2:
				player = GameObject.FindGameObjectWithTag ("Player2"); 
				controls[0] = "up";
				controls[1] = "down";
				controls[2] = "right";
				controls[3] = "left";
				break;
			default:
				break;
			}
		}

		/*public override void allowMovement(Movement mov, Rotation rot){
			mov.moveY(); // Move controls 
			rot.turnZ(); // Rotation controls

		}*/
		public void autoFollow(GameObject o){
			if (o.transform.position.y > player.transform.position.y && player.transform.position.y < yLimit) {
				player.transform.Translate (Vector3.up * Time.deltaTime * moveSpeed, Space.World);
			} else if (o.transform.position.y < player.transform.position.y  && player.transform.position.y > -yLimit) {
				player.transform.Translate (Vector3.down * Time.deltaTime * moveSpeed, Space.World);
			}
		}

		public void moveY(){
			if (Input.GetKey (controls[0]) && player.transform.position.y < yLimit) {
				player.transform.Translate (Vector3.up * Time.deltaTime * moveSpeed, Space.World);
			} else if (Input.GetKey (controls[1]) && player.transform.position.y > -yLimit) {
				player.transform.Translate (Vector3.down * Time.deltaTime * moveSpeed, Space.World);
			}
		}

		public void turnZ(){
			if (Input.GetKey (controls[2])) {
				player.transform.rotation = Quaternion.Euler (0f, 0f, -15f);
			} else if (Input.GetKey (controls[3])) {
				player.transform.rotation = Quaternion.Euler (0f, 0f, 15f);
			} else { 
				player.transform.rotation = Quaternion.Euler (0f, 0f, 0f); // return to normal
			}
		}
	}

}