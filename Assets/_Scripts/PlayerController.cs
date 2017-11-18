
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public int playerNumber ;
    public float speed = 0 ;
    private bool Up;
    private bool Down;
    private bool Left;
    private bool Right;

    private int wallMade = 0;

    public KeyCode upKey;
    public KeyCode downKey;
    public KeyCode rightKey;
    public KeyCode leftKey;



    public GameObject wallPrefab;

    public Collider2D wall;
    Vector2 lastWallEnd;


    private void Awake()
    {
   
    }
    // Use this for initialization
    void Start () {
        GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
        SpawnWall();

    }

    // Update is called once per frame
    void Update() {

         Vector2 velocity = GetComponent<Rigidbody2D>().velocity;

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
        if (velocity != GetComponent<Rigidbody2D>().velocity)
        {
            SpawnWall();

            
        }
        fitColliderBetween(wall, lastWallEnd, transform.position);
    }



    void SpawnWall()
    {

        lastWallEnd = transform.position;


        GameObject g = (GameObject)Instantiate(wallPrefab, transform.position, Quaternion.identity);
        wall = g.GetComponent<Collider2D>();
    }


    void fitColliderBetween(Collider2D co, Vector2 a, Vector2 b)
    {
        // Calculate the Center Position
        co.transform.position = a + (b - a) * 0.5f;

        // Scale it (horizontally or vertically)
        float dist = Vector2.Distance(a, b);
        if (a.x != b.x)
            co.transform.localScale = new Vector2(dist +1, 1);
        else
            co.transform.localScale = new Vector2(1, dist +1);
    }

}
