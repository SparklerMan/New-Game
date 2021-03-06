﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour 
{
	public float Speed;
	public GameObject ExplodeEffect;
	public float LifeTime;
	public LayerMask Whatissolid;
	public int damage;
	public float Distance;

    public CamShake Shake;

	void Start()
	{
		Invoke ("DestroyProjectile", LifeTime);

        Shake = GameObject.FindGameObjectWithTag("Scrn").GetComponent<CamShake>();
	}

	void Update () 
	{
		RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, Distance,Whatissolid);

		if (hitInfo.collider != null)
		{
			if(hitInfo.collider.CompareTag("Enemy"))
			{
			Debug.Log ("DAMAGE");
				hitInfo.collider.GetComponent<Enemy>().TakeDamage (damage);
			}
			DestroyProjectile ();
		}

		transform.Translate (Vector2.left * Speed * Time.deltaTime);
	}

	public void DestroyProjectile()
	{
        Destroy(gameObject);
        Effect();
    }

    public void Effect()
    {
        Instantiate(ExplodeEffect, transform.position, Quaternion.identity);

        Shake.ShakeCam();
    }

}
