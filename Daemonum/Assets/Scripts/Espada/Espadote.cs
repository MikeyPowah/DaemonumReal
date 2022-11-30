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
    [SerializeField] private GameObject player;
    public StatsPlayer statsPlayer;
    [SerializeField] private Transform target;
    [SerializeField] private bool Attacking = false;
    [SerializeField] private GameObject Lorey;
    private Vector3 vectorAtaque;
    public float timeBucle = 0.35f;
    private int Mjonlir;

    void Start()
    {
        animatorLorey = Lorey.GetComponent<Animator>();
        animator = GetComponent<Animator>();
        statsPlayer = player.GetComponent<StatsPlayer>();
    }

    private void Update()
    {
        if(!Attacking)
        {
            Seguir();
        }
        else
        {
            Atacar();
        }
            
        if (Input.GetKey(KeyCode.UpArrow) && !Attacking)
        {
            animator.SetBool("Ataque", true); Attacking = true;
            Mjonlir = 0;
            vectorAtaque = new Vector3(transform.position.x, transform.position.y, transform.position.z + 2);
        }
        if (Input.GetKey(KeyCode.DownArrow) && !Attacking)
        {
            animator.SetBool("Ataque", true); Attacking = true;
            Mjonlir = 1;
            vectorAtaque = new Vector3(transform.position.x, transform.position.y, transform.position.z - 2);  
        }
        if (Input.GetKey(KeyCode.LeftArrow) && !Attacking)
        {
            animator.SetBool("Ataque", true); Attacking = true;
            Mjonlir = 3;
            vectorAtaque = new Vector3(transform.position.x - 2, transform.position.y, transform.position.z);
        }
        if (Input.GetKey(KeyCode.RightArrow) && !Attacking)
        {
            animator.SetBool("Ataque", true); Attacking = true;
            Mjonlir = 2;
            vectorAtaque = new Vector3(transform.position.x + 2, transform.position.y, transform.position.z);
        }
    
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            AudioManager.instance.EspadaSFX();
        }
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            AudioManager.instance.EspadaSFX();
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            AudioManager.instance.EspadaSFX();
        }
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            AudioManager.instance.EspadaSFX();
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
                    Attacking = false;
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
                    Attacking = false;
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
                    Attacking = false;
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
                    Attacking = false;
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
                    Attacking = false;
                }
                break;
        }

        /*[SerializeField]
        private float DamageAfterTime;

        [SerializeField]
        private float StrongDamageAfterTime;
        */

        //StartCoroutine("Hit", Elemental);
    }

    /*private IEnumerator Hit(bool strong)
    {
        yield return new WaitForSeconds(1);
        Debug.Log(_attackArea.Damagables.Count);
        foreach(var attackingAreaDamageable in _attackArea.Damagables)
        {
            attackingAreaDamageable.Damage(Damage * (strong ? 2 : 1));
        }
    }*/

}