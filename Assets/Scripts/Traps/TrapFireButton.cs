using UnityEngine;

public class TrapFireButton : MonoBehaviour
{
    private Animator anim;
    private TrapFire trapFire;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        trapFire = GetComponentInParent<TrapFire>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null)
        {
            anim.SetTrigger("activate");
            trapFire.SwitchOffFire();
        }
    }
}