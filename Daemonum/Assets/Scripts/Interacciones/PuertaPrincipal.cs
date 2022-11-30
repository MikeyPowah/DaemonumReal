using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuertaPrincipal : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        GameObject.Find("Player").GetComponent<StatsPlayer>().passStats();
        SceneManager.LoadScene("Sandbox");
        StatsManager.instance.getPlayer();
        return true;
    }

}
