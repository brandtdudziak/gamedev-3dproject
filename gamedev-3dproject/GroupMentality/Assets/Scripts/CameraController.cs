using UnityEngine;
using System.Collections;

// replace this very simple camera logic with a better solution
public class CameraController : MonoBehaviour {

    public Transform target;

    float y_axis;
    float x_axis;

    void Start () {
        y_axis = Input.GetAxis("Mouse Y");
        x_axis = Input.GetAxis("Mouse X");
    }
		
	void Update () {

        transform.position = new Vector3(0, 3, -3);
        transform.LookAt(target);


        y_axis += Input.GetAxis("Mouse Y");
        float y_axis_clamped = Mathf.Clamp(y_axis, -30, 0F);

        x_axis += Input.GetAxis("Mouse X");
        float x_axis_clamped = Mathf.Clamp(x_axis, -360F, 360F);
       
        Vector3 distance = transform.position - target.position;

        Vector3 v = new Vector3(0, 0, 1);

        //rotation about y-axis
        Quaternion rotation = Quaternion.AngleAxis(y_axis_clamped, Vector3.right);
        Vector3 v_prime = rotation * v;

        // rotation about x-axis
        Quaternion rotation2 = Quaternion.AngleAxis(x_axis_clamped, Vector3.up);
        Vector3 v_prime_prime = rotation2 * v_prime;


        Vector3 vector_to_target = v_prime_prime * distance.magnitude;

        // find the player position
        Vector3 cameraPosition = target.position + vector_to_target;


        transform.position = cameraPosition;
		transform.LookAt (target);
	}
		
}
