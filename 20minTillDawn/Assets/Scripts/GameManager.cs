using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private int gameScore = 0;
    private int playerLifes = 0;
    [SerializeField] private float enemyVelocity = 5;
    [SerializeField] private float slowVelocity = 1;
    [SerializeField] private float currentVelocity = 5;

    private void Awake()
    {
        #region Singleton
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        #endregion
    }

    public Vector3 GetMousePosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mousePosition.z = 0;
        return mousePosition;
    }

    public int GetGameScore() 
    {
        return gameScore;
    }

    public void SetGameScore(int score)
    {
        gameScore += score;
        PlayerInfo.instance.SetCurrentXP(score);
        UIManager.instance.SetScoreText(gameScore);
    }

    public void SetPlayerLife(int life)
    {
        playerLifes = life;
        UIManager.instance.SetLifesText(playerLifes);
    }

    public void SetLevelInfo(int playerLevel, int currentXP, int toLevelUpXP)
    {
        UIManager.instance.SetXPInfoText(currentXP, toLevelUpXP);
        UIManager.instance.SetPlayerLevelText(playerLevel);
    }

    public void OnLevelUP()
    {
        Time.timeScale = 0;
        UIManager.instance.SetPowerUPContainer(true);
        
    }

    public float GetEnemyVelocity()
    {
        return enemyVelocity;
    }

    public float GetSlowVelocity()
    {
        return slowVelocity;
    }

    public float GetCurrentVelocity()
    {
        return currentVelocity;
    }

    public void TimeSlow(bool powerUpOn)
    {
        print("deu certo");
        if (powerUpOn == true)
        {
            StartCoroutine(SlowTimer());
        }

    }

    private IEnumerator SlowTimer()
    {
        currentVelocity = slowVelocity;
        yield return new WaitForSeconds(20f);
        currentVelocity = enemyVelocity;
    }
}
