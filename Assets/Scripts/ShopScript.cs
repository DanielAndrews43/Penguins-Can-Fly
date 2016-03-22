using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour {

	public GameObject[] skinPrefabs;
	GameObject[] skins;
	public GameObject skinHolder;
	public GameObject scrollBar;
	public RectTransform center;
	public RectTransform panel;

	float scrollBarWidthHalf;

	bool dragging;

	public float speed;

	public float exponent;
	public int maxSize;
	public float distance;

	bool firstTime = true;
	float skinDistance;

	int index;
	float min;

	void Start () {

		skins = new GameObject[skinPrefabs.Length];
		scrollBarWidthHalf = scrollBar.GetComponent<RectTransform> ().rect.x * -1;

		MakeSkins ();

		skinDistance = Mathf.Abs (skins [1].GetComponent<RectTransform> ().anchoredPosition.x - skins [0].GetComponent<RectTransform> ().anchoredPosition.x);
	}
	
	// Update is called once per frame
	void Update () {

		ResizeSkins ();

		if (!dragging) {
			SnapToNearest ();
			firstTime = false;
		}

	}

	void SnapToNearest(){
		if (firstTime) {
			index = 0;
			min = 100000;
			for (int i = 0; i < skins.Length; i++) {
				if (Mathf.Abs (skins [i].transform.position.x - center.transform.position.x) < min) {
					min = Mathf.Abs (skins [i].transform.position.x - center.transform.position.x);
					index = i;
				}
			}
		}

		float position = index * -skinDistance;

		float newX = Mathf.Lerp (panel.anchoredPosition.x, position, Time.deltaTime * 10f);
		Vector2 newPos = new Vector2 (newX, panel.anchoredPosition.y);

		panel.anchoredPosition = newPos;
	}

	public void BeginDrag(){
		dragging = true;
	}

	public void EndDrag(){
		dragging = false;
		firstTime = true;
	}

	void MakeSkins(){
		for (int i = 0; i < skinPrefabs.Length; i++) {
			Vector3 GOPosition = new Vector3 (center.transform.position.x + (scrollBarWidthHalf * distance * i), center.transform.position.y);

			GameObject GO = (GameObject)Instantiate (skinPrefabs [i], GOPosition, Quaternion.identity);
			GO.transform.SetParent (skinHolder.transform);

			skins [i] = GO;
		}
	}

	void ResizeSkins(){
		for (int i = 0; i < skins.Length; i++) {
			float difference = Mathf.Abs (center.transform.position.x - skins [i].transform.position.x);
			float percentage = difference / scrollBarWidthHalf;
			float proportion = maxSize - Mathf.Pow ((percentage), exponent);

			if (proportion < 1) {
				proportion = 1;
			}
			skins [i].transform.localScale = new Vector3 (proportion, proportion);
		}
	}
}
