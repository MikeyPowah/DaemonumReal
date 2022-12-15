using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] GameObject[] listPossibleEnemies;
    public GameObject enemy;
    public bool isAlive = false;
    public bool isBoss = false;
    // Start is called before the first frame update
    void Start()
    {
        generate();
    }
    public void isDead(){
        isAlive = false;
        this.transform.parent.GetComponent<ListEnemies>().hodor();
    }
    public void generate(){
        if(!isAlive){
            if(isBoss){
                enemy = Instantiate(listPossibleEnemies[Random.Range(0,listPossibleEnemies.Length)], new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity, transform);
                isAlive = true;
                enemy.transform.localScale = new Vector3(3f, 3f, 3f);
            }else{
                if(Random.Range(0,2) == 1){
                enemy = Instantiate(listPossibleEnemies[Random.Range(0,listPossibleEnemies.Length)], new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity, transform);
                isAlive = true;
                this.transform.parent.GetComponent<ListEnemies>().hodor();
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
