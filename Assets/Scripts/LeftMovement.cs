using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    private BoxCollider2D _box;
    private float _groundWidth;
    private float _obstacleWidth;

    private void Start()
    {
        if (gameObject.CompareTag("Ground"))
        {
            _box = GetComponent<BoxCollider2D>();
            _groundWidth = _box.size.x;
        }
        else if (gameObject.CompareTag("Obstacle"))
        {
            _obstacleWidth = GameObject.FindGameObjectWithTag("Column").GetComponent<BoxCollider2D>().size.x;
        }
    }

    private void Update()
    {
        if (GameManager.gameOver ==  false)
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }

        if (gameObject.CompareTag("Ground"))
        {
            if (transform.position.x <= -_groundWidth)
            {
                transform.position = new Vector2(transform.position.x + 2 * _groundWidth, transform.position.y);
            }
        }
        else if (gameObject.CompareTag("Obstacle"))
        {
            if (transform.position.x < GameManager.BottomLeft.x - _obstacleWidth)
            {
                Destroy(gameObject);
            }
        }
    }
}