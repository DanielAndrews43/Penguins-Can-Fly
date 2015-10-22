using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AchievementManager : MonoBehaviour {

	public GameObject prefab;

	public Sprite[] sprites;
	
	void Start () {
		CreateAchievement ("Beginner", "Make it past the first pipe!", 10, 0);
		CreateAchievement ("Intermediate", "Score 3 points without dieing", 20, 0);
		CreateAchievement ("Advanced Flier", "Score 10 points without dieing", 30, 0);
		CreateAchievement ("Death Streak", "Die three times without scoring", 10, 0);
		CreateAchievement ("Mario", "Try to fly into a pipe", 10, 0);
		CreateAchievement ("Consistent Failure", "Score one point three times in a row", 20, 0);
	}

	public void CreateAchievement(string title, string description, int points, int spriteIndex){
		GameObject achievement = (GameObject)Instantiate (prefab);
		achievement.transform.SetParent(GameObject.Find ("AchievementHolder").transform);
		achievement.transform.localScale = new Vector3 (1, 1, 1);

		achievement.transform.GetChild (0).GetComponent<Text> ().text = title;
		achievement.transform.GetChild (1).GetComponent<Text> ().text = description;
		achievement.transform.GetChild (2).GetComponent<Text> ().text = points.ToString ();
		achievement.transform.GetChild (3).GetComponent<Image> ().sprite = sprites[spriteIndex];
	}
}
