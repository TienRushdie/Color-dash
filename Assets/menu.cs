using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{ Rigidbody rb;
    float speed=5;
    bool isis = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Awake()
    {
        Application.targetFrameRate = 100;
    }

    // Update is called once per frame
    void Update()
    { 
      rb.velocity = new Vector3(speed, rb.velocity.y, speed/3);

    }
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.tag == "minus") { speed *= -1; }
        else if(collision.gameObject.tag == "plus") { speed *= -1; }
    }
    public void P()
    {
        SceneManager.LoadScene(1);
        
    }
}
