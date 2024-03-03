using System.Collections.Generic;
using UnityEngine;

public class MapGridGenerator : MonoBehaviour
{
    
    public int gridX = 9;
    public int gridY = 9;

    public MapGrid[,] mapGridArray;
    public GameObject gridBackGroundPrefab;

    public Vector2Int lastSelectedIndex = new Vector2Int(0, 0);


    public GameObject[] roomPrefabs;
    public MapGrid selectedMapGrid;




    private void Start()
    {
        InitializeGrid();
        Debug.Log($" {mapGridArray.GetLength(0)}  {mapGridArray.GetLength(1)}");
    }

    
    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            CreateEntryRoom();
        }
    }
    






    private void InitializeGrid()
    {
        mapGridArray = new MapGrid[gridX, gridY];

        for(int x = 0; x < gridX; x++)
        {
            for(int y = 0; y < gridY; y++)
            {
                GameObject gridObj = Instantiate(gridBackGroundPrefab, new Vector3(x, y , 0), Quaternion.identity);
                gridObj.transform.parent = transform;
            }
        }
    }



    private MapGrid GetRoomFromIndex(Vector2Int index)
    {
        MapGrid toReturn = mapGridArray[index.x, index.y];
        return toReturn;
    }



    public void CreateEntryRoom()
    {
        int randomIndex = Random.Range(0, roomPrefabs.Length);
        GameObject selectedPrefab = roomPrefabs[randomIndex];
        
        int entrySpawnBlockX = (int)(gridX / 3f);
        int entrySpawnBlockY = (int)(gridY / 3f);

        int randomXPos = Random.Range(entrySpawnBlockY, gridX - entrySpawnBlockX);
        int randomYPos = Random.Range(entrySpawnBlockY, gridY - entrySpawnBlockY);

        mapGridArray[randomXPos, randomYPos] = selectedMapGrid;

        Debug.Log($"x: {randomXPos}    y: {randomYPos}");
        Debug.Log(mapGridArray);


        Instantiate(selectedPrefab, new Vector3(randomXPos, randomYPos, 0), Quaternion.identity);
        lastSelectedIndex = new Vector2Int(randomXPos, randomYPos);

        selectedMapGrid = selectedPrefab.GetComponent<MapGrid>();
    }





    public void CreateLinkedRoom()
    {
        List<GameObject> availableRooms = new List<GameObject>();
        MapGrid lastSelectedRoom = GetRoomFromIndex(lastSelectedIndex);


        
    }
}






