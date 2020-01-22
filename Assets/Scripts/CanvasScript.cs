using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasScript : MonoBehaviour
{
    [SerializeField] private GameObject HitIndicator;

    public void SpawnIndicator(Transform player, Vector3 source)
    {
        var direction = new Vector2(player.position.x - source.x, player.position.z - source.z);
        var angle = Vector2.SignedAngle(direction, new Vector2(player.forward.x, player.forward.z));

        var indicator = Instantiate(HitIndicator, transform.position, Quaternion.identity);
        indicator.transform.parent = gameObject.transform;
        indicator.transform.Rotate(0, 0, -angle + 180);
    }
}
