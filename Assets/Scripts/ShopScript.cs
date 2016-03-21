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
	float scrollBarWidthHalf;

	bool isBeingScrolled;

	public float speed;

	public float exponent;
	public int maxSize;
	public float distance;

	void Start () {

		skins = new GameObject[skinPrefabs.Length];

		scroller = scrollBar.GetComponent<ScrollRect> ();

		scrollBarCenter = scrollBar.transform.position;
		scrollBarWidthHalf = scrollBar.GetComponent<RectTransform> ().rect.x * -1;

		for (int i = 0; i < skinPrefabs.Length; i++) {
			Vector3 GOPosition = new Vector3 (scrollBarCenter.x + (scrollBarWidthHalf * distance * i), scrollBarCenter.y);

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
			float percentage = difference / scrollBarWidthHalf;
			float proportion = maxSize - (1 * Mathf.Pow ((percentage), exponent));

			if (proportion < 1) {
				proportion = 1;
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
		if(scrollBarCenter.x - skins [index].transform.position.x < 0){ // to the right
			float step = speed * Time.deltaTime;

		}
	}
}
