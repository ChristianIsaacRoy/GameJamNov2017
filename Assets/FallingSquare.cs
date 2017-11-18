using UnityEngine;
using DG.Tweening;

public class FallingSquare : MonoBehaviour
{
    public float timeTillDeath;
    public float fallSpeed;

    private float timeAlive;
    private bool falling;

    private void Awake()
    {
        falling = false;
        timeAlive = 0;
        transform.DOShakePosition(1f, .1f).OnComplete(() => Fall());
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
        falling = true;
    }
}
