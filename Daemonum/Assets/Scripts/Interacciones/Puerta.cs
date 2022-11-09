using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour, IInteractable
{
    [SerializeField] private float x;
    [SerializeField] private float z;
    private string _prompt = "Cambiar de Sala";
    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        
        interactor.ObjectInteractor.transform.position = new Vector3(x, 1,z);
        return true;
    }
}
