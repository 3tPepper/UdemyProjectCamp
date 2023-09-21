//���ӽ����̽�: �뵵���� Ŭ������ ��Ƶ� ������ ����
//Ŭ����: �뵵���� ����, �Լ� ���� ����
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameObject jumpEffect;
    public float jumpPower = 5;
    public float playerX = 0.3f;

    TextMesh scoreOutput;
    int score = 0;


    // Start is called before the first frame update
    void Start()
    {
        scoreOutput = GameObject.Find(name: "Score").GetComponent<TextMesh>();
        jumpEffect.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            float nowPower = jumpPower;
            if (transform.position.y <= -3.0f)
            {
                nowPower += 5.0f;
            }
            GetComponent<Rigidbody>().velocity = new Vector3(playerX, nowPower, 0);
            //jumpEffect.SetActive(true);
            //Invoke("JumpEffectOff", 1);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void addScore(int s)
    {
        score += s;
        scoreOutput.text = "���� : " + score;
    }

    public void ChangeColor(MeshRenderer m)
    {
        GetComponent<MeshRenderer>().material.color = m.material.color;
    }

    private void JumpEffectOff()
    {
        jumpEffect.SetActive(false);
    }

}
