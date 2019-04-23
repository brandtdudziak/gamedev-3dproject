﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalStudent : Student
{

    public Transform target; // This is Benno's transform
    private Rigidbody rb3d;

    void Start()
    {
        speed = 5f;
        randomness = 2f;
        minDistanceToFollow = 5f;

        rb3d = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        rb3d.velocity = new Vector3(0, 0, 0);
        Move();
    }

    public override void Move()
    {
        Vector3 origin = transform.position;

        Vector3 direction = target.position - origin;

        float distanceToPlayer = direction.magnitude;
       

        direction.Normalize();

        if (distanceToPlayer > minDistanceToFollow)
        {
            rb3d.velocity = direction * speed * randomness;
        }

        else
        {
            rb3d.velocity = new Vector3(0, 0, 0);
        }





    }
}