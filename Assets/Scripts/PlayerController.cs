using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float jumpPower = 10.0f;
	public float rotateSpeed = 1.0f;
	Rigidbody2D myRigidbody;
	bool isGrounded = false;
	bool isGameOver = false;
	float posX = 0.0f;
	public float score = 0.0f;
	ChallengeController myChallengeController;
	GameController myGameController;

	// Use this for initialization
	void Start () {
		myRigidbody = transform.GetComponent<Rigidbody2D> ();
		posX = transform.position.x;
		myChallengeController = GameObject.FindObjectOfType<ChallengeController> ();
		myGameController = GameObject.FindObjectOfType<GameController> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKey (KeyCode.Space) && isGrounded && !isGameOver) {
			myRigidbody.AddForce (Vector3.up * (jumpPower * myRigidbody.mass * myRigidbody.gravityScale * 20.0f));
		}
		if (transform.position.x < posX) {
			GameOver ();
		}
	}

	void Update() {
		
	}

	void GameOver() {
		isGameOver = true;
		myChallengeController.GameOver ();
		Debug.Log ("Game Over");
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.collider.tag == "Ground") {
			isGrounded = true;
		}
		if (other.collider.tag == "Enemy") {
			GameOver ();
		}
	}
	void OnCollisionStay2D(Collision2D other) {
		if (other.collider.tag == "Ground") {
			isGrounded = true;
		}
	}
	void OnCollisionExit2D(Collision2D other) {
		if (other.collider.tag == "Ground") {
			isGrounded = false;
		}
	}
	void OnTriggerEnter2D(Collider2D other) {
		if (other.GetComponent<Collider2D>().tag == "Star") {
			myGameController.IncrementScore ();
		}
	}

}
