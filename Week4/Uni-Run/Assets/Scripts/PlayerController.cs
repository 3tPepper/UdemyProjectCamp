﻿using UnityEngine;

// PlayerController는 플레이어 캐릭터로서 Player 게임 오브젝트를 제어한다.
public class PlayerController : MonoBehaviour {
   public AudioClip deathClip; // 사망시 재생할 오디오 클립
   public float jumpForce = 700f; // 점프 힘

   private int jumpCount = 0; // 누적 점프 횟수
   private bool isGrounded = false; // 바닥에 닿았는지 나타냄
   private bool isDead = false; // 사망 상태

   private Rigidbody2D playerRigidbody; // 사용할 리지드바디 컴포넌트
   private Animator animator; // 사용할 애니메이터 컴포넌트
   private AudioSource playerAudio; // 사용할 오디오 소스 컴포넌트

   private void Start() {
        // 초기화
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
   }

   private void Update() {
        if (isDead)
        {
            return;
        }

        // 사용자 입력을 감지하고 점프하는 처리
        if (Input.GetMouseButtonDown(0) && jumpCount <2)
        {
            //점프 횟수 증가
            jumpCount++;
            //점프 직전 속도를 순간적으로 (0,0)으로 변경
            playerRigidbody.velocity = Vector2.zero;
            //리지드바디 위쪽으로 힘 주기
            playerRigidbody.AddForce(new Vector2(0, jumpForce));
            //오디오 소스 재생
            playerAudio.Play();
        }
        else if(Input.GetMouseButtonUp(0) && playerRigidbody.velocity.y > 0)
        {
            //마우스에서 손을 뗀 순간 점프를 하고 있는 중이라면
            //현재 속도를 절반으로 변경
            playerRigidbody.velocity = playerRigidbody.velocity * 0.5f;

        }

        
        animator.SetBool("Grounded", isGrounded);
    }

    private void Die() {
        // 사망 처리
        animator.SetTrigger("Die");
        playerAudio.clip = deathClip;
        playerAudio.Play();

        //속도를 0으로 변경
        playerRigidbody.velocity = Vector2.zero;

        //사망 상태를 true로 변경
        isDead = true;

        GameManager.instance.OnPlayerDead();
    }

   private void OnTriggerEnter2D(Collider2D other) {
       // 트리거 콜라이더를 가진 장애물과의 충돌을 감지
       if(other.tag == "Dead" && !isDead)
        {
            Die();
            
        }
   }

   private void OnCollisionEnter2D(Collision2D collision) {
       // 바닥에 닿았음을 감지하는 처리
       //충돌 위치에 따라 값이 바뀐다. 충돌 표면이 위쪽->아래쪽 이라면 == 발판에 잘 착지 함
       if(collision.contacts[0].normal.y > 0.7f)
        {
            isGrounded = true;
            jumpCount = 0;
        }
   }

   private void OnCollisionExit2D(Collision2D collision) {
        // 바닥에서 벗어났음을 감지하는 처리
        isGrounded = false;
   }
}