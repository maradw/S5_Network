using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentRoomCanvas : MonoBehaviour
{
    private RoomCanvases roomsCanvases;

    public void FirstInitialize(RoomCanvases canvases)
    {
        roomsCanvases = canvases;
    }
    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }

}
