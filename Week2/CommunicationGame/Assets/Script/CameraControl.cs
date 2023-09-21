using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject target;

    //ī�޶� �ʱ�ȭ
    Vector3 defPosition;
    Quaternion defRotation;
    float defZoom;

    private void Start()
    {

        //�ʱ� ��ġ ����
        defPosition = target.transform.position;
        defRotation = target.transform.rotation;
        defZoom = Camera.main.fieldOfView;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            //Debug.Log("���콺 ���� Ŭ�� " + Input.mousePosition);
            //���� �巡�׷� ī�޶� �̵�
            target.transform.Translate(
                -Input.GetAxis("Mouse X") / 10,
                Input.GetAxis("Mouse Y") / 10,
                0);
        }
        //������ �巡�׷� ī�޶� ȸ��
        else if (Input.GetMouseButton(1))
        {
            target.transform.Rotate(
                0,
                -Input.GetAxis("Mouse X") * 10,
                0);
        }
        //�� ȸ������ Ȯ��/���
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

        //�� Ŭ������ ���� �ʱ�ȭ
        else if (Input.GetMouseButton(2))
        {
            target.transform.position = defPosition;
            target.transform.rotation = defRotation;
            Camera.main.fieldOfView = defZoom;
        }
    }
}
