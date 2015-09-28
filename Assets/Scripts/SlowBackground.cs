using UnityEngine;
using System.Collections;

public class SlowBackground : MonoBehaviour {

	Rigidbody2D player;

	void Start(){
		GameObject player_ob = GameObject.FindGameObjectWithTag("Player");
		if (player_ob == null) {
			Debug.Log ("No player found");
			return;
		}

		player = player_ob.GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate(){
		Vector3 pos = transform.position;
		pos.x += player.velocity.x * Time.deltaTime * 0.9f;
		transform.position = pos;
	}
}
