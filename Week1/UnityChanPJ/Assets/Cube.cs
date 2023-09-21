using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    // Start is called before the first frame update

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag.Equals("Button"))
        {
            transform.SetParent(null);
            GetComponent<Rigidbody>().isKinematic = false;
            Player.getCube = false;
            Door.doorOpen = true;
        }
    }
}
