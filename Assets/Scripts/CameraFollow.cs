using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] private Transform player;
    [SerializeField] Vector3 offset;

    private void Update()
    {
        if (player != null)
            transform.position = player.position + offset;
    }


}
