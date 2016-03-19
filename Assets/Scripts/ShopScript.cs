using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour {

	public GameObject[] skinPrefabs;
	GameObject[] skins;
	public GameObject skinHolder;
	ScrollRect scroller;
	public GameObject scrollBar;

	Vector3 scrollBarCenter;
	float scrollBarWidth;

	bool isBeingScrolled;

	void Start () {

		skins = new GameObject[skinPrefabs.Length];

		scroller = scrollBar.GetComponent<ScrollRect> ();

		scrollBarCenter = scrollBar.transform.position;
		Debug.Log (scrollBarCenter);
		scrollBarWidth = scrollBar.GetComponent<RectTransform> ().rect.x * -1;

		for (int i = 0; i < skinPrefabs.Length; i++) {
			Vector3 GOPosition = new Vector3 (scrollBarCenter.x + (scrollBarWidth / 1.5f * i), scrollBarCenter.y);

			GameObject GO = (GameObject)Instantiate (skinPrefabs [i], GOPosition, Quaternion.identity);
			GO.transform.SetParent (skinHolder.transform);

			skins [i] = GO;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
		if (scroller.velocity.Equals(Vector2.zero)) {
			isBeingScrolled = false;
		} else {
			isBeingScrolled = true;
		}

		for (int i = 0; i < skins.Length; i++) {
			float difference = Mathf.Abs (scrollBarCenter.x - skins [i].transform.position.x);
			float proportion = 3 - Mathf.Pow ((difference) / (scrollBarWidth/2), 2);

			if (proportion < 0) {
				proportion = 0;
			}
			skins [i].transform.localScale = new Vector3 (proportion, proportion, 1);
		}

		if (!isBeingScrolled) {
			SnapToNearest ();
		}

	}

	void SnapToNearest(){
		float min = Mathf.Abs (scrollBarCenter.x - skins [0].transform.position.x);
		int index = 0;

		for (int i = 0; i < skins.Length; i++) {
			if (Mathf.Abs (scrollBarCenter.x - skins [i].transform.position.x) < min) {
				min = Mathf.Abs (scrollBarCenter.x - skins [i].transform.position.x);
				index = i;
			}
		}

		//move scrollbar until position of GO at index i = center;

	}
}
