using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] wallPrefab = new GameObject[2];
    public GameObject cylinderPrefab;
    public float interval = 1.5f;
    public float cylinderInterval = 2.0f;
    public float range = 3;
    float term;
    float cylinderTerm;

    // Start is called before the first frame update
    void Start()
    {
        term = interval;
        cylinderTerm = cylinderInterval;    
    }

    // Update is called once per frame
    void Update()
    {
        term += Time.deltaTime;
        cylinderTerm += Time.deltaTime;
        if(term >= interval)
        {
            Vector3 pos = transform.position;
            pos.y += Random.Range(-range, range);
            Instantiate(wallPrefab[Random.Range(0,wallPrefab.Length)], pos, transform.rotation);
            term -= interval;

        }
        if(cylinderTerm >= cylinderInterval)
        {
            Instantiate(cylinderPrefab, transform);
            cylinderTerm -= cylinderInterval;
        }
    }
}
