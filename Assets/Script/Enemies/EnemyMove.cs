using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    
    public float speed = 2f; // Velocidade de movimento do inimigo
    public float distance = 5f; // Distância total que o inimigo irá percorrer
    private float initialPositionX; // Posição inicial do inimigo

    private int direction = 1; // 1 para direita, -1 para esquerda
    private bool isFacingRight = true; // Verifica se o inimigo está virado para a direita

    private void Start()
    {
        initialPositionX = transform.position.x;
    }

    private void Update()
    {
        // Move o inimigo
        transform.Translate(Vector2.right * direction * speed * Time.deltaTime);

        // Verifica se atingiu a distância máxima
        if (Mathf.Abs(transform.position.x - initialPositionX) >= distance)
        {
            // Inverte a direção
            direction *= -1;
            FlipSprite();
        }
    }

    private void FlipSprite()
    {
        // Inverte a escala em X para inverter o sprite horizontalmente
        Vector3 scale = transform.localScale;
        scale.x = Mathf.Abs(scale.x) * (isFacingRight ? 1 : -1);
        transform.localScale = scale;

        // Atualiza o estado de direção do sprite
        isFacingRight = !isFacingRight;
    }
}