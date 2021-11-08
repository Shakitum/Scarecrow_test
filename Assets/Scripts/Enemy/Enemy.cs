using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	[Header("Components")]
	[SerializeField]	private EnemyInterface enemyInterface;

	[Header("Stats")]
	[SerializeField]	private float		_maxHP;
	[SerializeField]	private float		_minHP;
						private float		_currentHP;

						public  float		maxHP		{ get { return _maxHP; } }
						public  float		minHP		{ get { return _minHP; } }
						public  float		currentHP { get { return _currentHP; } }



	[SerializeField]	private float		_maxWet;
	[SerializeField]	private float		_minWet;
						private float		_currentWet;

						public float		maxWet		{ get { return _maxWet; } }
						public float		minWet		{ get { return _minWet; } }
						public float		currentWet { get { return _currentWet; } }

	[SerializeField]	private float		multiplyWetBonus = 0.5f;

						private float		startTimeBurning = 0;

						private bool		burning;
						private bool		wet;


	[Header("Others")]
	[SerializeField]	private Material	enemyMaterial;
	[SerializeField]	private Color		normalColor;
	[SerializeField]	private Color		wetColor;
	[SerializeField]	private Color		fireColor;


	private void Start() {
		Initialize();
	}


	public void Initialize() {

		_currentHP	= _maxHP;
		_currentWet = _minWet;

		SetEnemyColor();
		gameObject.SetActive(true);
		enemyInterface.FillBars();
	}

	/// <summary>
	/// ������� ����
	/// </summary>
	/// <param name="damage">����</param>
	/// <param name="haveWetBonus">����� �� ������ ���� ����� �� ���� ������ ���� ��� �����</param>
	public void Hit (float damage, bool haveWetBonus) {

		float localDmg = damage;
		if (haveWetBonus) localDmg += GetWetBonus() * multiplyWetBonus * damage;
		
		// ��������� ���� ����� ����� �� ���� � ������������� ��������
		localDmg = Mathf.Clamp(localDmg, 0, float.PositiveInfinity);


		_currentHP = Mathf.Clamp(_currentHP - localDmg, _minHP, _maxHP);

		if (_currentHP == minHP) Death();

		enemyInterface.FillBars();
		SetEnemyColor();



	}


	public void SetWet(float value) {

		// �������� �������� �����
		_currentWet = Mathf.Clamp(_currentWet + value, _minWet, _maxWet);

		// ���� ���� ������� ������, �� ������� � ���������� ��������
		if (_currentWet > _minWet) {
			wet = true;

			if (burning) {
				StopAllCoroutines();
				burning = false;
			}

		} 

		// ���� �� ������, �� �������
		else wet = false;

		enemyInterface.FillBars();
		SetEnemyColor();
	}


	public void SetFire(float damage, float damagePerSecond, float durationBurning) {

		Hit(damage, false);

		// ���� ������, ������ �������, ����� ��������
		if (wet) SetWet(-damage);

		// ���� �����, ����� �������
		else {
			if (burning) StopAllCoroutines();
			StartCoroutine(Burning(damagePerSecond, durationBurning));
		}

		SetEnemyColor();
	}


	private float GetWetBonus() {
		if (burning) return 1;				  // ���� �����
		else if (wet) return -1;			  // ���� ������
		else return 0;						  // ���� �� ��, �� ������
	}


	private void SetEnemyColor() {
		if (burning)	enemyMaterial.color	= fireColor; 
		else if (wet)	enemyMaterial.color	= wetColor; 
		else			enemyMaterial.color	= normalColor; 
	}


	private void Death() {
		StopAllCoroutines();
		gameObject.SetActive(false);
	}

	private IEnumerator Burning(float damagePerSecond, float durationBurning) {

		startTimeBurning = Time.time;
		burning = true;

		while (startTimeBurning + durationBurning > Time.time) {

			Hit(damagePerSecond, false);
			yield return new WaitForSeconds(1);
		}

		burning = false;
		SetEnemyColor();
	}



}
