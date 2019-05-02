using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCollisionStudent : MonoBehaviour
{

    public float pushForce = 20;
    private AudioSource audioSource;
    public AudioClip Hurt;
    private bool dead;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "car")
        {
            if(!dead)
            {
                Rigidbody rb = GetComponent<Rigidbody>();

                //Ragdoll
                rb.AddForce(1000 * Vector3.up);
                rb.constraints = RigidbodyConstraints.None;

                //Audio
                audioSource = GetComponent<AudioSource>();
                audioSource.clip = Hurt;
                audioSource.Play();

                GameManager.instance.StudentHit();

                //Game over screen
                StartCoroutine("RemoveStudent");
            }
            dead = true;
        }
    }

    public bool IsDead()
    {
        return dead;
    }

    IEnumerator RemoveStudent()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
