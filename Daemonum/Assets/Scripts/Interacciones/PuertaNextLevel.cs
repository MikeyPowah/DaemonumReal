using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuertaNextLevel : MonoBehaviour, IInteractable
{
    public GameObject me;

    
    private string _prompt = "Salir al Bosque";
    public string InteractionPrompt => _prompt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void appear(){
        me.SetActive(true);
    }

    public bool Interact(Interactor interactor)
    {
        GameObject.Find("Player").GetComponent<StatsPlayer>().passStatsWithCoins();
        SceneManager.LoadScene("Level2");
        
        return true;
    }
}
