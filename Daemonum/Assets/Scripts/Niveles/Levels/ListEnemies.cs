using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListEnemies : MonoBehaviour
{
    [SerializeField] GameObject[] list;
    private bool[] enemiesAlive;
    bool checkOneClosed = false;
    // Start is called before the first frame update
    void Start()
    {
        enemiesAlive = new bool[list.Length];
        hodor();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void hodor(){
        checkOneClosed = false;
        for(int i = 0; i < list.Length; i++){
            enemiesAlive[i] = list[i].GetComponent<EnemyGenerator>().isAlive;
            // Debug.Log(enemiesAlive[i]);
            if(enemiesAlive[i]){
                checkOneClosed = true;
            }
        }
        if(checkOneClosed){
            Debug.Log("Is Closed");
                this.transform.parent.GetComponent<RoomBehaviour>().accessTrue();
        }else{
            Debug.Log("Is Open");
        this.transform.parent.GetComponent<RoomBehaviour>().accessFalse();
        }
        
    }
}
