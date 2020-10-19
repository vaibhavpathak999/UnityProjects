using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnManager : MonoBehaviourPunCallbacks
{
    public GameObject[] playerPrefabs;
    public Transform[] spawnPositions;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #region Photon Callbacks Methods
    public override void OnJoinedRoom()
    {
        object playerSelectionNumber;
        if(PhotonNetwork.LocalPlayer.CustomProperties.TryGetValue(MultiplayerRunnerGame.PLAYER_CHARACTER_SELECTION_NUMBER, out playerSelectionNumber))
        {
            int randomSpawnPoint = Random.Range(0, spawnPositions.Length - 1);
            Vector3 intantiatePosition = spawnPositions[randomSpawnPoint].position;

            PhotonNetwork.Instantiate(playerPrefabs[(int)playerSelectionNumber].name, intantiatePosition, Quaternion.identity);
        }

    }

    #endregion
}
