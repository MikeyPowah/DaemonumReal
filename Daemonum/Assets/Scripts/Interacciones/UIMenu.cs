using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIMenu : MonoBehaviour, IInteractable
{
    
    [SerializeField] private string _prompt;
    [SerializeField] private InteractionPromptUI _interactionPromptUI;
    public string InteractionPrompt => _prompt;
    private void Update() {
        if (Input.anyKey)
        {
            if (Input.GetKey(KeyCode.F))
                {
                    if (!_interactionPromptUI.IsDisplayed) _interactionPromptUI.Open();
                    else _interactionPromptUI.Close();
                }
        }
    }
    public bool Interact(Interactor interactor)
    {
        if (!_interactionPromptUI.IsDisplayed) _interactionPromptUI.Open();
        else _interactionPromptUI.Close();
        return true;
    }
}
