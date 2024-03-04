using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MapGridGenerator : MonoBehaviour
{
    bool entryRoomCreated = false;

    public GameObject highlighter;

    public int gridX = 9;
    public int gridY = 9;

    public MapGrid[,] mapGridArray;
    public GameObject gridBackGroundPrefab;

    public Vector2Int lastSelectedIndex = new Vector2Int(0, 0);
    public Vector2Int tempSelectedIndex;
    Vector2Int temptemp;


    public GameObject[] roomPrefabs;





    private void Start()
    {
        InitializeGrid();
    }


    private void Update()
    {
        highlighter.transform.position = new Vector3(tempSelectedIndex.x, tempSelectedIndex.y, 0);
        

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (entryRoomCreated)
            {
                CheckCreateRoom();
            }
            else
            {
                CreateEntryRoom();
            }

        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            RotateLastPlacedRoom();
        }

    }

    private void RotateLastPlacedRoom()
    {
        MapGrid room = mapGridArray[lastSelectedIndex.x, lastSelectedIndex.y];
        room.GetRotated();
    }

    private void RotateALl()
    {
        foreach (MapGrid room in mapGridArray)
        {
            if (room != null)
            {
                room.GetRotated();
                

            }

        }
    }





    private void InitializeGrid()
    {
        mapGridArray = new MapGrid[gridX, gridY];

        for (int x = 0; x < gridX; x++)
        {
            for (int y = 0; y < gridY; y++)
            {
                GameObject gridObj = Instantiate(gridBackGroundPrefab, new Vector3(x, y, 0), Quaternion.identity);
                gridObj.transform.parent = transform;
            }
        }
    }



    public void CreateEntryRoom()
    {


        int entrySpawnBlockX = (int)(gridX / 3f);
        int entrySpawnBlockY = (int)(gridY / 3f);

        int randomXPos = Random.Range(entrySpawnBlockY, gridX - entrySpawnBlockX);
        int randomYPos = Random.Range(entrySpawnBlockY, gridY - entrySpawnBlockY);




        InstantiateRoom(new Vector2Int(randomXPos, randomYPos));

        lastSelectedIndex = new Vector2Int(randomXPos, randomYPos);

        entryRoomCreated = true;
    }



    public void CheckCreateRoom()
    {
        List<GameObject> availableRooms = new List<GameObject>();
        MapGrid lastSelectedRoom = GetRoomFromIndex(lastSelectedIndex);

        CheckRoadAvailability(lastSelectedIndex);
        MoveIndexToAvailableGrid();
        InstantiateRoom(tempSelectedIndex);


        lastSelectedIndex = tempSelectedIndex;

    }



    private void InstantiateRoom(Vector2Int ind)
    {
        if(mapGridArray[ind.x, ind.y] == null)
        {

            int randomIndex = Random.Range(0, roomPrefabs.Length);
            GameObject selectedPrefab = roomPrefabs[randomIndex];


            GameObject instantiatedRoom = Instantiate(selectedPrefab, new Vector3(ind.x, ind.y, 0), Quaternion.identity);

            mapGridArray[ind.x, ind.y] = instantiatedRoom.GetComponent<MapGrid>();


            lastSelectedIndex = ind;

            
        }
        //while()
        //rotate
    }



    private MapGrid GetRoomFromIndex(Vector2Int index)
    {
        MapGrid toReturn = mapGridArray[index.x, index.y];
        return toReturn;
    }




    private void MoveIndexToAvailableGrid()
    {
        Vector2Int ind = lastSelectedIndex;
        MapGrid room = GetRoomFromIndex(ind);
        Movability randomPos;
        
        if (room.availableList.Count > 0)
        {
            int randomIndex = Random.Range(0, room.availableList.Count);
            randomPos = room.availableList[randomIndex];

            
            switch (randomPos)
            {
                case Movability.Up:
                    temptemp = tempSelectedIndex;
                    tempSelectedIndex = new Vector2Int(lastSelectedIndex.x, lastSelectedIndex.y + 1);
                    Debug.Log("UpSelected");
                    return;
                case Movability.Down:
                    temptemp = tempSelectedIndex;
                    tempSelectedIndex = new Vector2Int(lastSelectedIndex.x, lastSelectedIndex.y - 1);
                    Debug.Log("DownSelected");
                    return;
                case Movability.Right:
                    temptemp = tempSelectedIndex;
                    tempSelectedIndex = new Vector2Int(lastSelectedIndex.x + 1, lastSelectedIndex.y);
                    Debug.Log("RightSelected");
                    return;
                case Movability.Left:
                    temptemp = tempSelectedIndex;
                    tempSelectedIndex = new Vector2Int(lastSelectedIndex.x - 1, lastSelectedIndex.y);
                    Debug.Log("LeftSelected");
                    return;
            }
        }
        else if(room.linksFinished)
        {





            foreach(Movability x in room.linksList)
            {
                
                if (x == Movability.Up)
                {
                    Debug.Log("lalalala");
                    if(mapGridArray[lastSelectedIndex.x, lastSelectedIndex.y + 1].linksFinished)
                    {
                        room.linksList.Remove(Movability.Up);
                    }
                    else{
                        tempSelectedIndex.y +=1;
                    }
                    
                }

                else if (x == Movability.Right)
                {
                    Debug.Log("lalalala");
                    if(mapGridArray[lastSelectedIndex.x + 1, lastSelectedIndex.y].linksFinished)
                    {
                        room.linksList.Remove(Movability.Right);
                    }
                    else{
                        tempSelectedIndex.x +=1;
                    }
                }

                else if (x == Movability.Down)
                {
                    Debug.Log("lalalala");
                    if(mapGridArray[lastSelectedIndex.x, lastSelectedIndex.y -1].linksFinished)
                    {
                        room.linksList.Remove(Movability.Down);
                    }
                    else{
                        tempSelectedIndex.y -=1;
                    }
                }

                else if (x == Movability.Left)
                {
                    Debug.Log("lalalala");
                    if(mapGridArray[lastSelectedIndex.x - 1, lastSelectedIndex.y].linksFinished)
                    {
                        room.linksList.Remove(Movability.Left);
                    }
                    else{
                        tempSelectedIndex.x -=1;
                    }
                }

            }
        }
    }



    private void CheckRoadAvailability(Vector2Int ind)
    {

        MapGrid room = GetRoomFromIndex(ind);
        room.availableList = new List<Movability>();

        if (room.hasUpExit && ind.y < gridY && (mapGridArray[ind.x, ind.y + 1] == null || mapGridArray[ind.x, ind.y + 1].hasDownExit == true))
        {
            if(mapGridArray[ind.x, ind.y + 1] != null)
            {
                if(mapGridArray[ind.x, ind.y + 1].hasDownExit == true)
                {
                    room.upLinked = true;
                    mapGridArray[ind.x, ind.y + 1].downLinked = true;

                    if(room.availableList.Contains(Movability.Up))
                    {
                        room.availableList.Remove(Movability.Up);
                    }
                }
            }
            else
            {
                room.upAvailability = true;
                room.availableList.Add(Movability.Up);
            }
        }

        if (room.hasDownExit && ind.y > 0 && (mapGridArray[ind.x, ind.y - 1] == null || mapGridArray[ind.x, ind.y - 1].hasUpExit == true))
        {
            if(mapGridArray[ind.x, ind.y - 1] != null)
            {
                if(mapGridArray[ind.x, ind.y - 1].hasUpExit == true)
                {
                    room.downLinked = true;
                    mapGridArray[ind.x, ind.y - 1].upLinked = true;
                    if(room.availableList.Contains(Movability.Down))
                    {
                        room.availableList.Remove(Movability.Down);
                    }
                }
            }
            else
            {
                room.downAvailability = true;
                room.availableList.Add(Movability.Down);
            }
            
        }

        if (room.hasRightExit && ind.x < gridX - 1 && (mapGridArray[ind.x + 1, ind.y] == null || mapGridArray[ind.x + 1, ind.y].hasLeftExit == true))
        {
            if(mapGridArray[ind.x + 1, ind.y] != null)
            {
                if(mapGridArray[ind.x + 1, ind.y].hasLeftExit == true)
                {
                    
                    room.rightLinked = true;
                    mapGridArray[ind.x + 1, ind.y].leftLinked = true;

                    if(room.availableList.Contains(Movability.Right))
                    {
                        room.availableList.Remove(Movability.Right);
                    }
                }
            }
            else
            {
                room.rightAvailability = true;
                room.availableList.Add(Movability.Right);
            }

        }

        if (room.hasLeftExit && ind.x > 0 && (mapGridArray[ind.x - 1, ind.y] == null || mapGridArray[ind.x - 1, ind.y].hasRightExit == true))
        {
            if(mapGridArray[ind.x - 1, ind.y] != null)
            {
                
                if(mapGridArray[ind.x - 1, ind.y].hasRightExit == true)
                {
                    
                    room.leftLinked = true;
                    mapGridArray[ind.x - 1, ind.y].rightLinked = true;

                    if(room.availableList.Contains(Movability.Left))
                    {
                        room.availableList.Remove(Movability.Left);
                    }
                }
            }
            else
            {
                ;
                room.leftAvailability = true;
                room.availableList.Add(Movability.Left);
            }

        }
        room.AddLinksToList();

        if(room.availableList.Count == 0)
        {
            room.linksFinished = true;
        }

        ///////////////////////////////////////////
        ///
        
    }


    private void GoToLinkedRoom(MapGrid currentRoom)
    {
        
    }

}






