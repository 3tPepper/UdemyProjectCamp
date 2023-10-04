using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    float surviveTime = 0;  //생존 시간

    public static bool isGameOver = false;

    public GameObject gameoverTxt;
    public Text timeTxt;
    public Text recordTxt;

    // Start is called before the first frame update
    void Start()
    {
        gameoverTxt.SetActive(false);
        //recordTxt.text = PlayerPrefs.GetFloat("Record").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //게임 오버가 아닌 동안 실행
        if (!isGameOver)
        {
            surviveTime += Time.deltaTime;
            timeTxt.text = "Time: " + (int)surviveTime;
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            isGameOver = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void EndGame()
    {
        isGameOver = true;
        gameoverTxt.SetActive(true);
        //if (surviveTime > )

        float bestTime = PlayerPrefs.GetFloat("BestTime");

        if(surviveTime > bestTime)
        {
            bestTime = surviveTime;
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        recordTxt.text = "Best Time: " + (int)bestTime;
    }
}
