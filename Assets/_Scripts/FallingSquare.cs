using UnityEngine;
using DG.Tweening;

public class FallingSquare : MonoBehaviour
{
    public float timeTillDeath;
    public float fallSpeed;
    public GameObject killCollider;

    private float timeAlive;
    private bool falling;
    private Vector3 startPos;

    private void Awake()
    {
        falling = false;
        timeAlive = 0;
        GetComponent<SpriteRenderer>().color = Color.red;
        transform.DOShakePosition(1f, .1f).OnComplete(() => Fall());
    }

    private void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        if (falling)
        {
            timeAlive += Time.deltaTime;
            transform.position += Vector3.down * fallSpeed;
        }

        if (timeAlive >= timeTillDeath)
        {
            Destroy(gameObject);
        }
	}

    private void Fall()
    {
        Instantiate(killCollider, new Vector3(startPos.x, startPos.y), Quaternion.identity);
        falling = true;
    }
}
