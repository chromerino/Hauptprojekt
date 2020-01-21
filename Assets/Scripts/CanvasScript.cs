using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasScript : MonoBehaviour
{
    [SerializeField] private GameObject HitIndicator;

    public void SpawnIndicator(Transform player, Vector3 source)
    {
        var direction = player.position - source;
        //var angle = Vector3.Angle(Vector3.forward, player.position);
        var angle = Vector3.Angle(player.position, source);

        var indicator = Instantiate(HitIndicator, transform.position, Quaternion.identity);
        indicator.transform.parent = gameObject.transform;
        indicator.transform.Rotate(0, 0, angle);
    }
}
