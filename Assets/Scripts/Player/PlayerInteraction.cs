using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
	[SerializeField]	private PlayerControll	playerControll;
	
	[SerializeField]	private float			interactionDistance = 2;
	[SerializeField]	private LayerMask		interactionMask;

						private RaycastHit		rayInfo;


	void Update() {

		Transform head = playerControll.GetHead();
		Ray ray = new Ray(head.position, head.forward);		
		

		Physics.Raycast(ray, out rayInfo, 500f, interactionMask);


		if (Input.GetKeyDown(KeyCode.Q)) {


			// ≈сли в левой руке уже есть оружие, бросить его
			if (playerControll.playerInventory.HaveItemInHand(PlayerInventory.Hand.Left)) {
				playerControll.playerInventory.DropWeapon(PlayerInventory.Hand.Left);
			}

			// ≈сли оружи€ нет, и мы навели на оружие и дистанци€ до него подход€ща€, вз€ть его
			else if (rayInfo.collider != null && rayInfo.distance < interactionDistance && rayInfo.collider.GetComponent<IWeapon>() != null) {
				playerControll.playerInventory.TakeWeapon(rayInfo.collider.transform, PlayerInventory.Hand.Left);
			}
			
		}

		if (Input.GetKeyDown(KeyCode.E)) {

			// ≈сли в правой руке уже есть оружие, бросить его
			if (playerControll.playerInventory.HaveItemInHand(PlayerInventory.Hand.Right)) {
				playerControll.playerInventory.DropWeapon(PlayerInventory.Hand.Right);
			}

			// ≈сли оружи€ нет, и мы навели на оружие и дистанци€ до него подход€ща€, вз€ть его
			else if (rayInfo.collider != null && rayInfo.distance < interactionDistance && rayInfo.collider.GetComponent<IWeapon>() != null) {
				playerControll.playerInventory.TakeWeapon(rayInfo.collider.transform, PlayerInventory.Hand.Right);
			}		
		}

		if (Input.GetMouseButtonDown(0)) {

			// ≈сли в левой руке есть оружие, использовать
			if (playerControll.playerInventory.HaveItemInHand(PlayerInventory.Hand.Left)) {
				playerControll.playerInventory.UseWeapon(PlayerInventory.Hand.Left);
			}
		}

		if (Input.GetMouseButtonDown(1)) {

			// ≈сли в левой руке есть оружие, использовать
			if (playerControll.playerInventory.HaveItemInHand(PlayerInventory.Hand.Right)) {
				playerControll.playerInventory.UseWeapon(PlayerInventory.Hand.Right);
			}
		}

	}


	public RaycastHit GetPlayerRaycast() {
		return rayInfo;
	}

}
