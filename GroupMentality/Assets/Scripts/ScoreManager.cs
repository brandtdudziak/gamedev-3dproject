using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int _score = 0;

    private static ScoreManager _instance;

    public static ScoreManager instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = GameObject.FindObjectOfType<ScoreManager>();
                    if(_instance == null)
                    {
                        throw new UnityException("Instance of ScoreManager not found in scene");
                    }
                }
                return _instance;
            }
        }

    private void Awake() {
        if(_instance == null)
        {
            _instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void AddScore(int score)
    {
        _score += score;
    }

    public int GetScore()
    {
        return _score;
    }

    public void ResetScore()
    {
        _score = 0;
    }
}
