using UnityEngine;

public class EnemyJumper : MonoBehaviour
{
    public float jumpHeight = 2f; // Altura do salto
    public float jumpDistance = 3f; // Distância percorrida durante o salto
    public float jumpSpeed = 1f; // Velocidade do salto
    private float initialPositionX; // Posição inicial do inimigo
    private float startY; // Posição Y inicial do inimigo
    private bool isFacingRight = true; // Verifica se o inimigo está virado para a direita

    private void Start()
    {
        initialPositionX = transform.position.x;
        startY = transform.position.y;
    }

    private void Update()
    {
        float t = Mathf.PingPong(Time.time * jumpSpeed, jumpDistance) / jumpDistance;
        float x = Mathf.Lerp(-jumpDistance, jumpDistance, t);

        float y = jumpHeight * Mathf.Sin(Mathf.PI * t);

        Vector2 targetPosition = new Vector2(initialPositionX + x, startY + y);
        transform.position = targetPosition;

        if (x > 0 && !isFacingRight)
        {
            FlipSprite();
        }
        else if (x < 0 && isFacingRight)
        {
            FlipSprite();
        }
    }

    private void FlipSprite()
    {
        Vector3 scale = transform.localScale;
        scale.x = -scale.x;
        transform.localScale = scale;

        isFacingRight = !isFacingRight;
    }
}
