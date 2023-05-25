using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Player : MonoBehaviour
{
     // Variáveis públicas para acessar outros componentes
    public Rigidbody2D myRigidbody; // Rigidbody2D do jogador
    public ParticleSystem jumpVFX; // Sistema de partículas para o efeito de pulo
    public ParticleSystem walkVFX; // Sistema de partículas para o efeito de caminhada
    public Animator animator; // Animator do jogador
    public HealthBase healthBase; // Componente HealthBase que gerencia a saúde do jogador

    // Variáveis privadas que controlam o estado do jogador
    private bool isGrounded = true; // Indica se o jogador está no chão
    private float _currentSpeed; // Velocidade atual do jogador

    // Referência a um ScriptableObject que contém configurações do jogador
    [Header("Player Setup")]
    public SOPlayerSetup sOPlayerSetup;

// Adiciona um evento de morte para a função OnPlayerKill
    private void Awake()
    {
        if (healthBase != null)
        {
            healthBase.OnKill += OnPlayerKill;
        }
    }

    private void Start()
    {
        ItemManager.Instance.OnAddHearts += OnAddHearts;
    }

    private void OnAddHearts(int value)
    {
        healthBase.SetCurrentLife(value);
    }

 // Função que é chamada quando o jogador morre
    private void OnPlayerKill()
    {
         // Remove o evento de morte da função OnPlayerKill
        healthBase.OnKill -= OnPlayerKill;
        // Ativa a animação de morte
        animator.SetTrigger(sOPlayerSetup.triggerDeath);

          StartCoroutine(EndGameCoroutine());
    }

    private IEnumerator EndGameCoroutine()
    {
        yield return new WaitForSeconds(sOPlayerSetup.deathAnimationDuration);

        EndGame endGame = FindObjectOfType<EndGame>();
        if (endGame != null)
        {
            endGame.CallEndGame();
        }
    }

  // Função que é chamada a cada frame
    private void Update()
    {
        // Verifica se o jogador está caindo
        checkIfPlayerIsFalling();

        // Lida com o pulo do jogador
        HandleJump();

        // Lida com o movimento do jogador
        HandleMovement();
    }

    private void HandleMovement()
    {
        if (isGrounded)
        {
            PlayWalkVFX();
        }
        
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
            PlayWalkVFX();
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            myRigidbody.velocity = new Vector2(_currentSpeed, myRigidbody.velocity.y);

            if (myRigidbody.transform.localScale.x != 1)
            {
                myRigidbody.transform.DOScaleX(1, sOPlayerSetup.playerSwipeDuration).SetEase(sOPlayerSetup.ease);
            }
            animator.SetBool(sOPlayerSetup.boolRun, true);
            PlayWalkVFX();
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

              if (walkVFX != null)
            {
                walkVFX.Stop();
            }
            PlayJumpVFX();
        }
        
    }


private void PlayJumpVFX()
{
    if (jumpVFX != null && sOPlayerSetup._jumpCount <=1) jumpVFX.Play();
}

private void PlayWalkVFX()
{
     if (walkVFX != null && sOPlayerSetup._jumpCount == 0) 
    {
        if(!walkVFX.isPlaying)
        {
            walkVFX.Play();
        }
    }
    else if (walkVFX != null && sOPlayerSetup._jumpCount > 0)
    {
        walkVFX.Stop();
    }
}



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(sOPlayerSetup.ground))
        {
            isGrounded = true;
            sOPlayerSetup._jumpCount = 0;
            if(walkVFX != null)
            {
                walkVFX.Play();
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(sOPlayerSetup.ground))
        {
            // o personagem saiu do chão, então desativa a verificação para ativar o particle system walkVFX
            isGrounded = false;
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
