using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrullaje : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private float distance;
    [SerializeField] private bool walksRight;
    public bool wallDetected;
    public LayerMask whatIsWall;

    private Rigidbody2D rb2D;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        RaycastHit2D checkGround = Physics2D.Raycast(groundCheck.position, Vector2.down, distance);
        wallDetected = Physics2D.OverlapCircle(wallCheck.position, distance, whatIsWall);
        rb2D.velocity = new Vector2(speed, rb2D.velocity.y);

        if (checkGround == false || wallDetected == true)
        {
            Flip();
        }
    }

    private void Flip()
    {
        walksRight = !walksRight;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        speed *= -1;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(groundCheck.transform.position, groundCheck.transform.position + Vector3.down * distance);
        Gizmos.DrawLine(wallCheck.transform.position, wallCheck.transform.position + Vector3.right * distance);
    }
}
