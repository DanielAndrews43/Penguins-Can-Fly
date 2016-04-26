using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public Vector2 force;
	public float speed;
	public KeyCode jump;

	Rigidbody2D player;

	bool flap = false;
	static bool isAlive = true;

	public bool godMode;
	float timeLeft = 0.1f;

	void Start(){
		player = GetComponent<Rigidbody2D> ();
	}

	public static bool GetAlive(){
		return isAlive;
	}

	void Update(){

		if (GameManager.HasClickedStart()) {
			//player.AddForce (force, ForceMode2D.Impulse);
			player.AddForce (Vector2.right * speed, ForceMode2D.Impulse);
			GameManager.SetClickedStartFalse ();
		}

		if (!isAlive) {
			if(timeLeft >= 0)
				timeLeft -= Time.deltaTime;
			else {
				this.GetComponent<CircleCollider2D> ().enabled = false;
				player.velocity = new Vector3 (0, player.velocity.y);
			}
			player.gravityScale = 3;
			return;
		}

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
			
		transform.Rotate (Vector3.forward);
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (godMode) {
			return;
		}
		isAlive = false;
	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.CompareTag ("PointBox")) {
			ScoreManager.AddPoint();
		}
	}
}

