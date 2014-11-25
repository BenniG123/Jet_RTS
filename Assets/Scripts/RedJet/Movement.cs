using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public float maxMoveSpeed;
	public float minMoveSpeed;
	private float moveSpeed;
	public float accelRate;
	public float decelRate;
	public float maxTurnRate;
	public float turnRate;
	private float turn;
	public Sprite leftTurn;
	public Sprite rightTurn;
	public Sprite straight;
	public int leftRight;
	public int accelDecel;

	// Use this for initialization
	void Start () {
		turn = 0.0f;
		moveSpeed = maxMoveSpeed;
	
	}
	
	// Update is called once per frame
	void Update () {

		if(accelDecel == 1) {
			if(moveSpeed < maxMoveSpeed) {
				moveSpeed += accelRate * Time.deltaTime;
				Debug.Log("accelerating " + moveSpeed);
			}
			else {
				moveSpeed = maxMoveSpeed;
			}
		}
		else if(accelDecel == -1) {
			if(moveSpeed > minMoveSpeed) {
				moveSpeed -= accelRate * Time.deltaTime;
				Debug.Log("decelerating " + moveSpeed);
			}
			else {
				moveSpeed = minMoveSpeed;
			}
		}
		if(leftRight == -1) {
			if(turn > -maxTurnRate) {
				turn -= turnRate * Time.deltaTime;
				Debug.Log("turning " + turn);
			}
			else {
				turn = -maxTurnRate;
			}
			transform.RotateAround(transform.position,Vector3.forward, -turn);
		} else if(leftRight == 1) {
			if(turn < maxTurnRate) {
				turn += turnRate * Time.deltaTime;
				Debug.Log("turning " + turn);
			}
			else {
				turn = maxTurnRate;
			}
			transform.RotateAround(transform.position,Vector3.forward, -turn);
		}

		if(leftRight == 0) {
			turn = 0.0f;
		}

		if(turn > 0.0f) {
			GetComponent<SpriteRenderer>().sprite = rightTurn;
		}
		else if(turn < 0.0f) {
			GetComponent<SpriteRenderer>().sprite = leftTurn;
		}
		else {
			GetComponent<SpriteRenderer>().sprite = straight;
		}
		transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
	
	}
}
