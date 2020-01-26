using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    // Start is called before the first frame update
    public int zoom = 10;
    public int normal = 60;
    public float smooth = 5;
    private bool isZoomed = false;
    public GameObject playerCam;

    // Update is called once per frame
    public void snipe()
    {
        if (playerCam.GetComponent<Camera>().fieldOfView == normal)
        {
            playerCam.GetComponent<Camera>().fieldOfView = zoom;
        }
        else
        {
            playerCam.GetComponent<Camera>().fieldOfView = normal;
        }
        
    }
    public void reset()
    {
        playerCam.GetComponent<Camera>().fieldOfView = normal;
    }
}
