using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PUMultiShoot : MonoBehaviour
{

    private bool powerUpIsGet = false;

    [Header("PowerUp Info")]
    [SerializeField] private Button button;
    [SerializeField] private string name;
    [SerializeField] private Sprite icon;

    [Header("Prefab Child Components")]
    [SerializeField] private TextMeshProUGUI powerUPNameText;
    [SerializeField] private Image powerUpIcon;


    private void Awake()
    {
        button.onClick.AddListener(MultiBullet);
        powerUpIcon.sprite = icon;
        powerUPNameText.text = name;
    }

    private void Update()
    {
        if (powerUpIsGet == true)
        {
            button.gameObject.SetActive(false);
        }
    }

    private void MultiBullet()
    {
            PlayerWeapon.instance.MultiShotOn(true);
            Time.timeScale = 1;
            UIManager.instance.SetPowerUPContainer(false);
            powerUpIsGet = true;
    }
}
