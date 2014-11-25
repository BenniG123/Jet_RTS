using UnityEngine;
using System.Collections;

public class redTriangleMovement : MonoBehaviour {

	public Transform target;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(target) {
			Vector3 dir = target.position - transform.position;
			float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90.0f;
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		}
		else {
			Destroy(this.gameObject);
			}
		}

	public Transform GetNearestTaggedObject() { // and finally the actual process for finding the nearest object:
		
		float nearestDistanceSqr = Mathf.Infinity;
		GameObject[] taggedGameObjects = GameObject.FindGameObjectsWithTag("EnemyJet"); 
		Transform nearestObj = null;
		
		// loop through each tagged object, remembering nearest one found
		foreach (GameObject element in taggedGameObjects)
		{
			Vector3 objectPos = element.transform.position;
			float distanceSqr = (objectPos - transform.position).sqrMagnitude;
			
			if (distanceSqr < nearestDistanceSqr) {
				nearestObj = element.transform;
				nearestDistanceSqr = distanceSqr;
			}
		}
		return nearestObj;
	}
}