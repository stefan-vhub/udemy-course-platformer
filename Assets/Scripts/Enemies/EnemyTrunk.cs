using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrunk : Enemy
{
    [Header("Trunk details")]
    [SerializeField] private EnemyBullet bulletPrefab;
    [SerializeField] private Transform gunPoint;
    [SerializeField] private float bulletSpeed = 7;
    [SerializeField] private float attackCooldown = 1.5f;
    private float lastTimeAttacked;

    protected override void Update()
    {
        base.Update();
        if (isDead) return;
        bool canAttack = Time.time > lastTimeAttacked + attackCooldown;
        if (isPlayerDetected && canAttack) Attack();
        HandleMovement();
        if (isGrounded) HandleTurnAround();
    }

    private void HandleTurnAround()
    {
        if (!isGroundInFrontDetected || isWallDetected)
        {
            Flip();
            idleTimer = idleDuration;
            rb.velocity = Vector2.zero;
        }
    }

    private void HandleMovement()
    {
        if (idleTimer > 0) return;
        if (isGroundInFrontDetected) rb.velocity = new Vector2(moveSpeed * facingDir, rb.velocity.y);
    }

    private void Attack()
    {
        idleTimer = idleDuration + attackCooldown;
        lastTimeAttacked = Time.time;
        anim.SetTrigger("attack");
    }

    private void CreateBullet()
    {
        EnemyBullet newBullet = Instantiate(bulletPrefab, gunPoint.position, Quaternion.identity);
        Vector2 bulletVelocity = new Vector2(facingDir * bulletSpeed, 0);
        if (facingDir == 1) newBullet.FlipSprite();
        newBullet.SetVelocity(bulletVelocity);
        Destroy(newBullet.gameObject, 10);
    }
}