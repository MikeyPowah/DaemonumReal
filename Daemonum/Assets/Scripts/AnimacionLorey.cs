using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionLorey : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                animator.SetInteger("Posicion", 5);
            }
            if (Input.GetKey(KeyCode.W))
            {
                animator.SetInteger("Posicion", 1);
                animator.SetBool("Ataque", false);
            }
            if (Input.GetKey(KeyCode.S))
            {
                animator.SetInteger("Posicion", 0);
                animator.SetBool("Ataque", false);
            }
            if (Input.GetKey(KeyCode.A))
            {
                if(Input.GetKeyDown(KeyCode.Space)){animator.SetInteger("Posicion", 5);}
                else animator.SetInteger("Posicion", 2);
            }
            if (Input.GetKey(KeyCode.D))
            {
                animator.SetInteger("Posicion", 3);
                animator.SetBool("Ataque", false);
            }
        }
        else
        {
            animator.SetInteger("Posicion", 4);
        }
        
    }
}
