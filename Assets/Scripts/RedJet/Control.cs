using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour {

	public GameObject missile;
	public Transform controlee;
	private int toggle;

	// Use this for initialization
	void Start () {
		toggle = 0;
	}

	// Update is called once per frame
	void Update () {

		//Change control to a different jet
		if(Input.GetKeyDown(KeyCode.Return)) {
			GameObject[] jets = GameObject.FindGameObjectsWithTag("FriendlyJet");
			controlee.GetComponent<Movement>().accelDecel = 0;
			controlee.GetComponent<Movement>().leftRight = 0;
			controlee = jets[toggle].transform;
			GetComponent<BoundingBox>().target = controlee;
			toggle++;
			if(toggle == jets.Length)
				toggle = 0;
		}

		//Fire a missile from controlled jet
		if(Input.GetKeyDown(KeyCode.Space)) {
			Quaternion q = controlee.rotation;
			q = q * Quaternion.Euler(0,0,-90);
			Instantiate(missile, controlee.position, q);
		}

		//Manual Flight Controls
		if (Input.GetKey(KeyCode.LeftArrow)) {
			controlee.GetComponent<Movement>().leftRight = -1;
		} else if (Input.GetKey(KeyCode.RightArrow)) {
			controlee.GetComponent<Movement>().leftRight = 1;
		}
		if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow)) {
			controlee.GetComponent<Movement>().leftRight = 0;
		}
		if (Input.GetKey(KeyCode.UpArrow)) {
			controlee.GetComponent<Movement>().accelDecel = 1;
		} else if (Input.GetKey(KeyCode.DownArrow)) {
			controlee.GetComponent<Movement>().accelDecel = -1;
		}
		if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow)) {
			controlee.GetComponent<Movement>().accelDecel = 0;
		}
		
	}
}
