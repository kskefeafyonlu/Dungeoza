using UnityEngine;

public class MapGridGenerator : MonoBehaviour
{
    
    public int gridX = 9;
    public int gridY = 9;

    public MapGrid[,] mapGridArray;


    public GameObject[] roomPrefabs;
    public MapGrid selectedMapGrid;


    private void Start() 
    {
        mapGridArray = new MapGrid[gridX, gridY];
        Debug.Log($" {mapGridArray.GetLength(0)}  {mapGridArray.GetLength(1)}");

        CreateEntryRoom();
    }

    




    public void CreateEntryRoom()
    {
        int randomIndex = Random.Range(0, roomPrefabs.Length);
        selectedMapGrid = roomPrefabs[randomIndex].GetComponent<MapGrid>();

        int entrySpawnBlockX = (int)(gridX / 3f);
        int entrySpawnBlockY = (int)(gridY / 3f);

        int randomXPos = Random.Range(entrySpawnBlockY, gridX - entrySpawnBlockX);
        int randomYPos = Random.Range(entrySpawnBlockY, gridY - entrySpawnBlockY);

        mapGridArray[randomXPos, randomYPos] = selectedMapGrid;

        Debug.Log($"x: {randomXPos}    y: {randomYPos}");
        Debug.Log(mapGridArray);

    }


}


