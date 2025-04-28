using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class RoomListingMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Transform _content;
    [SerializeField]
    private RoomListing _roomListing;

    private List<RoomListing> _listing = new List<RoomListing>();
    private RoomCanvases _roomsCanvases;
    public void FirstInitialize(RoomCanvases canvases)
    {
        _roomsCanvases = canvases;
    }

    public override void OnJoinedRoom()
    {
        
        _roomsCanvases._CurrentRoom.Show();
        _content.DestroyChildren();
        _listing.Clear();//
    }



    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {

        foreach (RoomInfo info in roomList)
        {
            //removed
            if (info.RemovedFromList)
            {

                int index = _listing.FindIndex(x => x._roomInfo.Name == info.Name);
                if (index != -1)
                {
                    Destroy(_listing[index].gameObject);
                    _listing.RemoveAt(index);
                }
            }
            //added
            else
            {
                int index = _listing.FindIndex(x => x._roomInfo.Name == info.Name);
                if (index == -1)  
                {
                    RoomListing listing = Instantiate(_roomListing, _content);
                    if (listing != null)
                    {
                        listing.SetRoomInfo(info);
                        _listing.Add(listing);
                        Debug.Log("Sala añadida: " + info.Name);
                    }
                }
            }


        }

        //
        print("Recibí actualización de salas: " + roomList.Count + " salas.");

        foreach (RoomInfo info in roomList)
        {
            print("Sala detectada: " + info.Name);

        }

    }
}
