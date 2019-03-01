using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "Items/LaserGun", fileName = "LaserGunName.asset")]
public class ItemLaserGun : Item
{
    public enum Quality
    {
        normal, rare, epic
    }

    public Quality quality;
    public int damage;
    public float fireRate;
}
