using UnityEngine;

public class health : MonoBehaviour
{
	public float _health = 100;

	public void TakeDamage (float _dmg) {
		_health -= _dmg;
	}
}
