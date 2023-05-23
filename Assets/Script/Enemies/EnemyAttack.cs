using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public ProjectileBase prefabProjectile;

    public Transform positionToShoot;
    public float timeBetweenShoot = .3f;
    public Transform enemySideReference;

    public AudioSource audioSource;

    private Coroutine _currentCoroutine;

    void Start()
    {
       _currentCoroutine = StartCoroutine(StartShoot());
    }


    //Coroutine
    IEnumerator StartShoot()
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(timeBetweenShoot);
        }
    }

    public void Shoot()
    {
        var projectile = Instantiate(prefabProjectile);
        projectile.transform.position = positionToShoot.position;
        projectile.side = -enemySideReference.transform.localScale.x;
        if(audioSource != null) audioSource.Play();
    }
}
