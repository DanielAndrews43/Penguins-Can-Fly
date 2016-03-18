using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	private static bool clickedStart = false;

	public Text text;
	private bool firstTime = true;

	public const string PLAYER_SCORE_STRING = "score";
	public const string PLAYER_HIGHSCORE_STRING = "highscore";


	void Start () {
		clickedStart = false;
		Time.timeScale = 0;
	}

	void Update () {
		if (firstTime && Input.GetKeyDown ("space")) {
			Time.timeScale = 1;
			clickedStart = true;
			text.gameObject.SetActive (false);
			firstTime = false;
		}

		if (!PlayerScript.GetAlive()) {
			DisplayGameOver ();
		}
	}

	public static bool HasClickedStart(){
		return clickedStart;
	}

	public static void SetClickedStartFalse(){
		clickedStart = false;
	}

	void DisplayGameOver(){
		PlayerPrefs.SetInt (PLAYER_SCORE_STRING, ScoreManager.GetPoints());
		if (PlayerPrefs.GetInt (PLAYER_HIGHSCORE_STRING, 0) < PlayerPrefs.GetInt (PLAYER_SCORE_STRING, 0)) {
			PlayerPrefs.SetInt (PLAYER_HIGHSCORE_STRING, ScoreManager.GetPoints ());
		}
	}
}
