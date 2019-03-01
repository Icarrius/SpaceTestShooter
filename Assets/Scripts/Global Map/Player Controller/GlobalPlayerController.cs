using UnityEngine;

public class GlobalPlayerController : MonoBehaviour
{
    #region Fields
    private bool inAction = false;
    private GlobalMapMovement movementController;

    [System.Serializable]
    private struct PlayerCoordinates
    {
        public int X { get; set; }
        public int Z { get; set; }

        public PlayerCoordinates(int x, int z)
        {
            X = x;
            Z = z;
        }

        public void SetCoordinates(int x, int z)
        {
            X = x;
            Z = z;
        }
    }

    private PlayerCoordinates currentCoordinates;
    #endregion

    #region Mono_Functions
    private void Start()
    {
        InitializeShip(0, 0);
        movementController = GetComponent<GlobalMapMovement>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit) && hit.collider.CompareTag("Cell"))
            {
                Cell cell = hit.collider.GetComponent<Cell>();
                if (movementController.MoveToCell(cell))
                {
                    currentCoordinates.SetCoordinates(cell.cellProperties.X, cell.cellProperties.Z);
                    cell.ActivateEvent();
                }
            }
        }
    }
    #endregion

    #region Public_Functions
    public void InitializeShip(int x, int y)
    {
        if (!CheckIfCoordinatesExists(x, y))
            return;

        currentCoordinates = new PlayerCoordinates(x, y);
    }
    #endregion

    #region Private_Functions
    private bool CheckIfCoordinatesExists(int x, int y)
    {
        int mapRows = MapGenerator.instance.mapRows;
        int mapColumns = MapGenerator.instance.mapColumns;

        if (x < mapRows && x >= 0 && y < mapColumns && y >= 0)
        {
            return true;
        }
        else
        {
            Debug.LogError(string.Format("Coordinates [{0},{1}] do not exists!", x, y));
            return false;
        }
    }
    #endregion
}
