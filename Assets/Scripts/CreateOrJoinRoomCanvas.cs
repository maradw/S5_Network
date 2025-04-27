using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateOrJoinRoomCanvas : MonoBehaviour
{
    [SerializeField]
    private CreateRoomMenu _createRoomMenu;

    private RoomCanvases roomsCanvases;
    
    public void FirstInitialize(RoomCanvases canvases)
    {
        roomsCanvases = canvases;
        _createRoomMenu.FirstInitialize(canvases);
    }

}
