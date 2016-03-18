using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AchievementManager : MonoBehaviour {

	public GameObject prefab;
	public GameObject otherPrefab;

	public Sprite[] sprites;
	public Sprite[] backgrounds;

	public int[] arr = new int[10];

	int index = 0;
	int scores = 0;



	void Start () {
		updater ();
		CreateAchievement ("Achievements","",-1,-1);
		CreateAchievement ("Beginner", "Achieve a highscore of 10", 10, 0); //0
		CreateAchievement ("Intermediate", "Achieve a highscore of 50", 50, 0); //1
		CreateAchievement ("Advanced", "Achieve a highscore of 100", 100, 0);//2
		CreateAchievement ("Veteran", "Achieve a highscore of 500", 500, 0);//3
		CreateAchievement ("Legend", "Achieve a highscore of 1000", 1000, 0);//4
		CreateAchievement ("First Death", "Die Once", 1, 0);//5
		CreateAchievement ("LegenDIEry", "Die 10 times", 10, 0);//6
		CreateAchievement ("50th Anniversary", "Die 50 Times", 50, 0);//7
		CreateAchievement ("LegenDIEry", "Die 100 times", 100, 0);//8
		CreateAchievement ("Afterlife", "Die 500 times", 500, 0);//9
		GameObject text = GameObject.FindGameObjectWithTag("Player");
		text.GetComponent<Text>().text = "Score: " + scores.ToString ();
	}

	void updater(){

		int score = PlayerPrefs.GetInt ("HighScore", 0);
		int deaths = PlayerPrefs.GetInt ("deaths", 0);

		for (int i = 0; i < arr.Length; i++) {
			arr[i] = 0;
		}

		if (score >= 10) {
			arr [0] = 1;
			scores += 10;
		}if (score >= 50){
			arr [1] = 1;
			scores+=50;
		}if (score >= 100){
			arr [2] = 1;
			scores+=100;
		}if (score >= 500){
			arr [3] = 1;
			scores+=500;
		}if (score >= 1000){
			arr [4] = 1;
			scores+=1000;
		}if (deaths >= 1){
			arr [5] = 1;
			scores+=1;
		}if (deaths >= 10){
			arr [6] = 1;
			scores+=10;
		}if (deaths >= 50) {
			arr [7] = 1;
			scores+=50;
		}if (deaths >= 100) {
			arr [8] = 1;
			scores+=100;
		}if (deaths >= 500) {
			arr [9] = 1;
			scores+=500;
		}

	}

	public void CreateAchievement(string title, string description, int points, int spriteIndex){

		if (points == -1) {
			GameObject achievement = (GameObject)Instantiate(otherPrefab);
			achievement.transform.SetParent (GameObject.Find ("AchievementHolder").transform);
			achievement.transform.localScale = new Vector3 (1, 1, 1);




		} else {
			GameObject achievement = (GameObject)Instantiate (prefab);
			achievement.transform.SetParent (GameObject.Find ("AchievementHolder").transform);
			achievement.transform.localScale = new Vector3 (1, 1, 1);

			achievement.transform.GetChild (0).GetComponent<Text> ().text = title;
			achievement.transform.GetChild (1).GetComponent<Text> ().text = description;
			achievement.transform.GetChild (2).GetComponent<Text> ().text = points.ToString ();
			achievement.transform.GetChild (3).GetComponent<Image> ().sprite = sprites [spriteIndex];
			achievement.transform.GetComponent<Image> ().overrideSprite = backgrounds [arr[index]];
			index ++;
		}

	}

}
