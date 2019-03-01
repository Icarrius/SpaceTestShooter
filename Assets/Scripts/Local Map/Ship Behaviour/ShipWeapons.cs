using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipWeapons : MonoBehaviour {

    #region Fields
    [SerializeField]
    private GameObject[] weaponSlots;

    private IShootable[] weapons;
    private List<int> activeWeapons = new List<int>();
    #endregion

    #region Mono_Functions
    private void Start () {
        weapons = new IShootable[weaponSlots.Length];
        for(int i = 0; i < weaponSlots.Length; i++)
        {
            if (weaponSlots[i].GetComponentInChildren<IShootable>() != null)
            {
                weapons[i] = weaponSlots[i].GetComponentInChildren<IShootable>();
                activeWeapons.Add(i);
            }
        }
	}
    #endregion

    #region Public_Functions
    public void ShootFromActiveWeapons()
    {
        foreach (int i in activeWeapons) weapons[i].Shoot();
    }
    #endregion

    #region Private_Functions
    #endregion
}
