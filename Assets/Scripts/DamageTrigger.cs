using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.tag == "Player") GameManager.instance.player.Knockback();
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null) player.Knockback(transform.position.x);
        //player?.Knockback();
    }
}
