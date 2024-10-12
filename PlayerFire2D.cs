using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire2D : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float fireRate = 1f;
    private float nextFireTime = 0f;
    public float bulletSpeed = 5f;

    public Color[] turretColors = { Color.blue, Color.red, Color.green };
    private int currentColorIndex = 0;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            SwitchTurretColor();
        }

        if (Time.time >= nextFireTime)
        {
            FireBullet();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    void FireBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * bulletSpeed;
        bullet.GetComponent<SpriteRenderer>().color = turretColors[currentColorIndex]; 
    }

    void SwitchTurretColor()
    {
        currentColorIndex = (currentColorIndex + 1) % turretColors.Length;
        GetComponent<SpriteRenderer>().color = turretColors[currentColorIndex]; 
    }
}