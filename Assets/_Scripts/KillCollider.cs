using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.instance.KillColliderCollision(GetComponent<Collider2D>(), collision.gameObject);
    }
}
