using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarCollision : MonoBehaviour
{
    public float pushForce = 20;
    public GameObject RestartMenu;
    private AudioSource audioSource;
    public AudioClip Hurt;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "car")
        {
            Rigidbody rb = GetComponent<Rigidbody>();

            rb.mass = 1;

            //Ragdoll
            rb.constraints = RigidbodyConstraints.None;
            rb.AddForce(1000 * Vector3.up);


            //Audio
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = Hurt;
            audioSource.Play();

            //Game over screen
            StartCoroutine("GameOver");
        }
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(2);
        Time.timeScale = 0;
        Instantiate(RestartMenu, new Vector3(0, 0, 0), Quaternion.identity);
    }
}
