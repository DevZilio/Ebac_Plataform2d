using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorTest : MonoBehaviour
{
    public Animator animator;

    public string triggerToPlay = "Fly";
    public KeyCode keyToTrigger = KeyCode.A;
    public KeyCode keyToExit = KeyCode.S;


    //Ao incluir o script ao objeto, automaticamente seleciona o animator a classe
    private void OnValidate()
    {
        if (animator == null) animator = GetComponent<Animator>();
    }


    // Get Trigger
    /* if (Input.GetKeyDown(keyToTrigger))
        {
            animator.SetTrigger(triggerToPlay);
        }
    }*/

    // Get Bool

    void Update()
    {
        /*if (Input.GetKeyDown(keyToTrigger))
        {
            animator.SetBool(triggerToPlay, true);
        }
        else if (Input.GetKeyDown(keyToExit))
        {
            animator.SetBool(triggerToPlay, false);

        }*/

        //ou
        if (Input.GetKeyDown(keyToTrigger))
        {
            animator.SetBool(triggerToPlay, !animator.GetBool(triggerToPlay));
        }

    }
}
