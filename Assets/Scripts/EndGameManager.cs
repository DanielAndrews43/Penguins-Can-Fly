using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndGameManager : MonoBehaviour {

	public Text score;
	public Text highScore;

	void Start(){
		score.text = "Score: " + PlayerPrefs.GetInt (GameManager.PLAYER_SCORE_STRING);
		highScore.text = "High Score: " + PlayerPrefs.GetInt (GameManager.PLAYER_HIGHSCORE_STRING);
	}

}
