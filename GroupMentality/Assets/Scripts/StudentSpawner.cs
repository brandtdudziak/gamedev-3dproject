using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentSpawner : MonoBehaviour
{
    public Material[] materials;
    public GameObject[] students;
    public int numStudents;

    void Start()
    {
        for(int i = 0; i < numStudents; i++)
        {
            int randomnumber = Random.Range(0, 4);
            GameObject student = Instantiate(students[randomnumber], transform.position, transform.rotation);
            randomnumber = Random.Range(0, 4);
            Renderer rend = student.GetComponent<Renderer>();
            rend.material = materials[randomnumber];
        }
    }

}
