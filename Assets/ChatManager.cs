using System;
using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using Photon.Chat;
using UnityEngine;
using UnityEngine.UI;
using AuthenticationValues = Photon.Chat.AuthenticationValues;

public class ChatManager : MonoBehaviour, IChatClientListener
{
    private ChatClient chat;
    public InputField userID;
    [SerializeField] private string Version = "0.1";
    private string worldChat;
    public Text txtArea;
    public InputField txtInput;
    public GameObject panel;
    public GameObject txtpanel;
    public Text msg;
    
    
    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings(Version);
    }
    
    private void Start()
    {
        

        Application.runInBackground = true;
        if (string.IsNullOrEmpty(PhotonNetwork.PhotonServerSettings.ChatAppID))
        {
            print("No chat ID");
            return;
        }

        worldChat = "xd";
        //GetConnected();
    }

    private void Update()
    {
        if(this.chat != null)
            this.chat.Service();
    }
    
    
    public void GetConnected()
    {
        print("xddddd");
        chat = new ChatClient(this);
        this.chat.Connect(PhotonNetwork.PhotonServerSettings.ChatAppID, Version, new Photon.Chat.AuthenticationValues(userID.text));
    }

    public void DebugReturn(DebugLevel level, string message)
    {
        throw new NotImplementedException();
    }

    public void OnDisconnected()
    {
        throw new NotImplementedException();
    }

    public void OnConnected()
    {
        panel.SetActive(false);
        txtpanel.SetActive(true);
        this.chat.Subscribe (new string[] { "globle"});
        this.chat.SetOnlineStatus(ChatUserStatus.Online);
    }
    
    void sendMsg()
    {
        this.chat.PublishMessage(worldChat, txtInput.text);
    }

    public void OnChatStateChange(ChatState state)
    {
        throw new NotImplementedException();
    }

    public void OnGetMessages(string channelName, string[] senders, object[] messages)
    {
        for ( int i = 0; i < senders.Length; i++ )
        {
            txtInput.text = senders[i] + ": " + messages[i] + ", ";
        }
    }

    public void OnPrivateMessage(string sender, object message, string channelName)
    {
        throw new NotImplementedException();
    }

    public void OnSubscribed(string[] channels, bool[] results)
    {
        //foreach (string channel in channels)
        
          //  this.chat.PublishMessage(channel, "says 'hi'."); // you don't HAVE to send a msg on join but you could.

        
        sendMsg ();
    }

    public void OnUnsubscribed(string[] channels)
    {
        throw new NotImplementedException();
    }

    public void OnStatusUpdate(string user, int status, bool gotMessage, object message)
    {
        throw new NotImplementedException();
    }

    public void OnUserSubscribed(string channel, string user)
    {
        throw new NotImplementedException();
    }

    public void OnUserUnsubscribed(string channel, string user)
    {
        throw new NotImplementedException();
    }
}
