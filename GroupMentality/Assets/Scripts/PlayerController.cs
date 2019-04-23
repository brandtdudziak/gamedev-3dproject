using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Transform cam;
    Vector2 input;
    bool isMoving = false;
    Rigidbody rb3d;

    private void Start()
    {
        rb3d = GetComponent<Rigidbody>();
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

        //transform.position += (camF * input.y + camR * input.x) * Time.deltaTime * speed;
        rb3d.velocity = (camF * input.y + camR * input.x) * speed;
    }

    public bool IsMoving()
    {
        return isMoving;
    } 
}
