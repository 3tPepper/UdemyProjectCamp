using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    float spawnRateMin = 0.5f;  //최소 생성 주기
    public float spawnRateMax = 3f;    //최대 생성 주기

    public Transform[] target = new Transform[2];
    public int targetNum;

    float spawnRate;           //생성 주기
    float timeAfterSpawn;       //최근 생성 시점으로부터 지난 시간
    // Start is called before the first frame update
    void Start()
    {
        timeAfterSpawn = 0f;

        //탄약 생성 간격 랜덤 지정
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
    }

    // Update is called once per frame
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;

        if(timeAfterSpawn >= spawnRate && !GameManager.isGameOver)
        {
            //누적된 시간 리셋
            timeAfterSpawn = 0f;

            //총알 생성
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.transform.LookAt(target[targetNum]);
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }
}
