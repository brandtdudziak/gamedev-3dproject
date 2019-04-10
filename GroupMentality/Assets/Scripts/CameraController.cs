using UnityEngine;
using System.Collections;

// replace this very simple camera logic with a better solution
public class CameraController : MonoBehaviour {

    public Transform target;
    public float distance = 5;

    private float angleX;
    private float angleY;

	void Start () {

	}
		
	void Update () {
        Vector3 v = new Vector3(0, 0, 1);
        float x = Input.GetAxis("Mouse X");
        angleX += x * 10;
        float y = Input.GetAxis("Mouse Y");
        angleY += y * 10;

        Quaternion rx = Quaternion.AngleAxis(angleX, new Vector3(0, 1, 0));
        Vector3 v_prime = rx * v;

        Quaternion ry = Quaternion.AngleAxis(angleY, new Vector3(1, 0, 0));
        Vector3 v_doublePrime = ry * v_prime; 

		transform.position = v_doublePrime * distance + target.position;
		transform.LookAt (target);
	}
		
}
