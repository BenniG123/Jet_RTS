using UnityEngine;
using System.Collections;

public class MissileMovement : MonoBehaviour {
	
	public float speed;
	public GameObject explosionPrefab;
	public float lifeTime;
	private Transform target;
	private float time;

	// Use this for initialization
	void Start () {
		time = 0.0f;
		target = GetNearestTaggedObject();
	}
	
	void LateUpdate()
	{
		float step = speed * Time.deltaTime;
		if(target) {
			transform.position = Vector3.MoveTowards (transform.position, target.position, step);
		} else {
			transform.Translate(Vector3.up * step);
		}
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if(time > lifeTime) {
			Explode();
		}
	}
	
	void Explode() {
		Instantiate(explosionPrefab, transform.position, transform.rotation);
		Destroy(this.gameObject);
	}
	
	void OnCollisionEnter2D(Collision2D coll)
	{
			Explode();
			Destroy(coll.gameObject);
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