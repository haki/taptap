using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject obstacle;
    [SerializeField] private float maxTime;
    [SerializeField] private float maxY;
    [SerializeField] private float minY;
    
    private float _timer;
    private float _randomY;

    private void Start()
    {
        //InstantiateObstacle();
    }

    private void Update()
    {
        if (!GameManager.gameOver && GameManager.gameStarted)
        {
            _timer += Time.deltaTime;
            if (_timer >= maxTime)
            {
                _randomY = Random.Range(minY, maxY);
                InstantiateObstacle();
                _timer = 0f;
            }
        }
    }

    public void InstantiateObstacle()
    {
        GameObject newObstacle = Instantiate(obstacle);
        newObstacle.transform.position = new Vector2(transform.position.x, _randomY);
    }
}
