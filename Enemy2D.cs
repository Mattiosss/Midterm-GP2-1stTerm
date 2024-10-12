using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2D : MonoBehaviour
{
    public float moveSpeed = 2f;
    public Color[] enemyColors = { Color.blue, Color.red, Color.green };
    private Color enemyColor;
    private Transform target;

    void Start()
    {
        int randomColorIndex = Random.Range(0, enemyColors.Length);
        enemyColor = enemyColors[randomColorIndex];
        GetComponent<SpriteRenderer>().color = enemyColor; 

        target = GameObject.FindWithTag("Turret").transform; 
    }

    void Update()
    {
        MoveTowardsTarget();
    }

    void MoveTowardsTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            if (collision.GetComponent<SpriteRenderer>().color == enemyColor)
            {
                Destroy(gameObject); 
            }
            Destroy(collision.gameObject); 
        }
        else if (collision.CompareTag("Turret"))
        {
            GameManager2D.instance.GameOver(); 
        }
    }
}
