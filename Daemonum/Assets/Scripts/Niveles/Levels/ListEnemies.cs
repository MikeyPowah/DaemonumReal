using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListEnemies : MonoBehaviour
{
    [SerializeField] GameObject[] list;
    private bool[] enemiesAlive;
    // Start is called before the first frame update
    void Start()
    {
        enemiesAlive = new bool[list.Length];

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void hodor(){
            for(int i = 0; i < list.Length; i++){
                enemiesAlive[i] = list[i].GetComponent<EnemyGenerator>().isAlive;
            }
    }
}
