using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[CreateAssetMenu]

public class SOPlayerSetup : ScriptableObject
{
   [Header("Moviment Setup")]
    public Vector2 friction = new Vector2(.1f, 0);
    public float speed;
    public float speedRun;
    public float forceJump;
    public int _jumpCount;

    [Header("Animation Player")]
    public string boolRun = "Run";
    public string boolJump = "Jump";
    public string triggerDeath = "Death";
    public float animationDuration = 0.3f;
    public float playerSwipeDuration = .1f;
    public bool falling;
    public float fallingThreshold;
    public Ease ease = Ease.OutBack;

    public string ground = "Ground";
}
