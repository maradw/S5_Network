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

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {

        foreach (RoomInfo info in roomList)
        {
            //removed
            if (info.RemovedFromList)
            {

                int index = _listing.FindIndex(x => x._roomInfo.Name == info.Name);
                if(index != -1)
                {
                    Destroy(_listing[index].gameObject);
                    _listing.RemoveAt(index);
                }
            }
            //added
            else
            {
                RoomListing listing = Instantiate(_roomListing, _content);
                if (listing != null)
                {
                    listing.SetRoomInfo(info);
                    _listing.Add(listing);
                }
            }
                
                
        }

        //
        print("Recibí actualización de salas: " + roomList.Count + " salas.");

        foreach (RoomInfo info in roomList)
        {
            print("Sala detectada: " + info.Name);
           
        }
        //
        // base.OnRoomListUpdate(roomList);
        /*        //base.OnRoomListUpdate(roomList);
                foreach (Transform child in _content)
                {
                    Destroy(child.gameObject);
                }
                foreach (RoomInfo room in roomList)
                {
                    GameObject roomListing = Instantiate(_roomListing, _content);
                    RoomListing roomListingScript = roomListing.GetComponent<RoomListing>();
                    roomListingScript.SetRoomName(room.Name);
                    roomListingScript.SetPlayerCount(room.PlayerCount, room.MaxPlayers);
                    roomListingScript.SetRoomInfo(room);
                }
                //}

                base. OnRoomListUpdate(roomList);
        */

    }
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }
}
