using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MsgDispUGUI : MonoBehaviour
{
    public static string msg;
    public static bool flagDisplay = false;
    public static int msgLen;
    public static float waitDelay;

    private float nextTime = 0;

    public GameObject TxtBox;


    private void Start()
    {
        TxtBox.SetActive(false);
    }
    private void Update()
    {
        if (flagDisplay)
        {
            ShowUI();
            flagDisplay = false;
        }
    }

    //gui 이벤트 처리/렌더링 위해 호출
    private void ShowUI()
    {
        if (flagDisplay)
        {
            //메시지창 출력
            TxtBox.SetActive(true);

            //메시지 출력
            //todo: 천천히 출력되도록
            Text txt = TxtBox.GetComponentInChildren<Text>();
            StartCoroutine(Typing(txt));
        }
    }

    IEnumerator Typing(Text txt)
    {
        
        for(int i=0; i<= msg.Length; i++)
        {
            txt.text = msg.Substring(0,i);
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(2f);
        TxtBox.SetActive(false);
    }

    //외부에서 메시지 받기
    public static void ShowMassage(string msg)
    {
        MsgDispUGUI.msg = msg;
        flagDisplay = true;
        msgLen = 0;
        waitDelay = 0;
    }
}
