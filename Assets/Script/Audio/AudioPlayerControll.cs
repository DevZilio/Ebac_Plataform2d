using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayerControll : MonoBehaviour
{
    public AudioSource stepSound;
    public AudioSource jumpSound;

     public KeyCode keycode = KeyCode.Space;

    public void WalkSFX()
    {
        if(stepSound != null) stepSound.Play();
    }

    public void JumpSFX()
    {
        if(Input.GetKey(keycode))
        {
            if(jumpSound != null) jumpSound.Play();
        }
    }
}
