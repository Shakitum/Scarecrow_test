using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
	
	[SerializeField] private Enemy enemy;

    private void Update() {
		if (Input.GetKey(KeyCode.R)) enemy.Initialize();
	}
}
