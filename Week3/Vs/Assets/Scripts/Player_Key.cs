using UnityEngine;
using System.Collections;




/*
 *	プレーヤークラス キー入力で操作
 *	Maruchu
 */
public class Player_Key : Player_Base
{




    public static GameObject m_mainPlayer = null;                   //ユーザーが動かしているプレーヤー(AI用)


    /*
     *	初期化で自分自身のオブジェクトを覚える
     */
    private void Awake()
    {
        m_mainPlayer = gameObject;
    }


    public KeyCode KEYCODE_MOVE_LEFT = KeyCode.A;       //操作方法のキーコード 左
    public KeyCode KEYCODE_MOVE_UP = KeyCode.W;     //操作方法のキーコード 上
    public KeyCode KEYCODE_MOVE_RIGHT = KeyCode.D;      //操作方法のキーコード 右
    public KeyCode KEYCODE_MOVE_DOWN = KeyCode.S;       //操作方法のキーコード 下

    public KeyCode KEYCODE_SHOOT = KeyCode.Space;   //操作方法のキーコード 射撃




    /*
     *	入力処理のチェック
     */
    protected override void GetInput()
    {

        //左右移動
        if (Input.GetKey(KEYCODE_MOVE_LEFT))
        {
            m_playerInput[(int)PlayerInput.Move_Left] = true;
        }
        else
        if (Input.GetKey(KEYCODE_MOVE_RIGHT))
        {
            m_playerInput[(int)PlayerInput.Move_Right] = true;
        }

        //上下移動
        if (Input.GetKey(KEYCODE_MOVE_UP))
        {
            m_playerInput[(int)PlayerInput.Move_Up] = true;
        }
        else
        if (Input.GetKey(KEYCODE_MOVE_DOWN))
        {
            m_playerInput[(int)PlayerInput.Move_Down] = true;
        }

        //射撃
        if (Input.GetKeyDown(KEYCODE_SHOOT))
        {           //これだけ押した瞬間がほしいので GetKeyDown を使います
            m_playerInput[(int)PlayerInput.Shoot] = true;
        }
    }

    protected override void HPUpdate(int hp)
    {
        UI.instance.ChangeHPUI("Player1", hp);
    }

    protected override void ShowPanel()
    {
        UI.instance.GameOverUI();
    }

}
