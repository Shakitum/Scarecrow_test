using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IWeapon {

	void Use (PlayerControll myPlayer);

	Transform GetMyTransform();
}
