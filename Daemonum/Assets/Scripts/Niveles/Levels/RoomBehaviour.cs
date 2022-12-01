using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBehaviour : MonoBehaviour
{   
    // 0 - Up 1 -Down 2 - Right 3- Left
    public GameObject[] doors;
    public string me;
    public bool isClosed;
    
    public void UpdateRoom(bool[] status)
    {
        for (int i = 0; i < status.Length; i++)
        {
            doors[i].SetActive(status[i]);
            // if(status[i]){
            //     doors[i].setTeleportLocation(x, z);
            // }
        }
    }
    public void setTPDoor(int i, Vector2 tp){
        doors[i].GetComponent<Puerta>().teleportX = tp.x;
        doors[i].GetComponent<Puerta>().teleportY = tp.y;
    }
    public float getPDoorX(int i){
        return doors[i].GetComponent<Puerta>().x;
    }
    public float getPDoorY(int i){
        return doors[i].GetComponent<Puerta>().y;
    }
    public void accessTrue(){
        isClosed = true;
        Debug.Log("Ha accedido correctamente isClosed = true");
    }
    public void accessFalse(){
        isClosed = false;
        Debug.Log("Ha accedido correctamente isClosed = false");
    }
}