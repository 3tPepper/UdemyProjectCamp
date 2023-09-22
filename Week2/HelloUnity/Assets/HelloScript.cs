using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float distance = GetDistance(2, 2, 5, 6);
        Debug.Log(distance);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //두 점 사이의 거리
    float GetDistance(float x1, float y1, float x2, float y2)
    {
        float width = x2 - x1;
        float height = y2 - y1;

        float distance = (width * width) + (height * height);
        distance = Mathf.Sqrt(distance);
        return distance;
    }
}
