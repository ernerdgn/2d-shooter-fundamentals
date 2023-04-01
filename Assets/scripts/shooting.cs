using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float fireRate;
    private float timer;

    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            timer += Time.deltaTime;
            if (timer >= 1/fireRate)
            {
                Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                timer = 0;
            }
        }
    }
}
