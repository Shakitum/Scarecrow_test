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


			// ���� � ����� ���� ��� ���� ������, ������� ���
			if (playerControll.playerInventory.HaveItemInHand(PlayerInventory.Hand.Left)) {
				playerControll.playerInventory.DropWeapon(PlayerInventory.Hand.Left);
			}

			// ���� ������ ���, � �� ������ �� ������ � ��������� �� ���� ����������, ����� ���
			else if (rayInfo.collider != null && rayInfo.distance < interactionDistance && rayInfo.collider.GetComponent<IWeapon>() != null) {
				playerControll.playerInventory.TakeWeapon(rayInfo.collider.transform, PlayerInventory.Hand.Left);
			}
			
		}

		if (Input.GetKeyDown(KeyCode.E)) {

			// ���� � ������ ���� ��� ���� ������, ������� ���
			if (playerControll.playerInventory.HaveItemInHand(PlayerInventory.Hand.Right)) {
				playerControll.playerInventory.DropWeapon(PlayerInventory.Hand.Right);
			}

			// ���� ������ ���, � �� ������ �� ������ � ��������� �� ���� ����������, ����� ���
			else if (rayInfo.collider != null && rayInfo.distance < interactionDistance && rayInfo.collider.GetComponent<IWeapon>() != null) {
				playerControll.playerInventory.TakeWeapon(rayInfo.collider.transform, PlayerInventory.Hand.Right);
			}		
		}

		if (Input.GetMouseButtonDown(0)) {

			// ���� � ����� ���� ���� ������, ������������
			if (playerControll.playerInventory.HaveItemInHand(PlayerInventory.Hand.Left)) {
				playerControll.playerInventory.UseWeapon(PlayerInventory.Hand.Left);
			}
		}

		if (Input.GetMouseButtonDown(1)) {

			// ���� � ����� ���� ���� ������, ������������
			if (playerControll.playerInventory.HaveItemInHand(PlayerInventory.Hand.Right)) {
				playerControll.playerInventory.UseWeapon(PlayerInventory.Hand.Right);
			}
		}

	}


	public RaycastHit GetPlayerRaycast() {
		return rayInfo;
	}

}
