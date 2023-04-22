using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D myRigidbody;

    [Header("Speed Setup")]
    public Vector2 friction = new Vector2(.1f, 0);
    public float speed;
    public float speedRun;
    public float forceJump;

    [Header("Animation Setup")]
    public float jumpScaleY = 1.5f;
    public float jumpScaleX = 0.7f;
    public float landingScaleY = 0.7f;
    public float landingScaleX = 1.5f;

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

    public HealthBase healthBase;


    private void Awake() {
        if(healthBase != null)
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
        HandleMoviment();

    }


    private void HandleMoviment()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _currentSpeed = speedRun;
            animator.speed = 1.5f;
        }
        else
        {
            _currentSpeed = speed;
            animator.speed = 1;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // myRigidbody.MovePosition(myRigidbody.position - velocity * Time.deltaTime);
            myRigidbody.velocity = new Vector2(-_currentSpeed, myRigidbody.velocity.y);
            if (myRigidbody.transform.localScale.x != -1)
            {
                myRigidbody.transform.DOScaleX(-1, playerSwipeDuration);
            }
            animator.SetBool(boolRun, true);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {

            // myR  igidbody.MovePosition(myRigidbody.position + velocity * Time.deltaTime);
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myRigidbody.velocity = Vector2.up * forceJump;
            
            // myRigidbody.transform.localScale = Vector2.one; //Reseta a escala

            // DOTween.Kill(myRigidbody.transform); //Mata qualquer animacao que estiver em acao antes de comecar outra

            // HandleScaleJump();
        }


    }

    public void HandleScaleJump()
    {
        // myRigidbody.transform.DOScaleY(jumpScaleY, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
        // myRigidbody.transform.DOScaleX(jumpScaleX, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
    }





    /*private void OnCollisionEnter(Collision collision) {

        var ground = collision.GetComponent<myRigybody>();

        if(collision.gameObject.CompareTag("Ground") && falling)
        {
            handleScaleLanding();
        }
    }

    private void handleScaleLanding()
    {
        
            myRigidbody.transform.DOScaleY(landingScaleY, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
            myRigidbody.transform.DOScaleX(landingScaleX, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);


    }*/

    private void checkIfPlayerIsFalling()
    {
        if (myRigidbody.velocity.y < fallingThreshold)
        {
            falling = true;
            animator.SetBool(boolJump, false);
            // Debug.Log("F TRUE");
        }
        else if (myRigidbody.velocity.y > fallingThreshold)
        {
            falling = false;
            animator.SetBool(boolJump, true);
            // Debug.Log("F FALSE");
        }
    }

public void DestroyMe()
{
    Destroy(gameObject);
}

















}
