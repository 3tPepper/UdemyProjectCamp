using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float speed = 6f;
    Rigidbody bulletRb;
    // Start is called before the first frame update
    void Start()
    {
        bulletRb = GetComponent<Rigidbody>();
        bulletRb.velocity = transform.forward*speed;

        //3초 뒤 자신 게임 오브젝트 파괴
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            if(playerController != null)
            {
                playerController.Die();
            }
        }
    }
}
