using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float distancia;
    public Transform playerObj;
    public Transform enemy;
    protected NavMeshAgent enemyMesh;
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
        
    }
}
