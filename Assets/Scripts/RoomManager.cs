using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RoomManager : MonoBehaviourPunCallbacks
{
    [SerializeField] GameObject player;
    [Space]
    [SerializeField] Transform spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log($"Connecting.....");

        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();

        Debug.Log($"Connected to server");

        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();

        PhotonNetwork.JoinOrCreateRoom(roomName: "test", roomOptions: null, typedLobby: null, expectedUsers: null);

        Debug.Log($"We're in the lobby");
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();

        Debug.Log($"We're connected and in a room now");
        
        var _player = PhotonNetwork.Instantiate(prefabName: player.name, position: spawnPoint.position, rotation: Quaternion.identity);
        _player.GetComponent<PlayerSetup>().IsLocalPlayer();
    }

}
