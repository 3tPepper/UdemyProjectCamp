using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 360f;

    CharacterController charCtrl;   //클래스를 변수화 하다.
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        charCtrl = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if(dir.sqrMagnitude > 0.01f)    //벡터값 제곱이 0.01보다 크다면 == 입력이 있다면
        {
            Vector3 forward = Vector3.Slerp(transform.forward, dir, rotationSpeed * Time.deltaTime / Vector3.Angle(transform.forward, dir));
            transform.LookAt(transform.position + forward);
        }
        charCtrl.Move(dir * moveSpeed * Time.deltaTime);
        anim.SetFloat("Speed", charCtrl.velocity.magnitude);

        if(GameObject.FindGameObjectsWithTag("Dot").Length < 1)
        {
            switch (SceneManager.GetActiveScene().name)
            {
                case "Main":
                    Score.instance.SavePoint();
                    SceneManager.LoadScene("Main 1");
                    break;
                case "Main 1":
                    Score.instance.SavePoint();
                    SceneManager.LoadScene("Main 2");
                    break;
                case "Main 2":
                    SceneManager.LoadScene("Win");
                    break;
                default:
                    break;
            }
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Dot":
                Destroy(other.gameObject);
                Score.instance.GetPoint();
                Score.instance.ScoreUpdate();

                break;
            case "Enemy":
                Score.instance.ClearPoint();

                SceneManager.LoadScene("Lose");
                break;
            default: 
                break;
        }

    }
}
