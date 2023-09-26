using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    private static UI _instance;
    public static UI instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<UI>();
            }
            return _instance;
        }
    }


    public GameObject[] PlayerHP = new GameObject[3];
    public GameObject[] AIHP = new GameObject[3];
    public GameObject GameOverPanel;
    public GameObject GameClearPanel;

    int HPCnt = 3;
    // Start is called before the first frame update
    void Start()
    {
        InitUI();
    }


    void InitUI()
    {
        for(int i=0; i<PlayerHP.Length; i++)
        {
            PlayerHP[i].SetActive(true);
            AIHP[i].SetActive(true);
        }
        GameOverPanel.SetActive(false);
        GameClearPanel.SetActive(false);

    }

    public void ChangeHPUI(string character, int hp)
    {
        if (hp < 0)
        {
            return;
        }
        if(character == "Player1")
        {
            //hp=n -> 3-n °³ ²û [2][1]
            for(int i=0; i<3-hp; i++)
            {
                PlayerHP[HPCnt - i - 1].SetActive(false);
            }
        }
        else if(character == "AI")
        {
            //hp=n -> 3-n °³ ²û [2][1]
            for (int i = 0; i < 3 - hp; i++)
            {
                AIHP[HPCnt - i - 1].SetActive(false);
            }
        }
    }

    public void GameClearUI()
    {
        GameClearPanel.SetActive(true);
    }
    public void GameOverUI()
    {
        GameOverPanel.SetActive(true);
    }
}
