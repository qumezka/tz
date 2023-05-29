using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

	private Rigidbody2D rb;

	private float horizontal, vertical;
	private Vector2 velocity;

	public float moveSpeed;

	private Vector2 mousePosition;
	private Vector2 lookDirection;

	private Transform cam;
	public float camFollowSpeed;

	public Weapon[] weapons;
	public int currentWeapon = 0;


	// в идеале бы тут все переместить в разные скрипты

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
		cam = GameObject.FindGameObjectWithTag("MainCamera").transform;
	}
	
    void Update()
    {
        horizontal = Input.GetAxisRaw ("Horizontal");
		vertical = Input.GetAxisRaw ("Vertical");
		velocity = new Vector2(horizontal, vertical).normalized;


		mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		lookDirection = (mousePosition - (Vector2)transform.position).normalized;
		transform.up = lookDirection;

		if (Input.GetButtonDown("Fire1")) {
			weapons[currentWeapon].Shot();
		}

		SwitchWeapon(Input.GetAxis ("Mouse ScrollWheel"));
	}
	

	private void FixedUpdate () {
		cam.position = Vector2.Lerp (cam.position, transform.position, camFollowSpeed * Time.deltaTime);

		rb.MovePosition(rb.position + velocity * moveSpeed * Time.fixedDeltaTime);
	}

	private void SwitchWeapon (float _value) {

		if (_value > 0) {
			currentWeapon += 1;
		} else if (_value < 0) {
			currentWeapon -= 1;
		}

		if (currentWeapon < 0) currentWeapon = weapons.Length - 1;
		if (currentWeapon > weapons.Length - 1) currentWeapon = 0;

		for (int i = 0; i < weapons.Length; i++) {
			weapons[i].gameObject.SetActive (false);
		}
		weapons[currentWeapon].gameObject.SetActive (true);
	}


	public health hp;

	private void OnTriggerEnter2D (Collider2D collision) {

		if (collision.tag == "ENEMY") {
			hp.TakeDamage(25);
		}
		Debug.Log(hp._health);
	}
}
