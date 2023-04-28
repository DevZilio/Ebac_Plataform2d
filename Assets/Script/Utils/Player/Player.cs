using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D myRigidbody;

    [Header("Player Setup")]
    public SOPlayerSetup sOPlayerSetup;

    private float _currentSpeed;

    public Animator animator;
    public HealthBase healthBase;

    private void Awake()
    {
        if (healthBase != null)
        {
            healthBase.OnKill += OnPlayerKill;
        }
    }

    private void OnPlayerKill()
    {
        healthBase.OnKill -= OnPlayerKill;

        animator.SetTrigger(sOPlayerSetup.triggerDeath);
    }

    private void Update()
    {
        checkIfPlayerIsFalling();
        HandleJump();
        HandleMovement();
    }

    private void HandleMovement()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _currentSpeed = sOPlayerSetup.speedRun;
            animator.speed = 1.5f;
        }
        else
        {
            _currentSpeed = sOPlayerSetup.speed;
            animator.speed = 1f;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            myRigidbody.velocity = new Vector2(-_currentSpeed, myRigidbody.velocity.y);

            if (myRigidbody.transform.localScale.x != -1)
            {
                myRigidbody.transform.DOScaleX(-1, sOPlayerSetup.playerSwipeDuration).SetEase(sOPlayerSetup.ease);
            }
            animator.SetBool(sOPlayerSetup.boolRun, true);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            myRigidbody.velocity = new Vector2(_currentSpeed, myRigidbody.velocity.y);

            if (myRigidbody.transform.localScale.x != 1)
            {
                myRigidbody.transform.DOScaleX(1, sOPlayerSetup.playerSwipeDuration).SetEase(sOPlayerSetup.ease);
            }
            animator.SetBool(sOPlayerSetup.boolRun, true);
        }
        else
        {
            animator.SetBool(sOPlayerSetup.boolRun, false);
        }

        if (myRigidbody.velocity.x > 0)
        {
            myRigidbody.velocity += sOPlayerSetup.friction;
        }
        else if (myRigidbody.velocity.x < 0)
        {
            myRigidbody.velocity -= sOPlayerSetup.friction;
        }
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && sOPlayerSetup._jumpCount < 2)
        {
            myRigidbody.velocity = Vector2.up * sOPlayerSetup.forceJump;
            sOPlayerSetup._jumpCount++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(sOPlayerSetup.ground))
        {
            sOPlayerSetup._jumpCount = 0;
        }
    }

    private void checkIfPlayerIsFalling()
    {
        if (myRigidbody.velocity.y < sOPlayerSetup.fallingThreshold)
        {
            sOPlayerSetup.falling = true;
            animator.SetBool(sOPlayerSetup.boolJump, false);
        }
        else if (myRigidbody.velocity.y > sOPlayerSetup.fallingThreshold)
        {
            sOPlayerSetup.falling = false;
            animator.SetBool(sOPlayerSetup.boolJump, true);
        }
    }

    public void DestroyMe()
    {
        Destroy(gameObject);
        
    }
}
