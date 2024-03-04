using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class RoomsManager : SerializedMonoBehaviour
{


    public int width = 5;
    public int height = 5;

    [TableMatrix(SquareCells = true)]
    public Room[,] RoomsGrid;

    public List<Room> RoomPrefabsList = new List<Room>();







    private void Start()
    {
        InitalizeRoomsGrid();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            CreateEntryRoom();
        }
    }





    public void InitalizeRoomsGrid()
    {
        RoomsGrid = new Room[width, height];
    }



#region PlaceRoomFunctions
    public void PlaceRoomAt(Vector2Int index)
    {
        RoomsGrid[index.x, index.y] = RoomPrefabsList[0];
    }
    public void PlaceRoomAt(int indexX, int indexY)
    {
        RoomsGrid[indexX, indexY] = RoomPrefabsList[0];
    }
#endregion





    public void CreateEntryRoom()
    {
        int blockadeX = width/2;
        int blockadeY = height/2;

        PlaceRoomAt(blockadeX, blockadeY);
    }



    public void CheckAvailableNeighbours()
    {

    }
    public void CheckAvailableNeighbours(int x, int y)
    {

    }
    public void CheckAvailableNeighbours(Vector2Int index)
    {

    }
}
