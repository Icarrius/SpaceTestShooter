using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGun : MonoBehaviour, IShootable
{
    #region Fields
    [SerializeField]
    private Transform bulletSpawnPoint;

    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private float shootCooldown;

    private float cooldownTimer = 0f;
    #endregion

    #region Mono_Functions
    private void FixedUpdate()
    {
        if (cooldownTimer > 0) cooldownTimer -= Time.deltaTime;
    }
    #endregion

    #region Public_Functions
    public void Shoot()
    {
        if(cooldownTimer <= 0)
        {
            cooldownTimer = shootCooldown;
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.layer = transform.parent.gameObject.layer;
        }
    }
    #endregion

    #region Private_Functions
    #endregion
}
