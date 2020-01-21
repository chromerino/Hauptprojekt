using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitIndicator : MonoBehaviour
{
    private float spawnTime;
    private float despawnTime = 10;
    private Image image;

    // Start is called before the first frame update
    void Start()
    {
        spawnTime = Time.time;
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - spawnTime >= despawnTime)
        {
            Destroy(this.gameObject);
            return;
        }
        var tempColor = image.color;
        tempColor.a = ((Time.time - spawnTime) / despawnTime - 1) * -1;
        image.color = tempColor;
    }
}
