using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerEnemie : MonoBehaviour
{
	private Transform PLAYER;

	private Rigidbody2D rb;

	private Vector2 moveDirection;

	public float moveSpeed;

	private void Start () {
		PLAYER = GameObject.FindGameObjectWithTag ("PLAYER").transform;
		rb = GetComponent<Rigidbody2D> ();
	}

	private void FixedUpdate () {
		moveDirection = ((Vector2)PLAYER.position - (Vector2)transform.position).normalized;

		rb.MovePosition (rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
	}


	public health hp;

	private void OnTriggerEnter2D (Collider2D collision) {

		if (collision.tag == "BULLET") {
			hp.TakeDamage (25);
		}
	}
}
