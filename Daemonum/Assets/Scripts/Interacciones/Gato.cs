using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gato : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    [SerializeField] private InteractionPromptUI _interactionPromptUI;
    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        if (!_interactionPromptUI.IsDisplayed) _interactionPromptUI.Open();
        else _interactionPromptUI.Close();
        return true;
    }
}
