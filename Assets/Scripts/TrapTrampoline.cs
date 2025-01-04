using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTrampoline : MonoBehaviour
{
    [SerializeField] private float duration = .5f;
    [SerializeField] private float pushPower;

    protected Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();

        if (player != null)
        {
            player.Push(transform.up * pushPower, duration);
            anim.SetTrigger("activate");
        }
    }
}