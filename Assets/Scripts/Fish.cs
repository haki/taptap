using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Fish : MonoBehaviour
{
    private Rigidbody2D _rb;
    private bool _touchedGround;
    private SpriteRenderer _sr;
    private Animator _animator;

    [SerializeField] private float speed = 9f;
    [SerializeField] private int angle;
    [SerializeField] private int maxAngle = 20;
    [SerializeField] private int minAngle = -60;
    [SerializeField] private Score score;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Sprite fishDied;
    [SerializeField] private ObstacleSpawner obstacleSpawner;
    [SerializeField] private AudioSource swim;
    [SerializeField] private AudioSource hit;
    [SerializeField] private AudioSource point;
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.gravityScale = 0;
        
        _sr = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        FishSwim();
    }

    private void FixedUpdate()
    {
        FishRotation();
    }

    private void FishSwim()
    {
        if (Input.GetMouseButtonDown(0) && !GameManager.gameOver)
        {
            swim.Play();
            if (!GameManager.gameStarted)
            {
                _rb.gravityScale = 4f;
                _rb.velocity = Vector2.zero;
                _rb.velocity = new Vector2(_rb.velocity.x, speed);
                obstacleSpawner.InstantiateObstacle();
                gameManager.GameHasStarted();
            }
            else
            {
                _rb.velocity = Vector2.zero;
                _rb.velocity = new Vector2(_rb.velocity.x, speed);
            }
        }
    }

    private void FishRotation()
    {
        if (_rb.velocity.y > 0)
        {
            if (angle <= maxAngle)
            {
                angle = angle + 4;
            }
        }
        else if (_rb.velocity.y < -1.2)
        {
            if (angle > minAngle)
            {
                angle = angle - 2;
            }
        }

        if (_touchedGround == false)
        {
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Obstacle"))
        {
            score.Scored();
            point.Play();
        }
        else if (col.CompareTag("Column") && !GameManager.gameOver)
        {
            FishDieEffect();
            gameManager.GameOver();
        }
    }

    private void FishDieEffect()
    {
        hit.Play();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (!GameManager.gameOver)
            {
                FishDieEffect();
                gameManager.GameOver();
                GameOver();
            }
            else
            {
                GameOver();
            }
        }
    }

    private void GameOver()
    {
        _touchedGround = true;
        transform.rotation = quaternion.Euler(0, 0, -90);
        _sr.sprite = fishDied;
        _animator.enabled = false;
    }
}