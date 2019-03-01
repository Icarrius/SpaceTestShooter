using UnityEngine;

public class Cell : MonoBehaviour
{
    #region Fields
    [System.Serializable]
    public struct CellProperties
    {
        public int X { get; set; }
        public int Z { get; set; }
        public EventType EventType { get; set; }

        public CellProperties(int x, int z, EventType eventType)
        {
            X = x;
            Z = z;
            EventType = eventType;
        }

        public override string ToString()
        {
            return string.Format("[X: {0} | Z: {1}]", X, Z);
        }
    }

    public enum EventType
    {
        Nothing, Event, Loot, Fight
    }

    public CellProperties cellProperties;
    #endregion

    #region Public_Functions
    public void ActivateEvent()
    {
        Debug.LogFormat("Activated event {0} at cell {1}", cellProperties.EventType, cellProperties.ToString());
    }

    public void GenerateCell(EventType _event, int x, int z)
    {
        cellProperties = new CellProperties(x, z, _event);
        GenerateEvent();
    }
    #endregion

    #region Private_Functions
    private void GenerateEvent()
    {

    }
    #endregion
}
