using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float speed;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine("DestroyCar");
    }

    void FixedUpdate()
    {
        Vector3 movement = Vector3.forward;

        rb.AddForce(movement * speed);
    }

    IEnumerator DestroyCar()
    {
        yield return new WaitForSeconds(4);
        Destroy(gameObject);
    }
}
