using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionLorey : MonoBehaviour
{
    private Animator animator;
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    //Arriba 0 Abajo 1 Derecha 2 Izquierda 3 Quieto 4
    void Update()
    {
        if (Input.anyKey)
        {
            
            if (Input.GetKey(KeyCode.W))
            {
                animator.SetInteger("Posicion", 0);
                
            }
            if (Input.GetKey(KeyCode.S))
            {
                animator.SetInteger("Posicion", 1);
                
            }
            if (Input.GetKey(KeyCode.A))
            {
                animator.SetInteger("Posicion", 3);
            }
            if (Input.GetKey(KeyCode.D))
            {
                animator.SetInteger("Posicion", 2);
                
            }
        }
        else
        {
            animator.SetInteger("Posicion", 4);
        }
        
    }
}
