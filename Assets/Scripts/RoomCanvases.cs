using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCanvases : MonoBehaviour
{
    [SerializeField] CreateOrJoinRoomCanvas _createOrJoinRoom;
    public CreateOrJoinRoomCanvas _CreateOrJoin { get { return _createOrJoinRoom; } }
    [SerializeField] CurrentRoomCanvas _currentRoomCanvas;
    public CurrentRoomCanvas _CurrentRoom { get { return _currentRoomCanvas; } }
    private void Awake()
    {
        FirstInitialize();
    }



    private void FirstInitialize()
    {
        _CreateOrJoin.FirstInitialize(this);
        _CurrentRoom.FirstInitialize(this);
    }

}
    
