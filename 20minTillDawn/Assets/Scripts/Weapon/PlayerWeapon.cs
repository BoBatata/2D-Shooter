using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public static PlayerWeapon instance;

    private Transform aimTransform;
    private bool multiShootOn;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform weapon;
    [SerializeField] private Transform extraBulletRight, extraBulletLeft;

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
        aimTransform = GetComponent<Transform>();
    }


    private void Update()
    {
        AimHandler();
        ShootingHandler();
    }

    private void AimHandler()
    {
        Vector3 mousePosition = GameManager.instance.GetMousePosition();
        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angle); 
    }

    private void ShootingHandler()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(bulletPrefab, weapon.position, weapon.rotation);
            MultiShotOn(multiShootOn);
        }
    }

    public void MultiShotOn(bool powerUpOn)
    {

        if (powerUpOn == true)
        {
            multiShootOn = true;
            Instantiate(bulletPrefab, extraBulletRight.position, weapon.rotation);
            Instantiate(bulletPrefab, extraBulletLeft.position, weapon.rotation);
        }
    }

}
