using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    public GameObject g;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Player"){ Destroy(g); }
        if (col.gameObject.tag == "wall") { Destroy(g); }
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -13) { Destroy(g);  }
    }
}
