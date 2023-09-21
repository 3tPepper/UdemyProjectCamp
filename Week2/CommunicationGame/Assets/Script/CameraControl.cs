using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject target;

    //카메라 초기화
    Vector3 defPosition;
    Quaternion defRotation;
    float defZoom;

    private void Start()
    {

        //초기 위치 저장
        defPosition = target.transform.position;
        defRotation = target.transform.rotation;
        defZoom = Camera.main.fieldOfView;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            //Debug.Log("마우스 왼쪽 클릭 " + Input.mousePosition);
            //왼쪽 드래그로 카메라 이동
            target.transform.Translate(
                -Input.GetAxis("Mouse X") / 10,
                Input.GetAxis("Mouse Y") / 10,
                0);
        }
        //오른쪽 드래그로 카메라 회전
        else if (Input.GetMouseButton(1))
        {
            target.transform.Rotate(
                0,
                -Input.GetAxis("Mouse X") * 10,
                0);
        }
        //휠 회전으로 확대/축소
        else if(Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            Camera.main.fieldOfView += (-20 * Input.GetAxis("Mouse ScrollWheel"));

            if(Camera.main.fieldOfView < 10)
            {
                Camera.main.fieldOfView = 10;
            }
            else if(Camera.main.fieldOfView > 80)
            {
                Camera.main.fieldOfView = 80;
            }
        }

        //휠 클릭으로 설정 초기화
        else if (Input.GetMouseButton(2))
        {
            target.transform.position = defPosition;
            target.transform.rotation = defRotation;
            Camera.main.fieldOfView = defZoom;
        }
    }
}
