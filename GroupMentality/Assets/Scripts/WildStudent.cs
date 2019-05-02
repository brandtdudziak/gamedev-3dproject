using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WildStudent : Student
{
    private Transform target;
    private GameObject player;
    private Rigidbody rb3d;


    /// <summary>
    /// The wildness of the student.
    /// </summary>
    private float wildness;

    /// <summary>
    /// The different types of the student.
    /// </summary>
    private string[] studentType = new string[] { "Stubborn", "ShapeShifter", "Rebel" };

    /// <summary>
    /// The type of the student.
    /// Stubborn students never move until "very strict condition is met" 
    /// Shape Shifter moves in the set direction, forwards and leftward every time
    /// Rebel alwas overtakes the teacher, and stops moving until the teacher overtakes them.
    /// </summary>
    public string StudentType;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player"); // The player

        target = player.GetComponent<Transform>(); // the transform of the player

        speed = Random.Range(3f, 6f); 

        randomness = Random.Range(1f, 5f);

        int index = (int)Random.Range(0f, 2f);

        wildness = index + 2;

        rb3d = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public override void Move()
    {
        switch (StudentType)
        {
            case "Stubborn":
                StubbornMovement();
                break;
            case "Rebel":
                RebelMovement();
                break;
            case "ShapeShifter":
                ShapeShifterMovement();
                break;

            default:
                RebelMovement();
                break;
        }
    }

    // Movement behavior for the stubborn wild student
    // Only move when the time elapsed since the level load is evenly divisible by 3.
    public void StubbornMovement()
    {

            Vector3 origin = transform.position;

            Vector3 direction = target.position - origin;

            float distanceToPlayer = direction.magnitude;

            direction.Normalize();

            rb3d.velocity = direction * speed;


    }

    // Movement behavior for the Shape shifting wild student
    public void ShapeShifterMovement()
    {
        speed = 5f;
        float randomDist = 5;

        Vector2 randomDir = SetTimer();

        randomDir *= randomDist;

        Vector3 pos = target.position + new Vector3(randomDir.x, 0, randomDir.y);

        Vector3 dir = pos - transform.position;

        dir.Normalize();

        rb3d.velocity = dir * speed;

    }

    // Movement behavior for the rebel wild student
    public void RebelMovement()
    {
        speed = 5f;

        randomness = 3f;

        Vector3 origin = transform.position;

        Vector3 direction = target.position - origin;

        float distanceToPlayer = direction.magnitude;

        direction.Normalize();


        // if player stops moving, then the rebel will overtake the player.
        if (target.GetComponent<Rigidbody>().velocity == new Vector3(0, 0, 0))
        {
            Vector2 randomDir = SetTimer();

            randomDir *= 5;

            Vector3 newTargetPos = target.position + new Vector3(randomDir.x, 0, randomDir.y); // set new target position

            Vector3 newDirection = newTargetPos - transform.position; // find new direction

            newDirection.Normalize();   // normalize direction

            rb3d.velocity = newDirection * speed * randomness; // set new velocity
            //transform.position = newTargetPos;

        }

        // If player leaves the movement radius, then the rebel will follow.
        else if (distanceToPlayer > minDistanceToFollow)
        {
            rb3d.velocity = direction * speed * wildness * randomness;
        }
    }

    IEnumerator RandomTimer ()
    {
        yield return new WaitForSeconds(5);
    }

    Vector2 SetTimer()
    {
        StartCoroutine(RandomTimer());
        return Random.insideUnitCircle;

    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Station"))
        {
            GameManager.instance.StudentEnterStation();
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.CompareTag("Station"))
        {
            GameManager.instance.StudentExitStation();
        }
    }
}


