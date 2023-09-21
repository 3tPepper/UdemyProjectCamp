using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public static float speed = -8;
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find(name: "Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
        if(transform.position.x < -10)
        {
            player.addScore(1);
            //player.ChangeColor(transform.GetChild(0).GetComponent<MeshRenderer>());
            Destroy(gameObject);
        }
        
    }
}
