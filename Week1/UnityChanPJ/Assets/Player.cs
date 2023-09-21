using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float playerSpeed = 2.0f;
    public GameObject UnityChan;
    public GameObject Cube;
    public static bool getCube = false;

    // Update is called once per frame
    void Update()
    {
        //플레이어 이동
        if (Input.GetKey("a"))
        {
            transform.position += new Vector3(-playerSpeed*Time.deltaTime, 0, 0);
            UnityChan.transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));
            UnityChan.transform.localPosition = new Vector3(0, 0, 0);
        }
        else if (Input.GetKey("d"))
        {
            transform.position += new Vector3(playerSpeed*Time.deltaTime, 0, 0);
            UnityChan.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
            UnityChan.transform.localPosition = new Vector3(0, 0, 0);
        }
        else if (Input.GetKey("w"))
        {
            transform.position += new Vector3(0, 0, playerSpeed * Time.deltaTime);
            UnityChan.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            UnityChan.transform.localPosition = new Vector3(0, 0, 0);
        }
        else if (Input.GetKey("s"))
        {
            transform.position += new Vector3(0, 0, -playerSpeed * Time.deltaTime);
            UnityChan.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
            UnityChan.transform.localPosition = new Vector3(0, 0, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!getCube)
        {
            if (collision.transform.tag.Equals("Cube"))
            {
                getCube = true;
                Cube.transform.SetParent(UnityChan.transform);
                Cube.transform.localPosition = new Vector3(0, 1.8f, 1f);
                Cube.GetComponent<Rigidbody>().isKinematic = true;
            }
        }

    }
}
