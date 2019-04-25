using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private static GameManager _instance;
    public int numStudents = 1;
    private int studentsAlive;
    private int studentsWithin;
    public string nextLevel;

    public static GameManager instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameManager>();
                if(_instance == null)
                {
                    throw new UnityException("Instance of GameManager not found in scene");
                }
            }
            return _instance;
        }
    }

    private void Start() {
        if(_instance != null)
        {
            Destroy(_instance.gameObject);
        }
        _instance = this;

        studentsAlive = numStudents;
        studentsWithin = 0;
    }

    public void EnterStation()
    {
        StationUI.instance.UpdateRemaining(studentsWithin, studentsAlive);
        StationUI.instance.canvas.alpha = 1f;
    }

    public void ExitStation()
    {
        StationUI.instance.canvas.alpha = 0f;
    }

    public void StudentEnterStation()
    {
        studentsWithin++;
        StationUI.instance.UpdateRemaining(studentsWithin, studentsAlive);
    }

    public void StudentExitStation()
    {
        studentsWithin--;
        StationUI.instance.UpdateRemaining(studentsWithin, studentsAlive);
    }

    public void NextScene()
    {
        SceneManager.LoadScene(nextLevel);
    }

    public void studentHit()
    {
        studentsAlive--;
    }
}
