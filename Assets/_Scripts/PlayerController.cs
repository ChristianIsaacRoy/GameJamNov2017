using Rewired;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    [Header("Player Settings")]
    public int playerNumber;
    public Vector2 startDirection;
    public float speed;
    public float jumpTime;
    public GameObject wallPrefab;

    public bool Jumping { get; private set; }

    public Collider2D Wall { get; private set; }

    private Vector2 lastWallEnd;
    private Player player;
    private Rigidbody2D rigid;
    private float jumpStart;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        jumpStart = 0;
        Jumping = false;
    }
    
    private void Start()
    {
        player = ReInput.players.GetPlayer(playerNumber - 1);
        rigid.velocity = startDirection * speed;
        SpawnWall();
    }
    
    private void Update()
    {
        if (Jumping)
        {
            jumpStart += Time.deltaTime;
            if (jumpStart > jumpTime)
            {
                jumpStart = 0;
                Jumping = false;
                SpawnWall();
            }
        }
        else
        {
            Vector2 velocity = GetComponent<Rigidbody2D>().velocity;
            float vert = player.GetAxis("MoveVertical");
            float horz = player.GetAxis("MoveHorizontal");

            if (Mathf.Abs(vert) > Mathf.Abs(horz))
            {
                if (vert < 0)
                {
                    rigid.velocity = Vector2.down * speed;
                }
                else 
                {
                    rigid.velocity = Vector2.up * speed;
                }
            }
            else if (Mathf.Abs(vert) < Mathf.Abs(horz))
            {
                if (horz < 0)
                {
                    rigid.velocity = Vector2.left * speed;
                }
                else
                {
                    rigid.velocity = Vector2.right * speed;
                }
            }

            if (velocity != rigid.velocity)
            {
                SpawnWall();
            }
            FitColliderBetween(Wall, lastWallEnd, transform.position);
        }

        if (player.GetButtonDown("Jump") && Jumping == false)
        {
            SpawnWall();
            Jumping = true;
            transform.DOScale(1.5f, jumpTime / 2).OnComplete(() => ScaleDown());
        }
    }

    private void ScaleDown()
    {
        transform.DOScale(1f, jumpTime / 2);
    }

    private void SpawnWall()
    {
        lastWallEnd = transform.position;
        
        GameObject g = (GameObject)Instantiate(wallPrefab, transform.position, Quaternion.identity);
        Wall = g.GetComponent<Collider2D>();
    }
    
    private void FitColliderBetween(Collider2D co, Vector2 a, Vector2 b)
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
