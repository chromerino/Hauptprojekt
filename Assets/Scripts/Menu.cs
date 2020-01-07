﻿using Bolt.Matchmaking;
using UdpKit;
using UnityEngine;

public class Menu : Bolt.GlobalEventListener
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject hostMenu;
    [SerializeField] GameObject clientMenu;
    [SerializeField] GameObject lobbyname;
    [SerializeField] GameObject joinname;

    public void NavigateToHostMenu()
    {
        mainMenu.SetActive(false);
        hostMenu.SetActive(true);
    }

    public void NavigateToClientMenu()
    {
        mainMenu.SetActive(false);
        clientMenu.SetActive(true);
    }

    public void NavigateToMainMenu()
    {
        hostMenu.SetActive(false);
        clientMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void StartServer()
    {
        if (string.IsNullOrWhiteSpace(lobbyname.GetComponent<UnityEngine.UI.Text>().text))
        {
            return;
        }
        BoltLauncher.StartServer();
    }

    public void StartClient()
    {
        BoltLauncher.StartClient();

        string matchName = joinname.GetComponent<UnityEngine.UI.Text>().text;
        BoltMatchmaking.JoinSession(matchName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public override void BoltStartDone()
    {
        if (BoltNetwork.IsServer)
        {
            string matchName = lobbyname.GetComponent<UnityEngine.UI.Text>().text;

            BoltMatchmaking.CreateSession(matchName);
            BoltNetwork.LoadScene("Main");
        }
    }

    /*public override void SessionListUpdated(UdpKit.Map<System.Guid, UdpKit.UdpSession> sessionList)
    {
        foreach (var session in sessionList)
        {
            UdpSession photonSession = session.Value as UdpSession;

            if (photonSession.Source == UdpSessionSource.Photon)
            {
                BoltNetwork.Connect(photonSession);
            }
        }
    }*/
}
