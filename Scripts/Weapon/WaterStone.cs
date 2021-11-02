using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterStone : MonoBehaviour, IWeapon {

	[SerializeField] private GameObject waterSpherePrefab;
	[SerializeField] private float force = 2;

	public Transform GetMyTransform() {
		return transform;
	}

	public void Use(PlayerControll playerControll) {

		Vector3 dir = playerControll.GetHead().forward;

		GameObject newSpehere = Instantiate(waterSpherePrefab);
		newSpehere.transform.position = transform.position + (newSpehere.transform.forward * 0.1f);
		newSpehere.transform.rotation = transform.rotation;

		newSpehere.GetComponent<Rigidbody>().AddForce(dir * force);
	}
}
