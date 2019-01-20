using System.Collections;
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

    //Sound and Camera shake

    public AudioClip SoundClip;
    public AudioSource SoundSource;

	void Start()
	{
		Invoke ("DestroyProjectile", LifeTime);
        SoundSource.clip = SoundClip;
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
        SoundSource.Play();
        Instantiate (ExplodeEffect,transform.position,Quaternion.identity);
        Destroy(gameObject);
    }

}
