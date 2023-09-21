using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public static bool doorOpen = false;
    float doorSpeed = 1f;
    Vector3 doorpos;

    private void Start()
    {
        doorpos = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        if (doorOpen)
        {
            transform.position += new Vector3(0, doorSpeed * Time.deltaTime, 0);
        }
        else
        {
            Vector3.MoveTowards(transform.position, doorpos, doorSpeed);
        }
    }
}
