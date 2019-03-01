using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketGun : MonoBehaviour, IShootable, IReloadable
{
    #region Fields
    [SerializeField]
    private Transform bulletSpawnPoint;

    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private float shootCooldown;

    [SerializeField]
    private int shellsToReload;

    [SerializeField]
    private float reloadTime;

    private int currentShells;
    private float cooldownTimer = 0f;

    #endregion

    #region Mono_Functions
    private void Start()
    {
        currentShells = shellsToReload;
    }

    private void FixedUpdate()
    {
        if (cooldownTimer > 0) cooldownTimer -= Time.deltaTime;
    }
    #endregion

    #region Public_Functions
    public IEnumerator Reload()
    {
        currentShells = 0;
        yield return new WaitForSecondsRealtime(reloadTime);
        currentShells = shellsToReload;
    }

    public void Shoot()
    {
        if (cooldownTimer <= 0 && currentShells > 0)
        {
            if (--currentShells == 0)
            {
                StartCoroutine(Reload());
            }
            cooldownTimer = shootCooldown;
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.layer = transform.parent.gameObject.layer;
        }
    }
    #endregion

    #region Private_Functions

    #endregion
}
