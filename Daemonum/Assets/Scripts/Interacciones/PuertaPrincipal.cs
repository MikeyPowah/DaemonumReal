using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuertaPrincipal : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    [SerializeField] private InteractionPromptUI _interactionPromptUI;
    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        _interactionPromptUI.Open();
        GameObject.Find("Player").GetComponent<StatsPlayer>().passStatsWithCoins();
        SceneManager.LoadScene("Level");
        
        return true;
    }

}
