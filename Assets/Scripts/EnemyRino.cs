using UnityEngine;

public class EnemyRino : Enemy
{
    [Header("Rino details")]
    [SerializeField] private float maxSpeed;
    [SerializeField] private float speedUpRate = .6f;
    private float defaultSpeed;
    [SerializeField] private Vector2 impactPower;

    protected override void Start()
    {
        base.Start();
        defaultSpeed = moveSpeed;
    }

    protected override void Update()
    {
        base.Update();
        HandleCharge();
    }

    private void HandleCharge()
    {
        if (canMove == false) return;
        HandleSpeedUp();
        rb.velocity = new Vector2(moveSpeed * facingDir, rb.velocity.y);
        if (isWallDetected) WallHit();
        if (!isGroundInFrontDetected) TurnAround();
    }

    private void HandleSpeedUp()
    {
        moveSpeed = moveSpeed + (Time.deltaTime * speedUpRate);
        if (moveSpeed >= maxSpeed) maxSpeed = moveSpeed;
    }

    private void TurnAround()
    {
        SpeedReset();
        canMove = false;
        rb.velocity = Vector2.zero;
        Flip();
    }

    private void WallHit()
    {
        canMove = false;
        SpeedReset();
        anim.SetBool("hitWall", true);
        rb.velocity = new Vector2(impactPower.x * -facingDir, impactPower.y);
    }

    private void SpeedReset()
    {
        moveSpeed = defaultSpeed;
    }

    private void ChargeIsOver()
    {
        anim.SetBool("hitWall", false);
        Invoke(nameof(Flip), 1);
    }

    protected override void HandleCollision()
    {
        base.HandleCollision();

        if (isPlayerDetected && isGrounded) canMove = true;
    }
}