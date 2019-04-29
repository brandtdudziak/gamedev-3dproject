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

        Vector2 randomDir = SetTimer();
        randomDir *= 6;

        Vector3 direction = targetPosition.position - origin + new Vector3(randomDir.x, 0, randomDir.y);

        float distanceToPlayer = direction.magnitude;
       

        direction.Normalize();

        if (distanceToPlayer > minDistanceToFollow)
        {
            rb3d.velocity = direction * speed * randomness;
        }

        else
        {

            rb3d.velocity = new Vector3(randomDir.x, 0, randomDir.y);
        }

    }

    IEnumerator Timer ()
    {
        yield return new WaitForSeconds(7);

    }

    Vector2 SetTimer()
    {

        StartCoroutine(Timer());
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
