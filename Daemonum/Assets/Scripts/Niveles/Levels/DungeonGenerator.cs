using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DungeonGenerator : MonoBehaviour
{
    public class Cell
    {
        public bool[] status = new bool[4];
    }

    public Vector2Int size;
    public Vector2Int offset;
    private Vector2Int actual;
    public GameObject[] suelos;

    Cell[,] board;
    GameObject[,] backRooms;
    int[,] path;
    public int maxRoomPath;
    private int numRoomPath;
    public GameObject startRoom;
    public GameObject[] normalRoom;
    public GameObject bossRoom;
    private int asAllShouldBe;
    
    // Start is called before the first frame update
    void Start()
    {
        board = new Cell[size.x,size.y];
        backRooms = new GameObject[size.x,size.y];
        path = new int[size.x,size.y];
        numRoomPath = maxRoomPath;
        asAllShouldBe = ((size.x * (size.x - 1) + size.y * (size.y - 1)) / 4) - (size.x / 2);
        // rooms = new GameObject[size.x,size.y];
        GenerateStart();
        GeneratePath();
        fillDungeon();
        CheckNeighbours();
        PerfectlyBalanced();
        suelos = GameObject.FindGameObjectsWithTag("Suelo");
        for (int i = 0; i < suelos.Length; i++)
        {
            suelos[i].GetComponent<NavMeshSurface>().BuildNavMesh();
        }
        // Debug.Log(board.Count);
        
    }

    void GenerateStart(){
        actual = new Vector2Int(Random.Range(0,size.x), Random.Range(0,size.y));
        // GameObject yo = (new GetComponent<RoomStart>()).me;
        // backRooms[start.x, start.y] = GetComponent<RoomStart>();
        // Instantiate(yo, new Vector3(start.x * offset.x, 0, start.y * offset.y), Quaternion.identity, transform);
        board[actual.x, actual.y] = new Cell();
        CheckBorders();
        board[actual.x, actual.y].status[0] = false;
        // board[actual.x, actual.y].status[2] = true;
        // board[actual.x, actual.y].status[3] = true;
        backRooms[actual.x, actual.y] = Instantiate(startRoom, new Vector3(actual.x * offset.x, 0, actual.y * offset.y), Quaternion.identity, transform);
        // backRooms[actual.x, actual.y].transform.rotation = Quaternion.Euler(new Vector3(0,180,0));

        backRooms[actual.x, actual.y].GetComponent<RoomBehaviour>().UpdateRoom(board[actual.x, actual.y].status);
        path[actual.x, actual.y] = 1;
        numRoomPath--;
    }
    void GeneratePath(){
        int randomDirection;
        while (numRoomPath > 1){
            randomDirection = Random.Range(0,4);
            if(randomDirection == 0 && actual.y + 1 <= 3 && path[actual.x, actual.y + 1] == 0 && numRoomPath < maxRoomPath-1){
                actual.y++;
                board[actual.x, actual.y] = new Cell();
                CheckBorders();
                backRooms[actual.x, actual.y] = Instantiate(normalRoom[Random.Range(0,normalRoom.Length)], new Vector3(actual.x * offset.x, 0, actual.y * offset.y), Quaternion.identity, transform);
                backRooms[actual.x, actual.y].GetComponent<RoomBehaviour>().UpdateRoom(board[actual.x, actual.y].status);
                path[actual.x, actual.y] = 1;
                numRoomPath--;
            }
            if(randomDirection == 1 && actual.y - 1 >= 0 && path[actual.x, actual.y - 1] == 0){
                actual.y--;
                board[actual.x, actual.y] = new Cell();
                CheckBorders();
                backRooms[actual.x, actual.y] = Instantiate(normalRoom[Random.Range(0,normalRoom.Length)], new Vector3(actual.x * offset.x, 0, actual.y * offset.y), Quaternion.identity, transform);
                backRooms[actual.x, actual.y].GetComponent<RoomBehaviour>().UpdateRoom(board[actual.x, actual.y].status);
                path[actual.x, actual.y] = 1;
                numRoomPath--;
            }
            if(randomDirection == 2 && actual.x + 1 <= 3 && path[actual.x + 1, actual.y] == 0){
                actual.x++;
                board[actual.x, actual.y] = new Cell();
                CheckBorders();
                backRooms[actual.x, actual.y] = Instantiate(normalRoom[Random.Range(0,normalRoom.Length)], new Vector3(actual.x * offset.x, 0, actual.y * offset.y), Quaternion.identity, transform);
                backRooms[actual.x, actual.y].GetComponent<RoomBehaviour>().UpdateRoom(board[actual.x, actual.y].status);
                path[actual.x, actual.y] = 1;
                numRoomPath--;
            }
            if(randomDirection == 3 && actual.x - 1 >= 0 && path[actual.x - 1, actual.y] == 0){
                actual.x--;
                board[actual.x, actual.y] = new Cell();
                CheckBorders();
                backRooms[actual.x, actual.y] = Instantiate(normalRoom[Random.Range(0,normalRoom.Length)], new Vector3(actual.x * offset.x, 0, actual.y * offset.y), Quaternion.identity, transform);
                backRooms[actual.x, actual.y].GetComponent<RoomBehaviour>().UpdateRoom(board[actual.x, actual.y].status);
                path[actual.x, actual.y] = 1;
                numRoomPath--;
            }
        }
        GenerateBoss();
    }
    void GenerateBoss(){
        int randomDirection;
        while (numRoomPath > 0){
            randomDirection = Random.Range(0,4);
            if(randomDirection == 0 && actual.y+1 <= 3 && path[actual.x, actual.y + 1] == 0){
                actual.y++;
                board[actual.x, actual.y] = new Cell();
                board[actual.x, actual.y].status[1] = true;
                backRooms[actual.x, actual.y] = Instantiate(bossRoom, new Vector3(actual.x * offset.x, 0, actual.y * offset.y), Quaternion.identity, transform);
                backRooms[actual.x, actual.y].GetComponent<RoomBehaviour>().UpdateRoom(board[actual.x, actual.y].status);
                path[actual.x, actual.y] = 1;
                numRoomPath--;
            }
            if(randomDirection == 1 && actual.y-1 >= 0 && path[actual.x, actual.y - 1] == 0){
                actual.y--;
                board[actual.x, actual.y] = new Cell();
                board[actual.x, actual.y].status[0] = true;
                backRooms[actual.x, actual.y] = Instantiate(bossRoom, new Vector3(actual.x * offset.x, 0, actual.y * offset.y), Quaternion.identity, transform);
                backRooms[actual.x, actual.y].GetComponent<RoomBehaviour>().UpdateRoom(board[actual.x, actual.y].status);
                path[actual.x, actual.y] = 1;
                numRoomPath--;
            }
            if(randomDirection == 2 && actual.x+1 <= 3 && path[actual.x + 1, actual.y] == 0){
                actual.x++;
                board[actual.x, actual.y] = new Cell();
                board[actual.x, actual.y].status[3] = true;
                backRooms[actual.x, actual.y] = Instantiate(bossRoom, new Vector3(actual.x * offset.x, 0, actual.y * offset.y), Quaternion.identity, transform);
                backRooms[actual.x, actual.y].GetComponent<RoomBehaviour>().UpdateRoom(board[actual.x, actual.y].status);
                path[actual.x, actual.y] = 1;
                numRoomPath--;
            }
            if(randomDirection == 3 && actual.x-1 >= 0 && path[actual.x - 1, actual.y] == 0){
                actual.x--;
                board[actual.x, actual.y] = new Cell();
                board[actual.x, actual.y].status[2] = true;
                backRooms[actual.x, actual.y] = Instantiate(bossRoom, new Vector3(actual.x * offset.x, 0, actual.y * offset.y), Quaternion.identity, transform);
                backRooms[actual.x, actual.y].GetComponent<RoomBehaviour>().UpdateRoom(board[actual.x, actual.y].status);
                path[actual.x, actual.y] = 1;
                numRoomPath--;
            }
        }
    }
    void CheckBorders(){
        
        if(actual.y + 1 <= 3){
            board[actual.x, actual.y].status[0] = true;
        }
        if(actual.y - 1 >= 0){
            board[actual.x, actual.y].status[1] = true;
        }
        if(actual.x + 1 <= 3){
            board[actual.x, actual.y].status[2] = true;
        }
        if(actual.x - 1 >= 0){
            board[actual.x, actual.y].status[3] = true;
        }
    }
    void fillDungeon(){
        for(int i = 0; i < size.x; i++){
            for(int j = 0; j < size.y; j++){
                if (path[i, j] == 0){
                    actual.x = i;
                    actual.y = j;
                    board[i, j] = new Cell();
                    CheckBorders();
                    backRooms[i, j] = Instantiate(normalRoom[Random.Range(0,normalRoom.Length)], new Vector3(i * offset.x, 0, j * offset.y), Quaternion.identity, transform);
                    backRooms[i, j].GetComponent<RoomBehaviour>().UpdateRoom(board[i, j].status);
                }
            }
        }
    }
    void CheckNeighbours(){
        
        for(int i = 0; i < size.x; i++){
            for(int j = 0; j < size.y; j++){
                actual.x = i;
                actual.y = j;
                if (backRooms[actual.x, actual.y].GetComponent<RoomBehaviour>().me != bossRoom.GetComponent<RoomBehaviour>().me && backRooms[actual.x, actual.y].GetComponent<RoomBehaviour>().me != startRoom.GetComponent<RoomBehaviour>().me){
                    
                    if(actual.y + 1 <= 3){
                        if(board[actual.x, actual.y + 1].status[1]){
                            board[actual.x, actual.y].status[0] = true;
                            // backRooms[actual.x, actual.y].GetComponent<RoomBehaviour>().setTPDoor(0 , new Vector2(backRooms[actual.x, actual.y + 1].GetComponent<RoomBehaviour>().getPDoorX(1) + (actual.x) * offset.x, backRooms[actual.x, actual.y + 1].GetComponent<RoomBehaviour>().getPDoorY(1) + (actual.y + 1) * offset.y));
                            // backRooms[actual.x, actual.y].GetComponent<RoomBehaviour>().
                        }  
                        else{
                            board[actual.x, actual.y].status[0] = false;
                        }
                    }
                    if(actual.y - 1 >= 0){
                        if(board[actual.x, actual.y - 1].status[0]){
                            board[actual.x, actual.y].status[1] = true;
                            // backRooms[actual.x, actual.y].GetComponent<RoomBehaviour>().setTPDoor(0 , new Vector2(backRooms[actual.x, actual.y - 1].GetComponent<RoomBehaviour>().getPDoorX(0) + (actual.x) * offset.x, backRooms[actual.x, actual.y - 1].GetComponent<RoomBehaviour>().getPDoorY(0) + (actual.y - 1) * offset.y));
                        }  
                        else{
                            board[actual.x, actual.y].status[1] = false;
                        }
                    }
                    if(actual.x + 1 <= 3){
                        if(board[actual.x + 1, actual.y].status[3]){
                            board[actual.x, actual.y].status[2] = true;
                            // backRooms[actual.x, actual.y].GetComponent<RoomBehaviour>().setTPDoor(0 , new Vector2(backRooms[actual.x + 1, actual.y].GetComponent<RoomBehaviour>().getPDoorX(3) + (actual.x + 1) * offset.x, backRooms[actual.x + 1, actual.y].GetComponent<RoomBehaviour>().getPDoorY(3) + (actual.y) * offset.y));
                        }  
                        else{
                            board[actual.x, actual.y].status[2] = false;
                            }
                    }
                    if(actual.x - 1 >= 0){
                        if(board[actual.x - 1, actual.y].status[2]){
                            board[actual.x, actual.y].status[3] = true;
                            // backRooms[actual.x, actual.y].GetComponent<RoomBehaviour>().setTPDoor(0 , new Vector2(backRooms[actual.x - 1, actual.y].GetComponent<RoomBehaviour>().getPDoorX(2) + (actual.x  - 1) * offset.x, backRooms[actual.x - 1, actual.y].GetComponent<RoomBehaviour>().getPDoorY(2) + (actual.y) * offset.y));
                        }  
                        else{
                            board[actual.x, actual.y].status[3] = false;
                        }
                    }
                }else if (backRooms[actual.x, actual.y].GetComponent<RoomBehaviour>().me == startRoom.GetComponent<RoomBehaviour>().me){
                    
                    if(actual.y - 1 >= 0){
                        if(backRooms[actual.x, actual.y - 1].GetComponent<RoomBehaviour>().me != bossRoom.GetComponent<RoomBehaviour>().me){
                            board[actual.x, actual.y].status[1] = true;
                            // backRooms[actual.x, actual.y].GetComponent<RoomBehaviour>().setTPDoor(0 , new Vector2(backRooms[actual.x, actual.y - 1].GetComponent<RoomBehaviour>().getPDoorX(0) + (actual.x) * offset.x, backRooms[actual.x, actual.y - 1].GetComponent<RoomBehaviour>().getPDoorY(0) + (actual.y - 1) * offset.y));
                        }  
                        else{
                            board[actual.x, actual.y].status[1] = false;
                        }
                    }
                    if(actual.x + 1 <= 3){
                        if(backRooms[actual.x + 1, actual.y].GetComponent<RoomBehaviour>().me != bossRoom.GetComponent<RoomBehaviour>().me){
                            board[actual.x, actual.y].status[2] = true;
                            // backRooms[actual.x, actual.y].GetComponent<RoomBehaviour>().setTPDoor(0 , new Vector2(backRooms[actual.x + 1, actual.y].GetComponent<RoomBehaviour>().getPDoorX(3) + (actual.x + 1) * offset.x, backRooms[actual.x + 1, actual.y].GetComponent<RoomBehaviour>().getPDoorY(3) + (actual.y) * offset.y));
                        }  
                        else{
                            board[actual.x, actual.y].status[2] = false;
                            }
                    }
                    if(actual.x - 1 >= 0){
                        if(backRooms[actual.x - 1, actual.y].GetComponent<RoomBehaviour>().me != bossRoom.GetComponent<RoomBehaviour>().me){
                            board[actual.x, actual.y].status[3] = true;
                            // backRooms[actual.x, actual.y].GetComponent<RoomBehaviour>().setTPDoor(0 , new Vector2(backRooms[actual.x - 1, actual.y].GetComponent<RoomBehaviour>().getPDoorX(2) + (actual.x  - 1) * offset.x, backRooms[actual.x - 1, actual.y].GetComponent<RoomBehaviour>().getPDoorY(2) + (actual.y) * offset.y));
                        }  
                        else{
                            board[actual.x, actual.y].status[3] = false;
                        }
                    }
                }
                if(board[actual.x, actual.y].status[0] == true){
                    backRooms[actual.x, actual.y].GetComponent<RoomBehaviour>().setTPDoor(0 , new Vector2(backRooms[actual.x, actual.y + 1].GetComponent<RoomBehaviour>().getPDoorX(1) + (actual.x) * offset.x, backRooms[actual.x, actual.y + 1].GetComponent<RoomBehaviour>().getPDoorY(1) + (actual.y + 1) * offset.y));
                }
                if(board[actual.x, actual.y].status[1] == true){
                    backRooms[actual.x, actual.y].GetComponent<RoomBehaviour>().setTPDoor(1 , new Vector2(backRooms[actual.x, actual.y - 1].GetComponent<RoomBehaviour>().getPDoorX(0) + (actual.x) * offset.x, backRooms[actual.x, actual.y - 1].GetComponent<RoomBehaviour>().getPDoorY(0) + (actual.y - 1) * offset.y));
                }
                if(board[actual.x, actual.y].status[2] == true){
                    backRooms[actual.x, actual.y].GetComponent<RoomBehaviour>().setTPDoor(2 , new Vector2(backRooms[actual.x + 1, actual.y].GetComponent<RoomBehaviour>().getPDoorX(3) + (actual.x + 1) * offset.x, backRooms[actual.x + 1, actual.y].GetComponent<RoomBehaviour>().getPDoorY(3) + (actual.y) * offset.y));
                }
                if(board[actual.x, actual.y].status[3] == true){
                    backRooms[actual.x, actual.y].GetComponent<RoomBehaviour>().setTPDoor(3 , new Vector2(backRooms[actual.x - 1, actual.y].GetComponent<RoomBehaviour>().getPDoorX(2) + (actual.x  - 1) * offset.x, backRooms[actual.x - 1, actual.y].GetComponent<RoomBehaviour>().getPDoorY(2) + (actual.y) * offset.y));
                }
                
                backRooms[actual.x, actual.y].GetComponent<RoomBehaviour>().UpdateRoom(board[actual.x, actual.y].status);

            }
        }
    }
    void PerfectlyBalanced()
    {
        while (asAllShouldBe > 0){
            actual.x = Random.Range(0,4);
            actual.y = Random.Range(0,4);
            if(path[actual.x, actual.y] != 1){
                board[actual.x, actual.y].status = new bool[4];
                backRooms[actual.x, actual.y].GetComponent<RoomBehaviour>().UpdateRoom(board[actual.x, actual.y].status);
                path[actual.x, actual.y] = 1;
                if(actual.y + 1 <= 3){
                    if(backRooms[actual.x, actual.y + 1].GetComponent<RoomBehaviour>().me != bossRoom.GetComponent<RoomBehaviour>().me){
                        board[actual.x, actual.y + 1].status[1] = false;
                        backRooms[actual.x, actual.y + 1].GetComponent<RoomBehaviour>().UpdateRoom(board[actual.x, actual.y + 1].status);
                    }
                }
                if(actual.y - 1 >= 0){
                    if(backRooms[actual.x, actual.y - 1].GetComponent<RoomBehaviour>().me != bossRoom.GetComponent<RoomBehaviour>().me){
                        board[actual.x, actual.y - 1].status[0] = false;
                        backRooms[actual.x, actual.y - 1].GetComponent<RoomBehaviour>().UpdateRoom(board[actual.x, actual.y - 1].status);
                    }
                }
                if(actual.x + 1 <= 3){
                    if(backRooms[actual.x + 1, actual.y].GetComponent<RoomBehaviour>().me != bossRoom.GetComponent<RoomBehaviour>().me){
                        board[actual.x + 1, actual.y].status[3] = false;
                        backRooms[actual.x + 1, actual.y].GetComponent<RoomBehaviour>().UpdateRoom(board[actual.x + 1, actual.y].status);
                    }
                }
                if(actual.x - 1 >= 0){
                    if(backRooms[actual.x - 1, actual.y].GetComponent<RoomBehaviour>().me != bossRoom.GetComponent<RoomBehaviour>().me){
                        board[actual.x - 1, actual.y].status[2] = false;
                        backRooms[actual.x - 1, actual.y].GetComponent<RoomBehaviour>().UpdateRoom(board[actual.x - 1, actual.y].status);
                    }
                }
                asAllShouldBe--;
                
            }
            
        }
        
        // var newRoom = Instantiate(rooms[randomRoom].room, new Vector3(i * offset.x, 0, -j * offset.y), Quaternion.identity, transform).GetComponent<RoomBehaviour>();
        // Debug.Log("Instance created in " + i +  "," + j + " with " + currentCell.status[0] + " " + currentCell.status[1] + " " + currentCell.status[2] + " " + currentCell.status[3]);
        // newRoom.UpdateRoom(currentCell.status);
        // newRoom.name += " " + i + "-" + j;


    }

    void MazeGenerator()
    {
        
        // GenerateDungeon();
    }

    
    
}
