using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class GameManager : MonoBehaviour
{
    public float fallingStartTime;
    public float minTimeBetweenFalls;
    public float maxTimeBetweenFalls;
    
    public GameObject fallingTilePrefab;
    public GameObject gameOverScreen;

    public static GameManager instance;

    private Tilemap tilemapFloor;

    private float timeToNextFall;
    private int width = 18;
    private int height = 10;
    private int numOfTiles;

    public int PlayerOneScore { get; private set; }
    public int PlayerTwoScore { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        tilemapFloor = GameObject.FindGameObjectWithTag("tilemap").GetComponent<Tilemap>();
        instance = this;
        timeToNextFall = fallingStartTime;
        PlayerOneScore = 0;
        PlayerTwoScore = 0;
        numOfTiles = width * height;
        DontDestroyOnLoad(gameObject);
    }
    
    private void Update()
    {
        timeToNextFall -= Time.deltaTime;

        if (timeToNextFall <= 0)
        {
            StartCoroutine(RandomTileFall());
            timeToNextFall = Random.Range(minTimeBetweenFalls, maxTimeBetweenFalls);
        }
    }

    private void OnLevelWasLoaded(int level)
    {
        timeToNextFall = fallingStartTime;
        tilemapFloor = GameObject.FindGameObjectWithTag("tilemap").GetComponent<Tilemap>();
        numOfTiles = width * height;
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
            PlayerTwoScore++;
        }
        else if (playerNumber == 2)
        {
            PlayerOneScore++;
        }

        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Player"))
        {
            go.SetActive(false);
        }
        
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameOverScreen.SetActive(true);
    }

    private IEnumerator RandomTileFall()
    {
        if (numOfTiles <= 0)
        {
            yield return 0;
        }

        Vector3Int tilePos;
        do
        {
            tilePos = new Vector3Int(Random.Range(-width/2, width/2), Random.Range(-height/2, height/2), 0);
        }
        while (!tilemapFloor.HasTile(tilePos));

        tilemapFloor.SetTile(tilePos, null);
        numOfTiles--;

        GameObject go = Instantiate(fallingTilePrefab, new Vector3(tilePos.x+.5f, tilePos.y+.5f), Quaternion.identity);
        go.GetComponent<SpriteRenderer>().sortingOrder = -1;
    }
}
