using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class PlayerSelectionManager : MonoBehaviour
{ 
    public Transform playerSwitcherTransform;
    public int characterSelectionNumber = 0;
    [SerializeField] GameObject[] characterModels;

    [Header("UI")]
    public Button forward;
    public Button backward;
    [SerializeField] GameObject UI_BeforeSelection;
    [SerializeField] GameObject UI_AfterSelection;


    #region UNITY Methods

    // Start is called before the first frame update
    void Start()
    {
        UI_BeforeSelection.SetActive(true);
        UI_AfterSelection.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {

    }
    #endregion

    #region UI Callback Methods
    public void NextPlayer()
    {
        characterSelectionNumber++;
        if(characterSelectionNumber > characterModels.Length -1)
        {
            characterSelectionNumber = 0;
        }

        Debug.Log(characterSelectionNumber);

        forward.enabled = false;
        backward.enabled = false;

        StartCoroutine(Rotate(Vector3.up, playerSwitcherTransform, 90, 1.0f));
    }

    public void PreviousPlayer()
    {
        characterSelectionNumber--;
        if(characterSelectionNumber < 0)
        {
            characterSelectionNumber = characterModels.Length - 1;
        }
        Debug.Log(characterSelectionNumber);

        forward.enabled = false;
        backward.enabled = false;


        StartCoroutine(Rotate(Vector3.up, playerSwitcherTransform, -90, 1.0f));
    }


    public void OnCharacterSelectButton()
    {

        UI_BeforeSelection.SetActive(false);
        UI_AfterSelection.SetActive(true);

        ExitGames.Client.Photon.Hashtable playerSelectionProperty =
        new ExitGames.Client.Photon.Hashtable { { MultiplayerRunnerGame.PLAYER_CHARACTER_SELECTION_NUMBER, characterSelectionNumber } };
        PhotonNetwork.LocalPlayer.SetCustomProperties(playerSelectionProperty);
    }
    public void OnRunButtonPressed()
    {
        SceneLoader.Instance.LoadScene("SampleScene");
    }

    public void OnReselectButtonPressed()
    {
        UI_BeforeSelection.SetActive(true);
        UI_AfterSelection.SetActive(false);
    }

    public void OnBackButtonPressed()
    {
        SceneLoader.Instance.LoadScene("LoginScene");
    }

    #endregion


    #region Private Methods
    IEnumerator Rotate(Vector3 axis, Transform transformToRotate, float angle, float duration = 1.0f)
    {

        Quaternion originalRotation = transformToRotate.rotation;
        Quaternion finalRotation = transformToRotate.rotation * Quaternion.Euler(axis * angle);

        float elapsedTime = 0.0f;
        while (elapsedTime < duration)
        {
            transformToRotate.rotation = Quaternion.Slerp(originalRotation, finalRotation, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transformToRotate.rotation = finalRotation;

        forward.enabled = true;
        backward.enabled = true;
    }

    #endregion


}

