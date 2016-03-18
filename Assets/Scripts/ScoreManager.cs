using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
	private static int score;
	
	
	Text text;
	
	
	void Awake (){
		text = GetComponent <Text> ();
		score = 0;
	}

	public static void AddPoint(){
		score++;
	}

	public static int GetPoints(){
		return score;
	}
	
	void Update (){
		text.text = "Score: " + score;
	}
}