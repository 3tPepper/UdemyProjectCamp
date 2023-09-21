using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score _instance;
    public static Score instance
    {
        get{
            if(_instance == null)
            {
                _instance = FindObjectOfType<Score>();
            }
            return _instance;
        }
    }

    private int score = 0;
    public static bool getDot = false; 
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("Score"))
        {
            score = PlayerPrefs.GetInt("Score");
            ScoreUpdate();
        }
    }

    //ui score update
    public void ScoreUpdate()
    {
        GetComponent<Text>().text = score.ToString();
    }

    //score plus
    public void GetPoint()
    {
        score++;
    }

    //score save in local
    public void SavePoint()
    {
        PlayerPrefs.SetInt("Score", score);
    }

    public void ClearPoint()
    {
        PlayerPrefs.DeleteKey("Score");
    }
}
