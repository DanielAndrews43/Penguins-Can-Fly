﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

	public void ToGame(){
		SceneManager.LoadScene (1);
	}

	public void ToMenu(){
		SceneManager.LoadScene (0);
	}

	public void ToAchievements(){
		SceneManager.LoadScene (2);
	}

	public void ToShop(){
		SceneManager.LoadScene (3);
	}

	public void ToSettings(){
		SceneManager.LoadScene (4);
	}
}
