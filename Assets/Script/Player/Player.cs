using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D myRigidbody;

    [Header("Moviment Setup")]
    public Vector2 friction = new Vector2(.1f, 0);
    public SOFloat soSpeed;
    public SOFloat soSpeedRun;
    public SOFloat soForceJump;
    public int _jumpCount;

    [Header("Animation Player")]
    public string boolRun = "Run";
    public string boolJump = "Jump";
    public string triggerDeath = "Death";
    public Animator animator;
    public float playerSwipeDuration = .1f;

    public bool falling;
    public float fallingThreshold;

    public float animationDuration = 0.3f;
    public Ease ease = Ease.OutBack;

    private float _currentSpeed;
    public string ground = "Ground";

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

        animator.SetTrigger(triggerDeath);
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
            _currentSpeed = soSpeedRun.value;
          animator.speed = 1.5f;
        }
        else
        {
            _currentSpeed = soSpeed.value;
            animator.speed = 1f;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            myRigidbody.velocity = new Vector2(-_currentSpeed, myRigidbody.velocity.y);

            if (myRigidbody.transform.localScale.x != -1)
            {
                myRigidbody.transform.DOScaleX(-1, playerSwipeDuration);
            }
            animator.SetBool(boolRun, true);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            myRigidbody.velocity = new Vector2(_currentSpeed, myRigidbody.velocity.y);

            if (myRigidbody.transform.localScale.x != 1)
            {
                myRigidbody.transform.DOScaleX(1, playerSwipeDuration);
            }
            animator.SetBool(boolRun, true);
        }
        else
        {
            animator.SetBool(boolRun, false);
        }

        if (myRigidbody.velocity.x > 0)
        {
            myRigidbody.velocity += friction;
        }
        else if (myRigidbody.velocity.x < 0)
        {
            myRigidbody.velocity -= friction;
        }
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _jumpCount < 2)
        {
            myRigidbody.velocity = Vector2.up * soForceJump.value;
            _jumpCount++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(ground))
        {
            _jumpCount = 0;
        }
    }

    private void checkIfPlayerIsFalling()
    {
        if (myRigidbody.velocity.y < fallingThreshold)
        {
            falling = true;
            animator.SetBool(boolJump, false);
        }
        else if (myRigidbody.velocity.y > fallingThreshold)
        {
            falling = false;
            animator.SetBool(boolJump, true);
        }
    }

    public void DestroyMe()
    {
        Destroy(gameObject);
    }
}
