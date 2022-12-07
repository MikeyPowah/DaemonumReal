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
    [SerializeField] private GameObject fuego;
    public Fuego Fuego;
    [SerializeField] private int speedAtaque = 5;
    private Vector3 vectorAtaque;
    public float timeBucle = 0.35f;
    private int Mjonlir;

    void Start()
    {
        animatorLorey = Lorey.GetComponent<Animator>();
        animator = GetComponent<Animator>();
        statsPlayer = player.GetComponent<StatsPlayer>();
        speedAtaque = 10;
        Fuego = fuego.GetComponent<Fuego>();
    }

    private void Update()
    {
        
        vectorAtaque = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.UpArrow) && !Attacking)
        {
            animator.SetBool("Ataque", true); Attacking = true;
            vectorAtaque = new Vector3(vectorAtaque.x, 0, vectorAtaque.y+5);
        }
        if (Input.GetKey(KeyCode.DownArrow) && !Attacking)
        {
            animator.SetBool("Ataque", true); Attacking = true;
            vectorAtaque = new Vector3(vectorAtaque.x, 0, vectorAtaque.y-5);  
        }
        if (Input.GetKey(KeyCode.LeftArrow) && !Attacking)
        {
            animator.SetBool("Ataque", true); Attacking = true;
            vectorAtaque = new Vector3(vectorAtaque.x-5, 0, vectorAtaque.y);
        }
        if (Input.GetKey(KeyCode.RightArrow) && !Attacking)
        {
            animator.SetBool("Ataque", true); Attacking = true;
            vectorAtaque = new Vector3(vectorAtaque.x+5, 0, vectorAtaque.y);
        }
        vectorAtaque.Normalize();

        if(!Attacking)
        {   
            animator.SetBool("Ataque", false);
            Seguir();
        }
        else
        {
            Atacar();
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
        GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }

    private void Atacar()
    {
        
        
        // vectorAtaque = new Vector3(vectorAtaque.x * speedAtaque, 0, vectorAtaque.y * speedAtaque);
        
        GetComponent<Rigidbody>().velocity = vectorAtaque*speedAtaque;
        Attacking = false;

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