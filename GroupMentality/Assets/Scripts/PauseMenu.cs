using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    private bool paused = false;
    private Transform child;

    private void Start()
    {
        child = gameObject.transform.GetChild(0);    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && paused == false)
        {
            child.gameObject.SetActive(true);
            Time.timeScale = 0;
            paused = true;
        }
    }

    public void Resume()
    {
        child.gameObject.SetActive(false);
        Time.timeScale = 1;
        paused = false;
    }
}
