using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuertaNextLevel : MonoBehaviour, IInteractable
{
    public GameObject me;
    public bool win = false;
    public float speed = 0.05f;
    
    private string _prompt = "Salir al Bosque";
    public string InteractionPrompt => _prompt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   

        if (win && transform.position.y < 0.1f)
        {
            transform.position = new Vector3(transform.position.x,transform.position.y + speed,transform.position.z);
        }
        
    }
    public void appear(){
        win = true;
    }

    public bool Interact(Interactor interactor)
    {
        GameObject.Find("Player").GetComponent<StatsPlayer>().passStatsWithCoins();
        SceneManager.LoadScene("Level2");
        
        return true;
    }
}
