using UnityEngine;
using System.Collections;

public class AddPoint : MonoBehaviour {
	
	void OnTriggerEnter2D(Collider2D coll){
		ScoreManager.score ++;
	}
}
