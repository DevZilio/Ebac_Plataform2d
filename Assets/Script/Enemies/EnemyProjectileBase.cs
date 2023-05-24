using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileBase: MonoBehaviour
{

    public Vector3 direction;

    public float timeToDestroy = 2f;

    public float side = 1;
    public int damageAmount = 1;
    public float movementSpeed = 1f;

    private void Awake()
    {
        Destroy(gameObject, timeToDestroy);
    }

    private void Update()
    {
        transform.Translate(Vector2.left * movementSpeed * Time.deltaTime);//Cria gameobject   
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        var player = collision.transform.GetComponent<HealthBase>();

        if (player != null)
        {
            player.DamageOnPlayer(damageAmount);
            Destroy(gameObject);
        }

    }
}
