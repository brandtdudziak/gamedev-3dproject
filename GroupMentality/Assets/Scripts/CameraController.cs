using UnityEngine;
using System.Collections;

// replace this very simple camera logic with a better solution
public class CameraController : MonoBehaviour {
    public Transform target;
    //public float distance;
    //float angleX;
   //float angleY;

    //void Update () {
    //       Vector3 v = new Vector3(0, 0, 1);
    //       float x = Input.GetAxis("Mouse X");
    //       angleX += x * 10;
    //       float y = Input.GetAxis("Mouse Y");
    //       angleY += y * 10;

    //       Quaternion rx = Quaternion.AngleAxis(angleX, new Vector3(0, 1, 0));
    //       Vector3 v_prime = rx * v;

    //       Quaternion ry = Quaternion.AngleAxis(angleY, new Vector3(1, 0, 0));
    //       Vector3 v_doublePrime = ry * v_prime; 

    //	transform.position = v_doublePrime * distance + target.position;
    //	transform.LookAt (target);
    //}



    float y_axis;
    float x_axis;
    public float distance = 5;

    void Start()
    {
        y_axis = Input.GetAxis("Mouse Y");
        x_axis = Input.GetAxis("Mouse X");
    }

    void Update()
    {

        transform.position = new Vector3(0, 3, -3);
        transform.LookAt(target);


        y_axis += Input.GetAxis("Mouse Y") * 10;
        float y_axis_clamped = Mathf.Clamp(y_axis, -30, 0F);

        x_axis += Input.GetAxis("Mouse X") * 10;
        float x_axis_clamped = Mathf.Clamp(x_axis, -360F, 360F);

        //distance = (transform.position - target.position).magnitude;

        Vector3 v = new Vector3(0, 0, 1);

        //rotation about y-axis
        Quaternion rotation = Quaternion.AngleAxis(y_axis_clamped, Vector3.right);
        Vector3 v_prime = rotation * v;

        // rotation about x-axis
        Quaternion rotation2 = Quaternion.AngleAxis(x_axis_clamped, Vector3.up);
        Vector3 v_prime_prime = rotation2 * v_prime;


        Vector3 vector_to_target = v_prime_prime * distance;

        // find the player position
        Vector3 cameraPosition = target.position + vector_to_target;


        transform.position = cameraPosition;
        transform.LookAt(target);
    }

}

		


