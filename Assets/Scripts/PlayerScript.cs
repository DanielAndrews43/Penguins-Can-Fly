using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public Vector2 force;
	public static float speed = 5;
	public KeyCode jump;

	Rigidbody2D player;

	bool flap = false;
	bool isAlive = true;

	void Start(){
		player = GetComponent<Rigidbody2D> ();
		player.AddForce (force, ForceMode2D.Impulse);
		player.AddForce (Vector2.right * speed, ForceMode2D.Impulse);
	}


	void Update(){

		if (!isAlive)
			return;

		if (Input.GetKeyDown (jump)) {
			flap = true;
		}

	}

	void FixedUpdate(){

		if (!isAlive)
			return;

		if (flap) {
			player.AddForce(force, ForceMode2D.Impulse);
			flap = false;
		}

	}

	void OnCollisionEnter2D(Collision2D coll){
		isAlive = false;
	}
}

