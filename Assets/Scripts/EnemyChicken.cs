using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChicken : Enemy
{
    [Header("Chicken Details")]
    [SerializeField] private float aggroDuration;
    private float aggroTimer;
    [SerializeField] private bool playerDetected;
    [SerializeField] private float detectionRange;
    private bool canFlip = true;

    protected override void Update()
    {
        base.Update();
        anim.SetFloat("xVelocity", rb.velocity.x);
        aggroTimer -= Time.deltaTime;
        if (isDead) return;
        if(playerDetected)
        {
            canMove = true;
            aggroTimer = aggroDuration;
        }
        if (aggroTimer < 0) canMove = false;
        HandleCollision();
        HandleMovement();
        if (isGrounded) HandleTurnAround();
    }

    private void HandleTurnAround()
    {
        if (!isGroundInFrontDetected || isWallDetected)
        {
            Flip();
            canMove = false;
            rb.velocity = Vector2.zero;
        }
    }

    private void HandleMovement()
    {
        if (canMove == false) return;
        HandleFlip(player.transform.position.x);
        rb.velocity = new Vector2(moveSpeed * facingDir, rb.velocity.y);
    }

    protected override void HandleFlip(float xValue)
    {
        if (xValue < transform.position.x && facingRight || xValue > transform.position.x && !facingRight)
        {
            if (canFlip)
            {
                canFlip = false;
                Invoke(nameof(Flip), .3f);
            }
        }
    }

    protected override void Flip()
    {
        base.Flip();

        canFlip = true;
    }

    protected override void HandleCollision()
    {
        base.HandleCollision();

        playerDetected = Physics2D.Raycast(transform.position, Vector2.right * facingDir, detectionRange, whatIsPlayer);
    }

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x + (detectionRange * facingDir), transform.position.y));
    }
}