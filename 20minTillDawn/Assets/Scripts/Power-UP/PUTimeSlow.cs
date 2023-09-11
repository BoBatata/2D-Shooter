using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class PUTimeSlow : MonoBehaviour
{
    [Header("PowerUp Info")]
    [SerializeField] private Button button;
    [SerializeField] private string name;
    [SerializeField] private Sprite icon;

    [Header("Prefab Child Components")]
    [SerializeField] private TextMeshProUGUI powerUPNameText;
    [SerializeField] private Image powerUpIcon;


    private void Awake()
    {
        button.onClick.AddListener(TimeStop);
        powerUpIcon.sprite = icon;
        powerUPNameText.text = name;
    }

    private void TimeStop()
    {
        GameManager.instance.TimeSlow(true);
        Time.timeScale = 1;
        UIManager.instance.SetPowerUPContainer(false);
    }
}
