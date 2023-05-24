using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int damage = 10;

    [Header("Animation")]
    public Animator animator;
    public string triggerAttack = "Attack";
    public string triggerKill = "Death";

    public float timeToDestroy = 1f;

    public HealthBase healthBase;

    public AudioSource deathSound;
    public AudioSource hitSound;


    private void Awake()
    {
        if (healthBase != null)
        {
            healthBase.OnKill += OnEnemyKill;
        }
    }

    private void OnEnemyKill()
    {

        healthBase.OnKill -= OnEnemyKill;
        PlayKillAnimation();
        Destroy(gameObject, timeToDestroy);
    }

//Enemy Attack - when player touch, loss life
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Debug.Log(collision.transform.name);

        var health = collision.gameObject.GetComponent<HealthBase>();

        if (health != null)
        {
            health.DamageOnPlayer(damage);
            PlayAttackAnimation();
        }

    }


    private void PlayAttackAnimation()
    {
        animator.SetTrigger(triggerAttack);
    }

    private void PlayKillAnimation()
    {
        animator.SetTrigger(triggerKill);
        if (deathSound != null) deathSound.Play();
    }


    public void Damage(int amount)
    {
        healthBase.DamageOnEnemy(amount);
        if(hitSound != null) hitSound.Play();
    }
}
