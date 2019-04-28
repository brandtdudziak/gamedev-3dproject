using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Transform cam;
    Vector2 input;

    Rigidbody rb3d;

    private void Start()
    {
        rb3d = GetComponent<Rigidbody>();
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.E))
        {
            GameManager.instance.StationE();
        }
    }
    void FixedUpdate()
    {
        input = new Vector2(Input.GetAxis("ADHorizontal"), Input.GetAxis("WSVertical"));
        input = Vector2.ClampMagnitude(input, 1);

        Vector3 camF = cam.forward;
        Vector3 camR = cam.right;

        camF.y = 0;
        camR.y = 0;
        camF = camF.normalized;
        camR = camR.normalized;

        transform.position += (camF * input.y + camR * input.x) * Time.deltaTime * speed;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Station"))
        {
            GameManager.instance.EnterStation();
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.CompareTag("Station"))
        {
            GameManager.instance.ExitStation();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Student"))
        {
            rb3d.mass = 10000f;
        }

    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Student"))
        {
            rb3d.mass = 1000f;
        }
    }
}
