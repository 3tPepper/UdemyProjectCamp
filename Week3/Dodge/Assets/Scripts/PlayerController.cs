using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody playerRb;
    float speed = 8f;   //이동 속력

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //수평축, 수직축 입력값 감지하여 저장
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        //실제 이동 속도를 입력값, 이동 속력 이용해 결정
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        //vector3 속도를 (xSpeed, 0, zSpeed)로 생성
        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        playerRb.velocity = newVelocity;
    }

    public void Die()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.EndGame();
        //자신의 게임 오브젝트 비활성화
        gameObject.SetActive(false);
    }
}
