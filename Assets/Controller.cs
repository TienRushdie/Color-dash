using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Controller : MonoBehaviour
{   Rigidbody rb;
MeshRenderer mr;

    public GameObject Bullet;
    public GameObject Cube;
    public int a = 0;
    bool b=false;
    public Material[] mat;
    int isChanged=2;
    public Text t;
    [SerializeField] private int Score=0;
    float horizontal;
    public float speed = 30f;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        StartCoroutine(Spawn());
        rb = GetComponent <Rigidbody>();
        mr=GetComponent <MeshRenderer>();
        StartCoroutine(CubeSpawn());
        mr.sharedMaterial = mat[Random.Range(0, 4)];
    }
    private void Awake()
    {
        Application.targetFrameRate = 100;
    }
    void rub(){if(Input.GetKeyDown(KeyCode.Space)){if(b==false) b=true; else b=false;}}
    // Update is called once per frame
    void FixedUpdate()
    {rub();
        if(b==true)
    {
        if   (Input.GetMouseButtonUp(0)) { speed = 20f; }
        if   (Application.platform== RuntimePlatform.Android) { horizontal = Input.acceleration.x; }
        else {rb.velocity = new Vector3(Input.GetAxis("Horizontal") * speed, rb.velocity.y, rb.velocity.z); }
    
        if(Input.GetMouseButtonDown(0)){rb.AddForce(transform.right*speed,ForceMode.Impulse);}
        if (Input.GetMouseButton(0)) {hhh();}
    }else{
   if(Application.platform==RuntimePlatform.Android){if(Input.touchCount>0){  Vector3 _pos = transform.position;_pos.x = Camera.main.ScreenPointToRay(Input.mousePosition).GetPoint(_pos.z - Camera.main.transform.position.z).x;
        if(_pos.x-transform.position.x<-0.5f) {if(isChanged==0){ rb.velocity=Vector3.zero; } rb.AddForce(speed*-1200f*Time.deltaTime,0f,0f,ForceMode.Acceleration);isChanged=1; }
   else if(_pos.x+transform.position.x>0.5f) {if(isChanged==1){ rb.velocity=Vector3.zero; } rb.AddForce(speed*1200f*Time.deltaTime,0f,0f,ForceMode.Acceleration); isChanged=0; } 
}}else{
       if(Input.GetMouseButtonDown(0)){ Vector3 _pos = transform.position;_pos.x = Camera.main.ScreenPointToRay(Input.mousePosition).GetPoint(_pos.z - Camera.main.transform.position.z).x;
        if(_pos.x<transform.position.x) {if(isChanged==0){ rb.velocity=Vector3.zero; } rb.AddForce(speed*-1200f*Time.deltaTime,0f,0f,ForceMode.Acceleration);isChanged=1; }
   else if(_pos.x>transform.position.x) {if(isChanged==1){ rb.velocity=Vector3.zero; } rb.AddForce(speed*1200f*Time.deltaTime,0f,0f,ForceMode.Acceleration); isChanged=0; } 
    /* if(transform.position.x<0){rb.AddForce(transform.right*speed,ForceMode.Impulse);}else {rb.AddForce(transform.right*-speed,ForceMode.Impulse);}*/ 
    }}t.text = "SCORE: " + Score;
        }
}
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) { Time.timeScale *= 1.5f; }
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Buller") { if (col.gameObject.GetComponent<MeshRenderer>().sharedMaterial == mr.sharedMaterial) {Score++; mr.material = mat[Random.Range(0, 4)]; } else { SceneManager.LoadScene("SampleScene"); } } else if(col.gameObject.tag == "wall"){a++;}
    }
  void hhh() { 

        Vector3 _pos = transform.position;_pos.x = Camera.main.ScreenPointToRay(Input.mousePosition).GetPoint(_pos.z - Camera.main.transform.position.z).x;
        _pos.x = _pos.x > 9f ? 9f : _pos.x;
        _pos.x = _pos.x < -9f ? -9f : _pos.x;
        rb.velocity= new Vector3(_pos.x*speed*Time.deltaTime,rb.velocity.y,rb.velocity.z);
        do speed += 0.1f; while(speed<70f); 
    }

    IEnumerator Spawn()
    { 
      
        while (true)
        {
            //GameObject Bullet;
            Instantiate(Bullet, new Vector3(Random.Range(-4, 4), 13, 12), new Quaternion(Random.Range(-30, 30), 0, Random.Range(-30, 30), Random.Range(-30, 30)));
            var div= Bullet.gameObject.GetComponent<MeshRenderer>().sharedMaterial;
            div = mat[Random.Range(0, 4)];
            Bullet.GetComponent<MeshRenderer>().sharedMaterial = div;
            if (Score > 4) { Bullet.transform.rotation = Quaternion.Euler(3f, 0.5f, 2f); }
            a++;
            yield return new WaitForSeconds(1f);
        }
       

    }
    IEnumerator CubeSpawn()
    {

        while (true)
        {
            if (a > 20)
            {
                Instantiate(Cube, new Vector3(Random.Range(-4, 4), 20, 12), new Quaternion(Random.Range(-28, 28),0, Random.Range(-28, 28), 0));
                var div = Cube.gameObject.GetComponent<MeshRenderer>().sharedMaterial;
                div = mat[Random.Range(0, 4)];
                Cube.GetComponent<MeshRenderer>().sharedMaterial = div;


            }
            yield return new WaitForSeconds(2f);
        }
    }
    public void P()
    {
        SceneManager.LoadScene(0);

    }
}
