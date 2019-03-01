using UnityEngine;
using System.IO;

public class SaveManager
{
    #region Public_Functions
    public static void LoadOrInitializeInventory()
    {
        // Save/load.
        if (File.Exists(Path.Combine(Application.persistentDataPath, "inventory.json")))
        {
            Debug.Log("Found file inventory.json, loading inventory.");
            Inventory.LoadFromJSON(Path.Combine(
                Application.persistentDataPath, "inventory.json"));
        }
        else
        {
            Debug.Log("Couldn't find inventory.json, loading from template.");
            Inventory.InitializeFromDefault();
        }
    }

    public static void SaveInventory()
    {
        Inventory.Instance.SaveToJSON(Path.Combine(
            Application.persistentDataPath, "inventory.json"));
    }

    public static void SaveGlobalMap()
    {

    }

    public static void LoadFromTemplate()
    {
        Inventory.InitializeFromDefault();
    }
    #endregion
}