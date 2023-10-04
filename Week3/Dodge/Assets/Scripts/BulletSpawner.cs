using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    float spawnRateMin = 0.5f;  //�ּ� ���� �ֱ�
    public float spawnRateMax = 3f;    //�ִ� ���� �ֱ�

    public Transform[] target = new Transform[2];
    public int targetNum;

    float spawnRate;           //���� �ֱ�
    float timeAfterSpawn;       //�ֱ� ���� �������κ��� ���� �ð�
    // Start is called before the first frame update
    void Start()
    {
        timeAfterSpawn = 0f;

        //ź�� ���� ���� ���� ����
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
    }

    // Update is called once per frame
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;

        if(timeAfterSpawn >= spawnRate && !GameManager.isGameOver)
        {
            //������ �ð� ����
            timeAfterSpawn = 0f;

            //�Ѿ� ����
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.transform.LookAt(target[targetNum]);
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }
}
