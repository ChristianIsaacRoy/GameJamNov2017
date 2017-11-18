using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 0 ;
    private bool Up;
    private bool Down;
    private bool Left;
    private bool Right;

    public KeyCode upKey;
    public KeyCode downKey;
    public KeyCode rightKey;
    public KeyCode leftKey;

    public GameObject wallPrefab;

    Collider2D wall;


    private void Awake()
    {
   
    }
    // Use this for initialization
    void Start () {
        GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;

    }

    // Update is called once per frame
    void Update() {


      if (Input.GetAxis("Vertical" )< 0)
        {
            
            GetComponent<Rigidbody2D>().velocity = -Vector2.up * speed;
        }
      else if (Input.GetAxis("Vertical" )> 0)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
        }
      else if(Input.GetAxis("Horizontal") > 0)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
        }
      else if(Input.GetAxis("Horizontal") < 0)
        {
            GetComponent<Rigidbody2D>().velocity = -Vector2.right * speed;
        }
    }



    void spawnWall()
    {
        GameObject g = (GameObject)Instantiate(wallPrefab, transform.position, Quaternion.identity);
        wall = g.GetComponent<Collider2D>();
    }




}
