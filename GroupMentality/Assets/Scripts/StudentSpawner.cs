﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentSpawner : MonoBehaviour
{
    public Material[] materials;
    public GameObject[] students;
    private int numStudents;

    void Start()
    {
        numStudents = GameManager.instance.numStudents;

        int zOffset = 2;
        int xOffset = 0;
        int offsetScale = 2;

        for(int i = 0; i < numStudents/2; i++)
        {
            if(xOffset > 6)
            {
                xOffset = -2;
                offsetScale *= -1;
            } else if(xOffset < -6)
            {
                xOffset = -2;
                offsetScale *= -1;
                zOffset += offsetScale;
            }

            Vector3 pos = new Vector3(transform.position.x + xOffset, transform.position.y, transform.position.z + zOffset);
            GameObject student = Instantiate(students[0], pos, transform.rotation);
            int randomnumber = Random.Range(0, materials.Length);
            Renderer rend = student.GetComponent<Renderer>();
            rend.material = materials[randomnumber];

            xOffset += offsetScale;
        }

        for(int i = numStudents/2; i < numStudents; i++)
        {

            if(xOffset > 6)
            {
                xOffset = -2;
                offsetScale *= -1;
            } else if(xOffset < -6)
            {
                xOffset = -2;
                offsetScale *= -1;
                zOffset += offsetScale;
            }

            Vector3 pos = new Vector3(transform.position.x + xOffset, transform.position.y, transform.position.z + zOffset);
            int randomnumber = Random.Range(1, students.Length);
            GameObject student = Instantiate(students[randomnumber], pos, transform.rotation);
            randomnumber = Random.Range(1, materials.Length);
            Renderer rend = student.GetComponent<Renderer>();
            rend.material = materials[randomnumber];

            xOffset += offsetScale;
        }
    }

}
