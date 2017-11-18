using UnityEngine;
using UnityEngine.Tilemaps;

public class GameManager : MonoBehaviour
{
    public float fallingStartTime;
    public float minTimeBetweenFalls;
    public float maxTimeBetweenFalls;

    public Tilemap tilemapFloor;
    public GameObject fallingTile;
    public GameObject killCollider;

    public PlayerController player1;
    public PlayerController player2;

    public static GameManager instance;

    private float timeToNextFall;
    private int width = 18;
    private int height = 10;
    private int numOfTiles = 180;

    private int playerOneScore;
    private int playerTwoScore;

    private void Awake()
    {
        instance = this;
        timeToNextFall = fallingStartTime;
        playerOneScore = 0;
        playerTwoScore = 0;
    }

    private void Update()
    {
        timeToNextFall -= Time.deltaTime;

        if (timeToNextFall <= 0)
        {
            RandomTileFall();
            timeToNextFall = Random.Range(minTimeBetweenFalls, maxTimeBetweenFalls);
        }
    }

    public void KillColliderCollision(Collider2D collider, GameObject other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null && player.Wall != collider)
        {
            if (!player.Jumping)
            {
                OnPlayerDeath(player);
            }
        }
    }

    public void OnPlayerDeath(PlayerController player)
    {
        int playerNumber = player.playerNumber;
        player.gameObject.SetActive(false);

        if (playerNumber == 1)
        {
            playerTwoScore++;
        }
        else if (playerNumber == 2)
        {
            playerOneScore++;
        }

        if (player1 != null)
        {
            player1.gameObject.SetActive(false);
        }
        if (player2 != null)
        {
            player2.gameObject.SetActive(false);
        }
    }

    private void RandomTileFall()
    {
        if (numOfTiles <= 0)
        {
            return;
        }

        Vector3Int tilePos;
        do
        {
            tilePos = new Vector3Int(Random.Range(-width/2, width/2), Random.Range(-height/2, height/2), 0);
        }
        while (!tilemapFloor.HasTile(tilePos));

        tilemapFloor.SetTile(tilePos, null);
        numOfTiles--;

        GameObject go = Instantiate(fallingTile, new Vector3(tilePos.x+.5f, tilePos.y+.5f), Quaternion.identity);
        Instantiate(killCollider, new Vector3(tilePos.x + .5f, tilePos.y + .5f), Quaternion.identity);
        go.GetComponent<SpriteRenderer>().sortingOrder = -1;
    }
}
