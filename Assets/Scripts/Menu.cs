using Bolt.Matchmaking;
using UdpKit;
using UnityEngine;

public class Menu : Bolt.GlobalEventListener
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject hostMenu;
    [SerializeField] GameObject clientMenu;
    [SerializeField] GameObject lobbyname;
    [SerializeField] GameObject joinname;
    [SerializeField] GameObject createPlayerName;
    [SerializeField] GameObject joinPlayerName;

    public void NavigateToHostMenu()
    {
        mainMenu.SetActive(false);
        hostMenu.SetActive(true);
    }

    public void NavigateToClientMenu()
    {
        mainMenu.SetActive(false);
        clientMenu.SetActive(true);
        BoltLauncher.StartClient();
    }

    public void NavigateToMainMenu()
    {
        if (clientMenu.activeSelf)
        {
            BoltLauncher.Shutdown();
        }

        hostMenu.SetActive(false);
        clientMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void StartServer()
    {
        string playerName = createPlayerName.GetComponent<UnityEngine.UI.Text>().text;
        if (string.IsNullOrWhiteSpace(lobbyname.GetComponent<UnityEngine.UI.Text>().text) || string.IsNullOrWhiteSpace(playerName))
        {
            return;
        }

        NetworkCallbacks.playerName = playerName;
        BoltLauncher.StartServer();
    }

    public void StartClient()
    {
        string playerName = joinPlayerName.GetComponent<UnityEngine.UI.Text>().text;
        string matchName = joinname.GetComponent<UnityEngine.UI.Text>().text;
        if (string.IsNullOrWhiteSpace(playerName) || string.IsNullOrWhiteSpace(matchName)) return;

        NetworkCallbacks.playerName = playerName;
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
