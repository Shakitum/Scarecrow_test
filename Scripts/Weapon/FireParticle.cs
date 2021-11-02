using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireParticle : MonoBehaviour
{
	[SerializeField] private float damage;
	[SerializeField] private float damagePerSecond;
	[SerializeField] private float duration;


	void OnParticleCollision(GameObject other) {
		
		Enemy enemy = other.GetComponent<Enemy>();
		if (enemy != null) enemy.SetFire(damage, damagePerSecond, duration);

	}
}
