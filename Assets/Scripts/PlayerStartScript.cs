using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartScript : MonoBehaviour
{
    private float time;
    private Vector3 startPosition;
    [SerializeField] private GameObject character;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = character.transform.position;
        time = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > time + 15)
        {
            character.transform.position = startPosition;
            Destroy(GetComponent<PlayerStartScript>());
        }
    }
}
