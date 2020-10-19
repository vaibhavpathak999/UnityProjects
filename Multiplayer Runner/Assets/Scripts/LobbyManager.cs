using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    [Header("Login UI")]
    public InputField playerNameInputField;
    public GameObject UI_Login;

    [Header("Lobby UI")]
    public GameObject UI_SuccesLogin;

    [Header("Connection Status UI")]
    public GameObject UI_ConnectionStatus;

    #region UNITY Methods
    void Start()
    {
        if (PhotonNetwork.IsConnected)
        {
            UI_Login.SetActive(false);
            UI_ConnectionStatus.SetActive(false);
            UI_SuccesLogin.SetActive(true);
        }
        else
        {
            UI_Login.SetActive(true);
            UI_ConnectionStatus.SetActive(false);
            UI_SuccesLogin.SetActive(false);
        }
    }

    void Update()
    {
        
    }
    #endregion

    #region UI Callback Methods

    public void OnEnterGameButtonClicked()
    {
        string playerName = playerNameInputField.text;
        if(!string.IsNullOrEmpty(playerName))
        {
            UI_Login.SetActive(false);
            UI_ConnectionStatus.SetActive(true);
            UI_SuccesLogin.SetActive(false);

            if (!PhotonNetwork.IsConnected) // cheking if player is not connected
            {
                PhotonNetwork.LocalPlayer.NickName = playerName; // setting the player name to the photon server
                PhotonNetwork.ConnectUsingSettings(); // connecting the player with the photon server
            }
        }
        else
        {
            Debug.Log("Player name is invalid or empty");
        }

    }


    public void OnQuickMatchButtonPressed()
    {
        //SceneManager.LoadScene("LoadingScene");
        SceneLoader.Instance.LoadScene("CharacterSelection");
    }

    #endregion

    #region PHOTON Callback Methods

    public override void OnConnected()
    {
        //base.OnConnected();
        Debug.Log("We connected to Internet");
    }
    public override void OnConnectedToMaster()
    {
        UI_Login.SetActive(false);
        UI_ConnectionStatus.SetActive(false);
        UI_SuccesLogin.SetActive(true);

        Debug.Log(PhotonNetwork.LocalPlayer.NickName + " is connected to Photon Server");
    }


    #endregion

}
