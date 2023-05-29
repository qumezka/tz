using UnityEngine;

public class Weapon : MonoBehaviour
{

	public Transform[] shotPositions;


	public void Shot () {

		for (int i = 0; i < shotPositions.Length; i++) {

			BulletsPool.instance.CreatePoolBullets (shotPositions[i]);

		}
	}

}
