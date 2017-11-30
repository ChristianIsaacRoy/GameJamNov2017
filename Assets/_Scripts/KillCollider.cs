using UnityEngine;

public class KillCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.KillColliderCollision(GetComponent<Collider2D>(), collision.gameObject);
        }
        else
        {
            Debug.Log("No GM");
        }
    }
}
