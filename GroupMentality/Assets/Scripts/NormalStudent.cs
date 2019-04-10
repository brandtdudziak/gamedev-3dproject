using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalStudent : Student
{

    public Transform target; // This is Benno's transform
    private Rigidbody rb2d;

    void Start()
    {
        speed = 5f;
        randomness = Random.Range(1f, 3f);
        minDistanceToFollow = 5f;

        rb2d = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        rb2d.velocity = new Vector3(0, 0, 0);
        Move();
    }

    public override void Move()
    {
        Vector3 origin = transform.position;

        Vector3 direction = target.position - origin;

        float distanceToPlayer = direction.magnitude;
        Debug.Log(distanceToPlayer);

        direction.Normalize();

        if (distanceToPlayer > minDistanceToFollow)
        {
            rb2d.velocity = direction * speed * randomness;
        }

        else
        {
            rb2d.velocity = new Vector3(0, 0, 0);
        }





    }
}
