using System.Collections;
using UnityEngine;

public class GlobalMapMovement : MonoBehaviour
{
    #region Fields
    private bool moving;
    #endregion

    #region Public_Functions
    /// <summary>
    /// Move ship to the cell
    /// </summary>
    /// <param name="cell">Targeted cell</param>
    /// <returns>Is moving succesfull?</returns>
    public bool MoveToCell(Cell cell)
    {
        if (!moving)
        {
            StartCoroutine(MoveTo(cell.transform.position));
            return true;
        }
        else
        {
            return false;
        }
    }
    #endregion

    #region Private_Functions
    private IEnumerator MoveTo(Vector3 cellPosition)
    {
        moving = true;

        Vector3 startPos = transform.position;
        Vector3 endPos = new Vector3(cellPosition.x, 1, cellPosition.z);

        Vector3 targetDir = endPos - startPos;
        transform.rotation = Quaternion.LookRotation(targetDir);

        yield return new WaitForSeconds(0.5f);

        float timeToStart = Time.time;
        while (Vector3.Distance(transform.position, endPos) > 0)
        {
            transform.position = Vector3.Lerp(startPos, endPos, (Time.time - timeToStart) * 1.5f);
            yield return null;
        }

        moving = false;
    }
    #endregion
}
