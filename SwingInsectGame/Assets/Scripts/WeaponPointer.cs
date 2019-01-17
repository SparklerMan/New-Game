using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPointer : MonoBehaviour
{
    //Variables

    public float offset;
    public GameObject projectile;
    public Transform ShotPoint;
    private float timebtwshots;
    public float startTimeBtwShots;
    //Functions

    private void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
        if (timebtwshots <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(projectile, ShotPoint.position, transform.rotation);
                timebtwshots = startTimeBtwShots;
            }

        }
        else
        {
            timebtwshots -= Time.deltaTime;
        }
    }
}
