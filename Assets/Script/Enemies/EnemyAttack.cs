using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public EnemyProjectileBase prefabProjectile;

    public Transform positionToShoot;
    public float timeBetweenShoot = 2.5f;
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
            yield return new WaitForSeconds(timeBetweenShoot);
            Shoot();
        }
    }

    public void Shoot()
    {
        var projectile = Instantiate(prefabProjectile);
        projectile.transform.position = positionToShoot.position;
        projectile.side = enemySideReference.transform.localScale.x;
        if(audioSource != null) audioSource.Play();
    }

        // Atualiza o movimento do objeto
  
}
