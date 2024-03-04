using UnityEngine;

public class RoomsManager : MonoBehaviour
{


    public int width = 5;
    public int height = 5;

    public Room[,] RoomsGrid;





    private void Start() {
        InitalizeRoomsGrid();
    }

    private void Update() {
        
    }







    public void InitalizeRoomsGrid()
    {
        RoomsGrid = new Room[width, height];
    }


}


