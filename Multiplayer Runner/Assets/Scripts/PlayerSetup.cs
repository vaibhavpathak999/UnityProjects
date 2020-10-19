using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class PlayerSetup : MonoBehaviourPun
{
    public Text playerName;
    public Camera playerCamera;
    // Start is called before the first frame update
    void Start()
    {
        if(photonView.IsMine)
        {
            transform.GetComponent<MovementController>().enabled = true;
            transform.GetComponent<MovementController>().joystick.gameObject.SetActive(true);
            playerCamera.enabled = true;
        }
        else
        {

            transform.GetComponent<MovementController>().enabled = false;
            transform.GetComponent<MovementController>().joystick.gameObject.SetActive(false);
            playerCamera.enabled = false;
            playerCamera.GetComponent<AudioListener>().enabled = false;
        }
        SetPlayerName();
    }

    private void SetPlayerName()
    {
        if(photonView.IsMine)
        {
            playerName.text = "You";
            playerName.color = Color.red;
        }
        else
        {
            playerName.text = photonView.Owner.NickName;
        }
    }
}
