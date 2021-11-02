using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{

	[Header("Components")]
	[SerializeField]	private CharacterController	controller;
	[SerializeField]	private Transform			head;
	[SerializeField]	private PlayerInteraction	_playerInteraction;
	[SerializeField]	private PlayerInterface		_playerInterface;
	[SerializeField]	private PlayerInventory		_playerInventory;

						public PlayerInteraction	playerInteraction	{ get{ return _playerInteraction; } }
						public PlayerInterface		playerInterface		{ get{ return _playerInterface; } }
						public PlayerInventory		playerInventory		{ get{ return _playerInventory; } }



	[Header("Stats")]
	[SerializeField]	private float				speed		= 3;
	[SerializeField]	private float				sensetivity	= 3;
	[SerializeField]	private float				topAngleY	= 70;          // Максимальный угол поворота головы вверх
	[SerializeField]	private float				botAngleY	= -70;			// Максимальный угол поворота головы вниз
	[SerializeField]	private float				gravity		= -10;


						private float				ver;
						private float				hor;
						private float				mouseX;
						private float				mouseY;

						private Vector3				targetRotation = Vector3.zero;


	private void Update() {

		ver = 0;
		hor = 0;

		// Input движения
		if (Input.GetKey(KeyCode.W)) ver += 1;
		if (Input.GetKey(KeyCode.S)) ver -= 1;
		if (Input.GetKey(KeyCode.D)) hor += 1;
		if (Input.GetKey(KeyCode.A)) hor -= 1;

		// Input поворота
		mouseX = Input.GetAxis("Mouse X");
		mouseY = Input.GetAxis("Mouse Y");

		// Поворот
		Rotate();

		// Перемещение
		Move();
	}


	private void Rotate() {
		// Ограничиваем поворот и учитываем сенсу
		targetRotation = new Vector3(Mathf.Clamp(targetRotation.x + (mouseY * sensetivity * -1), botAngleY, topAngleY), targetRotation.y + (mouseX * sensetivity), 0);


		transform.eulerAngles = new Vector3(0, targetRotation.y, 0);
		head.localEulerAngles = new Vector3(targetRotation.x, 0, 0);

	}


	private void Move() {
		Vector3 movementDirection = new Vector3(hor * speed, 0, ver * speed);
		Vector3 moveFactor = transform.TransformDirection(movementDirection + new Vector3(0, gravity, 0)) * Time.deltaTime;

		controller.Move(moveFactor);
	}

	public Transform GetHead() {
		return head;
	}
}
