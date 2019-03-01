using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    #region Fields
    public static MapGenerator instance;

    [SerializeField]
    private GameObject cellPrefab;

    public int mapRows = 1, mapColumns = 1;

    private List<Cell> cellsList = new List<Cell>();
    private float cellSize = 1;
    #endregion

    #region Mono_Functions
    private void Awake()
    {
        if (instance == null) instance = this;
    }

    void Start()
    {
        cellSize = cellPrefab.transform.localScale.x;
        GenerateMap(mapRows, mapColumns);     
    }
    #endregion

    #region Private_Functions
    private void GenerateMap(int rows, int columns)
    {
        for(int row = 0; row < rows; row++)
        {
            for(int column = 0; column < columns; column++)
            {
                Vector3 cellPosition = new Vector3(cellSize * 10 * row, 0, cellSize * 10 * column);
                Cell generatedCell = Instantiate(cellPrefab, cellPosition, Quaternion.identity, transform).GetComponent<Cell>();
                Cell.EventType eventType = GenerateEvent();
                generatedCell.GenerateCell(eventType, row, column);
                cellsList.Add(generatedCell);
            }
        }
    }

    private Cell.EventType GenerateEvent()
    {
        float randomFloat = Random.value;

        if(randomFloat < 0.6)
            return Cell.EventType.Nothing;
        else
            return Cell.EventType.Event;
    }
    #endregion
}
