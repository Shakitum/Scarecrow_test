using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyInterface : MonoBehaviour
{
	[SerializeField] private Enemy enemy;

	[SerializeField] private Image hpBar;
	[SerializeField] private Image wetBar;

	[SerializeField] private Text hpText;
	[SerializeField] private Text wetText;

	[SerializeField] private Gradient hpGradient;




	

	public void FillBars() {

		hpBar.fillAmount = CalculateValueForAmount(enemy.minHP, enemy.maxHP, enemy.currentHP);
		wetBar.fillAmount = CalculateValueForAmount(enemy.minWet, enemy.maxWet, enemy.currentWet);

		hpBar.color = hpGradient.Evaluate(CalculateValueForAmount(enemy.minHP, enemy.maxHP, enemy.currentHP));

		hpText.text = enemy.currentHP + "/" + enemy.maxHP;
		wetText.text = enemy.currentWet + "/" + enemy.maxWet;

	}


	private float CalculateValueForAmount(float minVal, float maxVal, float currentVal) {
		
		// Приводим к виду от 0 - max
		float localMax = maxVal - minVal;
		float localCurrent = currentVal - minVal;

		return (localCurrent * 1) / localMax;
	}


}
