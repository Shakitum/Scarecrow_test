using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
	[SerializeField] private PlayerControll playerControll;

	[SerializeField] private Transform parentLeftHand;
	[SerializeField] private Transform parentRightHand;

	private IWeapon leftHandWeapon;
	private IWeapon rightHandWeapon;


	public enum Hand {
		Left,
		Right
	}

	// Проверяем есть ли оружие в руке
	public bool HaveItemInHand(Hand whichHand) {

		if (whichHand == Hand.Left) return (leftHandWeapon != null);
		else						return (rightHandWeapon != null);
	}

	// Взять оружие в руку
	public void TakeWeapon(Transform item, Hand whichHand) {

		if (item == null) return;

		if (whichHand == Hand.Left) {
			item.SetParent(parentLeftHand);
			leftHandWeapon = item.GetComponent<IWeapon>();
		}

		else{
			item.SetParent(parentRightHand);
			rightHandWeapon = item.GetComponent<IWeapon>();
		}

		item.gameObject.layer = LayerMask.NameToLayer("Player");

		item.localPosition = Vector3.zero;
		item.localEulerAngles = Vector3.zero;

	}

	// Бросить оружие из руки
	public void DropWeapon(Hand whichHand) {

		if (whichHand == Hand.Left && leftHandWeapon != null) {
			leftHandWeapon.GetMyTransform().gameObject.layer = LayerMask.NameToLayer("Default");
			leftHandWeapon.GetMyTransform().SetParent(null);
			leftHandWeapon = null;
		}

		if (whichHand == Hand.Right && rightHandWeapon != null) {
			rightHandWeapon.GetMyTransform().gameObject.layer = LayerMask.NameToLayer("Default");
			rightHandWeapon.GetMyTransform().SetParent(null);
			rightHandWeapon = null;
		}
	}

	// Использовать оружие 
	public void UseWeapon(Hand whichHand) {
		if (whichHand == Hand.Left  && leftHandWeapon != null)  leftHandWeapon.Use(playerControll);
		if (whichHand == Hand.Right && rightHandWeapon != null) rightHandWeapon.Use(playerControll);
	}	
}
