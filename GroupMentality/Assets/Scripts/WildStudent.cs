using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WildStudent : Student
{
    public Transform target;
    private Rigidbody rb3d;


    /// <summary>
    /// The wildness of the student.
    /// </summary>
    private float wildness;

    /// <summary>
    /// The different types of the student.
    /// </summary>
    private string[] studentType = new string[] { "Stubborn", "Shape Shifter", "Rebel" };

    /// <summary>
    /// The type of the student.
    /// Stubborn students never move until "very strict condition is met" 
    /// Shape Shifter moves in the set direction, forwards and leftward every time
    /// Rebel alwas overtakes the teacher, and stops moving until the teacher overtakes them.
    /// </summary>
    private string StudentType;


    // Start is called before the first frame update
    void Start()
    {

        speed = Random.Range(0f, 15f);
        randomness = Random.Range(1f, 18f);
        wildness = speed;

        int index = (int)Random.Range(0f, 2f);
        StudentType = studentType[2];


        rb3d = GetComponent<Rigidbody>();


    }

    // Update is called once per frame
    void Update()
    {

        Move();
    }

    public override void Move()
    {
        Debug.Log(StudentType);

        switch (StudentType) {
            case "Stubborn":
                StubbornMovement();
                break;
            case "Rebel":
                RebelMovement();
                break;
            case "Shape Shifter":
                ShapeShifterMovement();
                break;
        }
    }

    // Movement behavior for the stubborn wild student
    public void StubbornMovement()
    {

    }

    // Movement behavior for the Shape shifting wild student
    public void ShapeShifterMovement()
    {

    }

    // Movement behavior for the rebel wild student
    public void RebelMovement()
    {



        Vector3 origin = transform.position;

        Vector3 direction = target.position - origin;

        float distanceToPlayer = direction.magnitude;

        Debug.Log(distanceToPlayer);

        direction.Normalize();


        if (distanceToPlayer > minDistanceToFollow)
        {
            rb3d.velocity = sdirection * speed * randomness * wildness;
        }

        else
        {
            if (target.GetComponent<Rigidbody>().velocity == new Vector3(0, 0, 0))
            {
                rb3d.velocity = direction * 2;
            }

        }


    }
}


