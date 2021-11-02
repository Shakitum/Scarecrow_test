using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour, IWeapon {

	[SerializeField] private ParticleSystem particleSystem;
	[SerializeField] private Animation		animation;
	[SerializeField] private float			damage;


	public Transform GetMyTransform() {
		return transform;
	}

	public void Use(PlayerControll playerControll) {

		if (!IsReady()) return;

		RaycastHit raycastHit = playerControll.playerInteraction.GetPlayerRaycast();
		if (raycastHit.collider != null) {
			Enemy enemy = raycastHit.collider.GetComponent<Enemy>();
			if (enemy != null) enemy.Hit(damage, true);

		}

		animation.Play();
		particleSystem.Play();
	}

	private bool IsReady() {
		return !animation.isPlaying;
	}

}
