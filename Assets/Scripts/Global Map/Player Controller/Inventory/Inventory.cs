using UnityEngine;

[CreateAssetMenu(menuName = "Items/Inventory", fileName = "Inventory.asset")]
[System.Serializable]
public class Inventory : ScriptableObject
{
    #region Fields
    private readonly static string baseInventoryPath = "BaseInventory";
    private static Inventory instance;
    #endregion

    #region Public_Functions
    public static Inventory Instance
    {
        get
        {
            if (!instance)
            {
                Inventory[] tmp = Resources.FindObjectsOfTypeAll<Inventory>();
                if (tmp.Length > 0)
                {
                    instance = tmp[0];
                    Debug.Log("Found inventory as: " + instance);
                }
                else
                {
                    Debug.Log("Did not find inventory, loading from file or template.");
                    SaveManager.LoadOrInitializeInventory();
                }
            }

            return instance;
        }
    }

    public static void InitializeFromDefault()
    {
        if (instance) DestroyImmediate(instance);
        instance = Instantiate((Inventory)Resources.Load(baseInventoryPath));
        instance.hideFlags = HideFlags.HideAndDontSave;
    }

    public static void LoadFromJSON(string path)
    {
        if (instance) DestroyImmediate(instance);
        instance = CreateInstance<Inventory>();
        JsonUtility.FromJsonOverwrite(System.IO.File.ReadAllText(path), instance);
        instance.hideFlags = HideFlags.HideAndDontSave;
    }

    public void SaveToJSON(string path)
    {
        Debug.LogFormat("Saving inventory to {0}", path);
        System.IO.File.WriteAllText(path, JsonUtility.ToJson(this, true));
    }

    /* Inventory START */
    public ItemInstance[] inventory;

    public bool SlotEmpty(int index)
    {
        if (inventory[index] == null || inventory[index].item == null)
            return true;

        return false;
    }

    // Get an item if it exists.
    public bool GetItem(int index, out ItemInstance item)
    {
        if (SlotEmpty(index))
        {
            item = null;
            return false;
        }

        item = inventory[index];
        return true;
    }

    // Remove item at index
    public bool RemoveItem(int index)
    {
        if (SlotEmpty(index))
        {
            return false;
        }

        inventory[index] = null;

        return true;
    }

    public int InsertItem(ItemInstance item)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (SlotEmpty(i))
            {
                inventory[i] = item;
                return i;
            }
        }

        return -1;
    }
    #endregion

    #region Private_Functions
    private void Save()
    {
        SaveManager.SaveInventory();
    }
    #endregion
}
