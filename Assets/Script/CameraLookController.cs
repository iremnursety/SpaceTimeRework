using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookController : MonoBehaviour
{
    [Range(50, 500)] [SerializeField] private float sens;
    [SerializeField] private Transform body;
    [SerializeField] private float xRot = 0f;

    private void OnValidate()
    {
        body = transform.parent;
    }

    private void Update()
    {
        float rotX = Input.GetAxisRaw("Mouse X") * sens * Time.deltaTime;
        float rotY = Input.GetAxisRaw("Mouse Y") * sens * Time.deltaTime;

        xRot -= rotY;
        xRot = Mathf.Clamp(xRot, -80f, 80f);

        transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
        body.Rotate(Vector3.up * rotX);
    }
}