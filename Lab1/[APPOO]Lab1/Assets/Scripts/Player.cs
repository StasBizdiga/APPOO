using UnityEngine;
using System;
using System.Collections;
	
namespace PlayerObject{
	
	public interface Movement{
		void move();
	}

	public interface Rotation{
		void turn();
	}
	
public abstract class PlayerDefault{
		
	public GameObject player;
	public string[] controls; 

}

	public class PaddleFactory{
		public PaddlePlayer getInstance(int id, string[] controls){
			PaddlePlayer p = new PaddlePlayer ();
			p.controls = controls;
			switch(id){
			case 1:
				p.player = GameObject.FindGameObjectWithTag ("Player1"); // alternatively can instantiate from prefab
				break;
			case 2:
				p.player = GameObject.FindGameObjectWithTag ("Player2"); 
				break;
			default:
				return null;
			}
			return p;
		}
	}

	public class SpectatorFactory{
		public Spectator getInstance(string[] controls){
			Spectator p = new Spectator ();
			p.controls = controls;
			p.player = GameObject.FindGameObjectWithTag ("spectator"); // alternatively can instantiate from prefab
			return p;
		}
	}
		
public class PaddlePlayer : PlayerDefault, Movement, Rotation {
		
		protected float moveSpeed = 10f;	// paddle speed	
		protected float yLimit = 3.5f; 	// y axis boundary (amplitude)

		public void autoFollow(GameObject o){
			if (o.transform.position.y > player.transform.position.y && player.transform.position.y < yLimit) {
				player.transform.Translate (Vector3.up * Time.deltaTime * moveSpeed, Space.World);
			} else if (o.transform.position.y < player.transform.position.y  && player.transform.position.y > -yLimit) {
				player.transform.Translate (Vector3.down * Time.deltaTime * moveSpeed, Space.World);
			}
		}

		public void move(){
			if (Input.GetKey (controls[0]) && player.transform.position.y < yLimit) {
				player.transform.Translate (Vector3.up * Time.deltaTime * moveSpeed, Space.World);
			} else if (Input.GetKey (controls[1]) && player.transform.position.y > -yLimit) {
				player.transform.Translate (Vector3.down * Time.deltaTime * moveSpeed, Space.World);
			}
		}

		public void turn(){
			if (Input.GetKey (controls[2])) {
				player.transform.rotation = Quaternion.Euler (0f, 0f, -15f);
			} else if (Input.GetKey (controls[3])) {
				player.transform.rotation = Quaternion.Euler (0f, 0f, 15f);
			} else { 
				player.transform.rotation = Quaternion.Euler (0f, 0f, 0f); // return to normal
			}
		}
	}



	public class Spectator : PlayerDefault, Movement, Rotation {
		
		protected float moveSpeed = 5f;
		protected float xyLimit = 3.5f; 	// boundary


		public void move(){
			if (Input.GetKey (controls [0]) && player.transform.position.y < xyLimit) {
				player.transform.Translate (Vector3.up * Time.deltaTime * moveSpeed, Space.World);
			} else if (Input.GetKey (controls [1]) && player.transform.position.y > -xyLimit) {
				player.transform.Translate (Vector3.down * Time.deltaTime * moveSpeed, Space.World);
			} else if (Input.GetKey (controls [2]) && player.transform.position.x < xyLimit) {
				player.transform.Translate (Vector3.right * Time.deltaTime * moveSpeed, Space.World);
			} else if (Input.GetKey (controls [3]) && player.transform.position.x > -xyLimit) {
				player.transform.Translate (Vector3.left * Time.deltaTime * moveSpeed, Space.World);
			}
		}
		public void turn(){
			if (Input.GetKey (controls[4])) {
				player.transform.rotation = Quaternion.Euler (0f, 0f, -15f);
			} else if (Input.GetKey (controls[5])) {
				player.transform.rotation = Quaternion.Euler (0f, 0f, 15f);
			} else { 
				player.transform.rotation = Quaternion.Euler (0f, 0f, 0f); // return to normal
			}
		}
	}
}