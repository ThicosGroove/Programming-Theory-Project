using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameObject player;

    private Vector3 offSet = new Vector3(0, 7, -9);

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");        
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offSet;
    }
}
