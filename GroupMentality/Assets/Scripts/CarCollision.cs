using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarCollision : MonoBehaviour
{
    public float pushForce = 20;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "car")
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            Debug.Log("Collision");
            //Vector3 dir = col.contacts[0].point - transform.position;
            //dir = -dir.normalized;
            rb.AddForce(1000 * Vector3.up);
            rb.constraints = RigidbodyConstraints.None;
            StartCoroutine("GameOver");
        }
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("GameOver");
    }
}
