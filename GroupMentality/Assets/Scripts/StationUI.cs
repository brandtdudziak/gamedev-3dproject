using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StationUI : MonoBehaviour
{
    private static StationUI _instance;
    public Text studentsRemaining;
    public CanvasGroup canvas;
    //public AudioClip sound;

    public static StationUI instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<StationUI>();
                if(_instance == null)
                {
                    throw new UnityException("Instance of StationUI not found in scene");
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

        canvas = gameObject.GetComponent<CanvasGroup>();
        canvas.alpha = 0f;
    }

    public void UpdateRemaining(int students, int total)
    {
        studentsRemaining.text = "Students accounted for: " + students.ToString() + "/" + total.ToString();
    }
}
