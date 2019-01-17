using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour 
{
	//Variables

	public int health;
	public GameObject EnemyDeathEffect;

	//Functions

	public void TakeDamage(int damage)
	{
		health -= damage;
	}

	void Update () 
	{
		if (health <= 0)
		{
			Instantiate (EnemyDeathEffect, transform.position, Quaternion.identity);
			Destroy (gameObject);
		}
	}
}
