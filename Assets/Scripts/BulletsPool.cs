using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsPool : MonoBehaviour
{

	public static BulletsPool instance;


	public GameObject BulletPrefab;

	public int SpawnAmount = 30;

	private List<GameObject> poolObjects = new List<GameObject> ();
	private List<Rigidbody2D> objectsRB = new List<Rigidbody2D> ();

	public float bulletSpeed = 25;

	private void Start () {

		instance = this;

		for (int i = 0; i < SpawnAmount; i++) {
			SpawnObjets ();
		}
	}

	private void SpawnObjets () {
		GameObject go = Instantiate (BulletPrefab, transform);
		go.SetActive (false);
		poolObjects.Add (go);
		objectsRB.Add(go.GetComponent<Rigidbody2D>());
	}

	public GameObject CreatePoolBullets (Transform target) {
		for (int i = 0; i < poolObjects.Count; i++) {

			if (!poolObjects[i].activeInHierarchy) {

				poolObjects[i].transform.position = target.position;
				poolObjects[i].SetActive (true);
				poolObjects[i].transform.parent = null;
				objectsRB[i].AddForce(target.up * bulletSpeed, ForceMode2D.Impulse);

				StartCoroutine(DisableBullet(poolObjects[i]));
				return poolObjects[i];
			}
		}

		// Тут можно спавнить еще объекты если не хватило но т.к времени мало я этого реализовывать не буду.
		return null;
	}



	IEnumerator DisableBullet (GameObject bullet) {
		yield return new WaitForSeconds(1);
		bullet.SetActive(false);
	}
}
