using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChampiController : MonoBehaviour
{
    public float distancia;
    public Transform playerObj;
    public Transform enemy;
    protected NavMeshAgent enemyMesh;
    
    private bool timerIsRunning = false;
    private bool timerLoreyIsRunning = false;
    public float timeLoreyRemaining = 1;
    [SerializeField] private GameObject espada;
    [SerializeField] private GameObject lorey;
    public float timeRemaining = 1;
    [SerializeField] private NavMeshAgent enemigoMovimiento;

    private void OnTriggerStay(Collider col)
    {
        if (col == espada.GetComponent<Collider>() && !timerIsRunning && espada.GetComponent<Animator>().GetBool("Ataque"))
        {
            timerIsRunning = true;
            Debug.Log("Hola");
            enemigoMovimiento.speed = 0;
            AudioManager.instance.EnemigoDañadoSFX();
            //ENEMY DMG
        }
        if(col == lorey.GetComponent<Collider>() && !timerLoreyIsRunning) 
        {
            timerLoreyIsRunning = true;
            Debug.Log("ATAQUE");
            enemigoMovimiento.speed = 0;
            AudioManager.instance.EnemigoAtaqueSFX();
            //LOREY DMG
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        enemyMesh = GetComponent<NavMeshAgent>();
        enemy = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Vector3.Distance(enemy.position,playerObj.position) <= distancia )
        {
            enemyMesh.SetDestination(playerObj.position);
        }
        
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                
            }
            else
            {
                timerIsRunning = false;
                timeRemaining = 1;
                enemigoMovimiento.speed = 5;
            }
        }

        if (timerLoreyIsRunning)
        {
            if (timeLoreyRemaining > 0)
            {
                timeLoreyRemaining -= Time.deltaTime;
                
            }
            else
            {
                timerLoreyIsRunning = false;
                timeLoreyRemaining = 1;
                enemigoMovimiento.speed = 5;
            }
        }
    }
}
