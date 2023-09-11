using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static Enemy instance;

    private float velocity;
    private float slowVelocity;
    private float currentVelocity;
    private bool powerUpOn;
    private int lives;
    private Transform enemyTransform;

    private Vector2 targetPosition;

    private void Awake()
    {
        velocity = GameManager.instance.GetEnemyVelocity();
        slowVelocity = GameManager.instance.GetSlowVelocity(); ;
        currentVelocity = GameManager.instance.GetCurrentVelocity();
        enemyTransform = GetComponent<Transform>();
    }
    void Update()
    {

        targetPosition = PlayerInfo.instance.GetPlayerPosition();
        enemyTransform.position = Vector3.MoveTowards(enemyTransform.position, targetPosition, currentVelocity * Time.deltaTime);

    }
}