using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListEnemies : MonoBehaviour
{
    [SerializeField] GameObject[] list;
    private bool[] enemiesAlive;
    public int minNumEnemies = 1;
    public int numEnemies;
    bool checkOneClosed = false;
    // Start is called before the first frame update
    void Start()
    {
        enemiesAlive = new bool[list.Length];
        hodor();
        while (numEnemies < minNumEnemies)
        {
            for(int i = 0; i < list.Length; i++){
                list[i].GetComponent<EnemyGenerator>().generate();
                
            }
            hodor();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void hodor(){
        numEnemies = 0;
        checkOneClosed = false;
        for(int i = 0; i < list.Length; i++){
            enemiesAlive[i] = list[i].GetComponent<EnemyGenerator>().isAlive;
            // Debug.Log(enemiesAlive[i]);
            if(enemiesAlive[i]){
                checkOneClosed = true;
                numEnemies++;
            }
        }
        
        if(checkOneClosed){
                this.transform.parent.GetComponent<RoomBehaviour>().accessTrue();
        }else{
        this.transform.parent.GetComponent<RoomBehaviour>().accessFalse();
        }
        
    }
}
