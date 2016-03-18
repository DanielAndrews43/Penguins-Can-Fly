using UnityEngine;
using System.Collections;

public class ResizeToCanvasHeight : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//This works. Probably shouldn't touch it
		GetComponent<RectTransform> ().sizeDelta = new Vector2(GetComponent<RectTransform> ().rect.width, GameObject.FindGameObjectWithTag ("Canvas").GetComponent<RectTransform> ().rect.height);
	}
}
