using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalStudent : Student
{

    private GameObject target; // This is Benno's transform
    private Rigidbody rb3d;
    private Transform targetPosition;
    float xdir;


    void Start()
    {
        speed = Random.Range(3f, 8f);

        randomness = Random.Range(3f, 7f);

        minDistanceToFollow = 5f;

        rb3d = GetComponent<Rigidbody>();

        target = GameObject.FindWithTag("Player");

        targetPosition = target.GetComponent<Transform>();
        xdir = Random.Range(-3f, 3f);
        
    }

    // Update is called once per frame
    void Update()
    {
        //rb3d.velocity = new Vector3(0, 0, 0);
        Move();
    }

    public override void Move()
    {
        Vector3 origin = transform.position;

        Vector3 direction = targetPosition.position - origin;

        float distanceToPlayer = direction.magnitude;
       

        direction.Normalize();

        if (distanceToPlayer > minDistanceToFollow)
        {
            rb3d.velocity = direction * speed * randomness;
        }

        else
        {
            rb3d.velocity = new Vector3(1, 0, -1);
        }





    }
}
