using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalEnemie : MonoBehaviour
{

	private Transform PLAYER;

	private Rigidbody2D rb;

	private void Start () {
		PLAYER = GameObject.FindGameObjectWithTag("PLAYER").transform;

		rb = GetComponent<Rigidbody2D>();

		StartCoroutine (Jump ());
	}
	

	IEnumerator Jump () {
		
		transform.up = ((Vector2)PLAYER.position - (Vector2)transform.position).normalized;

		rb.AddForce (transform.up * 10, ForceMode2D.Impulse);
		yield return new WaitForSeconds(1);
		StartCoroutine(Jump ());
	}

	public health hp;

	private void OnTriggerEnter2D (Collider2D collision) {

		if (collision.tag == "BULLET") {
			hp.TakeDamage (25);
		}
	}
}
