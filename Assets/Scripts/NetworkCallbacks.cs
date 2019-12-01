using UnityEngine;

[BoltGlobalBehaviour]
public class NetworkCallbacks : Bolt.GlobalEventListener
{
    public override void SceneLoadLocalDone(string scene)
    {
        var spawnPosition = new Vector3(8, 150, 8);

        BoltNetwork.Instantiate(BoltPrefabs.Player, spawnPosition, Quaternion.identity);
    }
}
