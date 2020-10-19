using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using WebSocketSharp;
using TMPro;

public class GameManager : MonoBehaviourPunCallbacks
{
    [SerializeField] InputField customRoomName;
    [SerializeField] InputField joinCustomRoomName;

    [Header("UI")]
    [SerializeField] GameObject roomJoiningUI;
    [SerializeField] GameObject roomTextUI;
    [SerializeField] TextMeshProUGUI UI_UpdateText;

    #region UI callback methods
    public void JoinRandomRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }
    public void CreateRoom()
    {
        if (customRoomName.text.IsNullOrEmpty())
        {
            return;
        }
        string roomName = customRoomName.text;
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;
        PhotonNetwork.CreateRoom(roomName, roomOptions);
    }
    public void JoinCustomRoom()
    {
        if(joinCustomRoomName.text.IsNullOrEmpty())
        {
            return;
        }
        string roomName = joinCustomRoomName.text;
        PhotonNetwork.JoinRoom(roomName);
        UI_UpdateText.text = "You joined " + roomName + "waiting for other player";
    }
    #endregion

    #region Photon CallBack Methods
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log(message);
        CreateAndJoinRoom();
    }
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log(message);
        CreateAndJoinRoom();
    }

    #endregion
    private void CreateAndJoinRoom()
    {
        string randomRoomName = "RM" + Random.Range(0, 1000);
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;
        PhotonNetwork.CreateRoom(randomRoomName, roomOptions);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log(PhotonNetwork.NickName + "Joined to " + PhotonNetwork.CurrentRoom.Name);
        if(PhotonNetwork.CurrentRoom.PlayerCount ==1)
        {
            UI_UpdateText.text = "You joined " + PhotonNetwork.CurrentRoom.Name + "waiting for other player";
            roomJoiningUI.SetActive(false);
        }
        else if(PhotonNetwork.CurrentRoom.PlayerCount == 2)
        {
            UI_UpdateText.text = "You joined " + PhotonNetwork.CurrentRoom.Name;
            StartCoroutine(DisableRoomJoinUI());
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log(newPlayer.NickName + " Joined to " + PhotonNetwork.CurrentRoom.Name + "Player Count " + PhotonNetwork.CurrentRoom.PlayerCount);
        UI_UpdateText.text = newPlayer.NickName + " joined to " + PhotonNetwork.CurrentRoom.Name;
        StartCoroutine(DisableRoomJoinUI());
    }

    IEnumerator DisableRoomJoinUI()
    {
        //roomJoiningUI.SetActive(false);
        yield return new WaitForSeconds(2f);
        roomTextUI.SetActive(false);
    }
}
