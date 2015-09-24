using UnityEngine;
using System.Collections;

public class LoopManager : MonoBehaviour {

	float obstacleMin = -0.115f;
	float obstacleMax = 3.82f;

	public int numPanels;


	void Start(){
		GameObject[] obstacles = GameObject.FindGameObjectsWithTag ("Obstacle");

		foreach (GameObject obstacle in obstacles) {
			Vector3 pos = obstacle.transform.position;

			pos.y = Random.Range(obstacleMin, obstacleMax);

			obstacle.transform.position = pos;
		}
	}

	void OnTriggerEnter2D(Collider2D coll){
		float width = ((BoxCollider2D)coll).size.x;
		Vector3 pos = coll.transform.position;
		pos.x += width * numPanels * coll.transform.localScale.x;

		if (coll.tag == "Obstacle") {
			pos.y = Random.Range (obstacleMin, obstacleMax);
		}

		coll.transform.position = pos;
	}
}
