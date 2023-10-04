using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody playerRb;
    float speed = 8f;   //�̵� �ӷ�

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //������, ������ �Է°� �����Ͽ� ����
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        //���� �̵� �ӵ��� �Է°�, �̵� �ӷ� �̿��� ����
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        //vector3 �ӵ��� (xSpeed, 0, zSpeed)�� ����
        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        playerRb.velocity = newVelocity;
    }

    public void Die()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.EndGame();
        //�ڽ��� ���� ������Ʈ ��Ȱ��ȭ
        gameObject.SetActive(false);
    }
}
