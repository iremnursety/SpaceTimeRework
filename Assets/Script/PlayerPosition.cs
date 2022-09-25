using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    public GameObject player;

    [SerializeField] private float positionX;
    [SerializeField] private float positionY;
    [SerializeField] private float positionZ;

    public void OnValidate()
    {
        player = gameObject;
    }

    public void Update()
    {
        PlayerCoordinate();
    }

    private void PlayerCoordinate()
    {
        Vector3 playerPos = player.transform.position;
        positionX = playerPos.x;
        positionY = playerPos.y;
        positionZ = playerPos.z;
    }
}