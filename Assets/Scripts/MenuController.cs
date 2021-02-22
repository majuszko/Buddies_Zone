using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] private string Version = "0.1";
    [SerializeField] private GameObject Username;
    [SerializeField] private GameObject Connect;
    
    [SerializeField] private InputField userInput;
    [SerializeField] private InputField createInput;
    [SerializeField] private InputField joinInput;
    
    [SerializeField] private GameObject StartBut;
    
    

    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings(Version);
    }

    private void Start()
    {
        Username.SetActive(true);
    }

    private void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby(TypedLobby.Default);
        Debug.Log("ugabuga");
    }

    public void UsernameChange()
    {
        if (userInput.text.Length >= 3)
        {
            StartBut.SetActive(true);
        }
        else
        {
            StartBut.SetActive(false);
        }
    }

    public void NewUsername()
    {
        Username.SetActive(false);
        PhotonNetwork.playerName = userInput.text;
    }

    public void CreateGame()
    {
        PhotonNetwork.CreateRoom(createInput.text, new RoomOptions() {maxPlayers = 10}, null);
    }

    public void JoinGame()
    {
        RoomOptions ro = new RoomOptions();
        ro.maxPlayers = 10;
        PhotonNetwork.JoinOrCreateRoom(joinInput.text, ro, TypedLobby.Default);
    }

    private void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }
}
