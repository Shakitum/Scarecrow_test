using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireStone : MonoBehaviour, IWeapon {

	[SerializeField] private ParticleSystem particleSystem;

	public Transform GetMyTransform() {
		return transform;
	}

	public void Use(PlayerControll playerControll) {
		particleSystem.Play();
	}
}
