using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPaddleController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 3f;

    public Vector2 limits = new Vector2(-4.5f, 4.5f);

    private GameObject ball;

    public bool isPlayer = true;
    public SpriteRenderer spriteRenderer;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ball = GameObject.Find("Ball");

        if (isPlayer)
            spriteRenderer.color = SaveController.Instance.colorPlayer;
        else
            spriteRenderer.color = SaveController.Instance.colorEnemy;
    }

    private void Update()
    {
        if(ball != null)
        {
            float targety = Mathf.Clamp(ball.transform.position.y, limits.x, limits.y);
            Vector2 targetPosition = new Vector2(transform.position.x, targety);
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, Time.deltaTime * speed);
        }
    }
}
