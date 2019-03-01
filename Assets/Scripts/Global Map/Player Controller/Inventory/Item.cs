using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public abstract class Item : ScriptableObject
{
    public enum ItemType
    {
        LaserGun, RocketGun
    }

    public string itemName;
    public ItemType itemType;
    public Image itemImage;
}

[System.Serializable]
public class ItemInstance
{
    // Reference to object template
    public Item item;
    
    public ItemInstance(Item item)
    {
        this.item = item;
        this.item.itemType = item.itemType;
    }

}
