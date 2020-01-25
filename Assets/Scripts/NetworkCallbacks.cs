using UnityEngine;

[BoltGlobalBehaviour]
public class NetworkCallbacks : Bolt.GlobalEventListener
{
    public static string playerName;

    public override void SceneLoadLocalDone(string scene)
    {
        var spawnPosition = new Vector3(40, 150, 40);

        var player = BoltNetwork.Instantiate(BoltPrefabs.Player, spawnPosition, Quaternion.identity);
        player.GetState<IPlayerState>().name = playerName;
    }
}
