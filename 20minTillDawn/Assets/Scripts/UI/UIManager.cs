using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [Header ("Containers")]
    [SerializeField] private Transform powerUpContainer;

    [Header ("TopView-Texts")]
    [SerializeField] private TextMeshProUGUI lifesText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI xpInfoText;
    [SerializeField] private TextMeshProUGUI currentLevelXP;

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
        SetupUI();
        #endregion
    }

    private void SetupUI()
    {
        lifesText.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(true);

        SetPowerUPContainer(false);
    }
    public void SetPowerUPContainer(bool isActive)
    {
        powerUpContainer.gameObject.SetActive(isActive);
    }

    public void SetScoreText(int updatedScore)
    {
        scoreText.text = "Score: " + updatedScore;
    }

    public void SetLifesText(int updatedLife)
    {
        lifesText.text = "Lifes: " + updatedLife;
    }

    public void SetXPInfoText(int curretXP, int toLevelUpXP)
    {
        xpInfoText.text = "XP: " + curretXP + " / " + toLevelUpXP;
    }

    public void SetPlayerLevelText(int newLevel)
    {
        currentLevelXP.text = "Level: " + newLevel.ToString();
    }

}
