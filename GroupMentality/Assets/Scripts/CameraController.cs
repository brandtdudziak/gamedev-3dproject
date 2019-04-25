// <copyright file="CameraController.cs" company="DIS Copenhagen">
// Copyright (c) 2017 All Rights Reserved
// </copyright>
// <author>Benno Lueders</author>
// <date>05/10/2017</date>

using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    public Transform target;

    public LayerMask obstacleLayerMask;

    public float distance = 10;
    public float minVerticalAngle = -80;
    public float maxVerticalAngle = 0;

    public float verticalMouseSpeed = 20;
    public float horizontalMouseSpeed = 20;
    public float verticalArrowSpeed = 50;
    public float horizontalArrowSpeed = 50;

    private float angleX;
    private float angleY;

    void Start()
    {
        angleX = -45;
        angleY = 0;
    }

    void Update()
    {
        angleX += ((Input.GetAxis("ArrowVertical") * verticalArrowSpeed) + (Input.GetAxis("Mouse Y") * verticalMouseSpeed)) * Time.deltaTime;
        angleY += ((Input.GetAxis("ArrowHorizontal") * horizontalArrowSpeed) + (Input.GetAxis("Mouse X") * horizontalMouseSpeed)) * Time.deltaTime;

        angleX = Mathf.Clamp(angleX, minVerticalAngle, maxVerticalAngle);
        angleY %= 360;

        Quaternion xRotation = Quaternion.AngleAxis(angleX, new Vector3(1, 0, 0));
        Quaternion yRotation = Quaternion.AngleAxis(angleY, new Vector3(0, 1, 0));
        Vector3 offset = new Vector3(0, 0, 1);
        offset = xRotation * offset;
        offset = yRotation * offset;
        offset *= distance;

        transform.position = target.position + offset;
        transform.rotation = Quaternion.LookRotation(target.position - transform.position, new Vector3(0, 1, 0));
    }
}
