using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInterface : MonoBehaviour
{
	[SerializeField] private PlayerControll playerControll;

	private void Start() {
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}

}
