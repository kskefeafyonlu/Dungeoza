using UnityEngine;

public class MapGridGenerator : MonoBehaviour
{
    
    public int gridX = 9;
    public int gridY = 9;

    public MapGrid[,] mapGridArray;
    public GameObject gridBackGroundPrefab;


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
        selectedMapGrid = selectedPrefab.GetComponent<MapGrid>();
    }



    public void CreateLinkedRoom()
    {
        
    }

}


