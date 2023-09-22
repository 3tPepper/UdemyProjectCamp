using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MsgDisplay : MonoBehaviour
{
    public static string msg;
    public static bool flagDisplay = false;
    public GUIStyle guiDisplay;
    public static int msgLen;
    public static float waitDelay;

    private float nextTime = 0;
    private Rect rtDisplay = new Rect();


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        if(flagDisplay)
        {
            if(msgLen < msg.Length)
            {
                if (Time.time > nextTime)
                { 
                    msgLen++;
                    nextTime = Time.time + 0.02f;
                }
            }
            else
            {
                waitDelay += Time.deltaTime;
                if(waitDelay > 1 + msg.Length / 4)
                {
                    flagDisplay = false;
                }
            }
        }
    }

    //gui 이벤트 처리/렌더링 위해 호출
    private void OnGUI()
    {
        const float guiScreen = 1280;
        const float guiWidth = 800;
        const float guiHeight = 200;
        const float guiLeft = (guiScreen - guiWidth) /2;
        const float guiTop = 720 - guiHeight - 20;

        //현재 화면과의 비율
        float gui_scale = Screen.width / guiScreen;

        if (flagDisplay)
        {
            //글꼴 스타일
            GUIStyle msgFont = new GUIStyle
            {
                fontSize = (int)(30 * gui_scale)
            };

            //메시지창 위치 계산
            rtDisplay.x = guiLeft * gui_scale;
            rtDisplay.y = guiTop * gui_scale;
            rtDisplay.width = guiWidth * gui_scale;
            rtDisplay.height = guiHeight * gui_scale;

            //메시지창 출력
            GUI.Box(rtDisplay, "창", guiDisplay);

            //메시지 그림자 출력
            msgFont.normal.textColor = Color.black;
            rtDisplay.x = (guiLeft + 22) * gui_scale;
            rtDisplay.y = (guiTop + 22) * gui_scale;
            GUI.Label(rtDisplay, msg.Substring(0, msgLen), msgFont);

            //메시지 출력
            msgFont.normal.textColor = Color.white;
            rtDisplay.x = (guiLeft + 20) * gui_scale;
            rtDisplay.y = (guiTop + 20) * gui_scale;
            GUI.Label(rtDisplay, msg.Substring(0,msgLen), msgFont);
        }
    }

    //외부에서 메시지 받기
    public static void ShowMassage(string msg)
    {
        MsgDisplay.msg = msg;
        flagDisplay = true;
        msgLen = 0;
        waitDelay = 0;
    }
}
