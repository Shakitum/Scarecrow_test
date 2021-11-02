using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCollision : MonoBehaviour
{
	[SerializeField] private float wetValue;

	private void OnCollisionEnter(Collision collision) {

		Enemy enemy = collision.transform.GetComponent<Enemy>();
		if (enemy != null) enemy.SetWet(wetValue);

		Destroy(gameObject);
	}

}
