using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentRoomCanvas : MonoBehaviour
{
    private RoomCanvases roomsCanvases;

    [SerializeField]
    private PlayerListingMenu playerListingsMenu;
    [SerializeField]
    private LeaveRoomMenu leaveRoomMenu;

    public void FirstInitialize(RoomCanvases canvases)
    {
        roomsCanvases = canvases;
        playerListingsMenu.FirstInitialize(canvases);
        leaveRoomMenu.FirstInitialize(canvases);
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
