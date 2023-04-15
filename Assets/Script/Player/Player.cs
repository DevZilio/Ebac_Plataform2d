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

    public bool falling;
    public float fallingThreshold;

    public float animationDuration = 0.3f;
    public Ease ease = Ease.OutBack;

    private float _currentSpeed;

    private void Update()
    {
        checkIfPlayerIsFalling();
        HandleJump();
        HandleMoviment();
        
    }


    private void HandleMoviment()
    {
        if (Input.GetKey(KeyCode.C))
            _currentSpeed = speedRun;
        else
            _currentSpeed = speed;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // myRigidbody.MovePosition(myRigidbody.position - velocity * Time.deltaTime);
            myRigidbody.velocity = new Vector2(-_currentSpeed, myRigidbody.velocity.y);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {

            // myR  igidbody.MovePosition(myRigidbody.position + velocity * Time.deltaTime);
            myRigidbody.velocity = new Vector2(_currentSpeed, myRigidbody.velocity.y);
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
            myRigidbody.transform.localScale = Vector2.one; //Reseta a escala

            DOTween.Kill(myRigidbody.transform); //Mata qualquer animacao que estiver em acao antes de comecar outra

            HandleScaleJump();
        }


    }

    public void HandleScaleJump()
    {
        myRigidbody.transform.DOScaleY(jumpScaleY, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
        myRigidbody.transform.DOScaleX(jumpScaleX, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
    }





/*private void OnCollisionEnter(Collision collision) {
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

private void checkIfPlayerIsFalling(){
    if(myRigidbody.velocity.y < fallingThreshold)
    {
        falling = true;
    }
    else
    {
        falling = false;
    }
}
















}
