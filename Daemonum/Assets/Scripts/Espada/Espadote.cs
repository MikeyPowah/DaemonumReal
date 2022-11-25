using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espadote : MonoBehaviour {
    private Animator animator;
    private Animator animatorLorey;
    //Arriba 0 Abajo 1 Derecha 2 Izquierda 3 Quieto 4
    public GameObject espada;
    private Vector3 offset = new Vector3(0f, 0f, 0f);
    private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private Transform target;
    [SerializeField] private bool timerIsRunning = false;
    [SerializeField] private GameObject Lorey;
    private Vector3 vectorAtaque;
    public float timeBucle = 0.35f;
    private int Mjonlir;
    void Start()
    {
        animatorLorey = Lorey.GetComponent<Animator>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(!timerIsRunning)
        {
            Seguir();
        }
        else
        {
            Atacar();
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && !timerIsRunning)
        {
            Mjonlir = animatorLorey.GetInteger("Posicion");
            animator.SetBool("Ataque", true); timerIsRunning = true;
            switch (Mjonlir)
            {
                case 0:
                    vectorAtaque = new Vector3(transform.position.x, transform.position.y, transform.position.z + 7);
                    break;
                case 1:
                    vectorAtaque = new Vector3(transform.position.x, transform.position.y, transform.position.z - 7);
                    break;
                case 2:
                    vectorAtaque = new Vector3(transform.position.x + 7, transform.position.y, transform.position.z);
                    break;
                case 3:
                    vectorAtaque = new Vector3(transform.position.x - 7, transform.position.y, transform.position.z);
                    break;
                default:
                    vectorAtaque = new Vector3(transform.position.x, transform.position.y, transform.position.z - 3);
                    break;
            }
        }
        else
        {
            if (timeBucle > 0)
            {
                timeBucle -= Time.deltaTime;
            }
            else
            {
                //timeBucle = 0.35f;
                //animator.SetBool("Ataque", false);
            }
        }
    }

    private void Seguir()
    {
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }

    private void Atacar()
    {
        switch (Mjonlir)
        {
            case 0:
                if(vectorAtaque.z >= transform.position.z)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.02f); 
                }
                else
                {
                    animator.SetBool("Ataque", false);
                    timerIsRunning = false;
                }
                break;      
            case 1:
                if(vectorAtaque.z < transform.position.z)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.02f); 
                }
                else
                {
                    animator.SetBool("Ataque", false);
                    timerIsRunning = false;
                }
                break;
            case 2:
                if(vectorAtaque.x >= transform.position.x)
                {
                    transform.position = new Vector3(transform.position.x + 0.02f, transform.position.y, transform.position.z); 
                }
                else
                {
                    animator.SetBool("Ataque", false);
                    timerIsRunning = false;
                }
                break;
            case 3:
                if(vectorAtaque.x < transform.position.x)
                {
                    transform.position = new Vector3(transform.position.x - 0.02f, transform.position.y, transform.position.z); 
                }
                else
                {
                    animator.SetBool("Ataque", false);
                    timerIsRunning = false;
                }
                break;
            default:
                if(vectorAtaque.z < transform.position.z)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.02f); 
                }
                else
                {
                    animator.SetBool("Ataque", false);
                    timerIsRunning = false;
                }
                break;
        }
    }
}