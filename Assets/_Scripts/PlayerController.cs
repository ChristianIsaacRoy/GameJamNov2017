
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public int jumpTime = 1;
    public float jumpStart;
    public int playerNumber;
    public float speed = 0;

    public bool isJumping;

    private bool Up;
    private bool Down;
    private bool Left;
    private bool Right;

    private int wallMade = 0;

    //public KeyCode upKey;
    //public KeyCode downKey;
    //public KeyCode rightKey;
    //public KeyCode leftKey;
    public KeyCode jump;


    public GameObject wallPrefab;

    public Collider2D wall;
    Vector2 lastWallEnd;

    private Rigidbody2D rigidbody;
    
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        jumpStart = 0;
        isJumping = false;
    }
    // Use this for initialization
    void Start()
    {
        rigidbody.velocity = Vector2.up * speed;
        SpawnWall();
    }

    // Update is called once per frame
    void Update()
    {
        if (isJumping)
        {
            jumpStart += Time.deltaTime;
            if (jumpStart > jumpTime)
            {
                jumpStart = 0;
                isJumping = false;
            }
        }

        Vector2 velocity = GetComponent<Rigidbody2D>().velocity;

        if (Input.GetAxis("Vertical") < 0)
        {
            rigidbody.velocity = -Vector2.up * speed;
        }
        else if (Input.GetAxis("Vertical") > 0)
        {
            rigidbody.velocity = Vector2.up * speed;
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            rigidbody.velocity = Vector2.right * speed;
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            rigidbody.velocity = -Vector2.right * speed;
        }

        if (velocity != rigidbody.velocity)
        {
            SpawnWall();
        }

        if (!isJumping)
        {
            FitColliderBetween(wall, lastWallEnd, transform.position);
        }

        if (Input.GetKeyDown(jump) && isJumping == false)
        {
            isJumping = true;
        }
    }



    void SpawnWall()
    {
        lastWallEnd = transform.position;
        
        GameObject g = (GameObject)Instantiate(wallPrefab, transform.position, Quaternion.identity);
        wall = g.GetComponent<Collider2D>();
    }


    void FitColliderBetween(Collider2D co, Vector2 a, Vector2 b)
    {
        // Calculate the Center Position
        co.transform.position = a + (b - a) * 0.5f;

        // Scale it (horizontally or vertically)
        float dist = Vector2.Distance(a, b);
        if (a.x != b.x)
            co.transform.localScale = new Vector2(dist + 1, 1);
        else
            co.transform.localScale = new Vector2(1, dist + 1);
    }



}
