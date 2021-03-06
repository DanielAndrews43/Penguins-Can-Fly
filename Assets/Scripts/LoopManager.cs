﻿using UnityEngine;
using System.Collections;

public class LoopManager : MonoBehaviour {

	float obstacleMin = -0.3f;
	float obstacleMax = 2.7f;

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

		float width = ((BoxCollider2D)coll).size.x * coll.transform.localScale.x;
		Vector3 pos = coll.transform.position;

		pos.x += width * numPanels;

		if (coll.tag == "Obstacle") {
			pos.y = Random.Range (obstacleMin, obstacleMax);
		}

		coll.transform.position = pos;
	}
}
