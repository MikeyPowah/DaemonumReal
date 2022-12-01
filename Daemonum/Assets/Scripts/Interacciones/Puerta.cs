using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour, IInteractable
{
    public float x = 0;
    public float y = 0;
    public float teleportX = 0;
    public float teleportY = 0;
    [SerializeField] private GameObject room;

    
    private string _prompt = "Cambiar de Sala";
    public string InteractionPrompt => _prompt;

    void start(){
        x += room.transform.position.x;
        y += room.transform.position.y;
    }

    public bool Interact(Interactor interactor)
    {
        if(!room.GetComponent<RoomBehaviour>().isClosed){
            interactor.ObjectInteractor.transform.position = new Vector3(teleportX, 0.5f,teleportY);
        }
        return true;
    }
}
