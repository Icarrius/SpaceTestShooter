using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    #region Fields
    private Movement movementController;
    private ShipWeapons weaponController;
    #endregion

    #region Mono_Functions
    void Start () {
        movementController = gameObject.GetComponent<Movement>();
        weaponController = gameObject.GetComponent<ShipWeapons>();
	}

    void Update () {
        movementController.ChangeAcceleration(Input.GetAxisRaw("Vertical"));

        if(Input.GetAxisRaw("Vertical") >= 0)
            movementController.ChangeRotation(Input.GetAxisRaw("Horizontal"));
        else
            movementController.ChangeRotation(-Input.GetAxisRaw("Horizontal"));

        if (Input.GetKey(KeyCode.Space))
            weaponController.ShootFromActiveWeapons();
    }
    #endregion

    #region Public_Functions
    #endregion

    #region Private_Functions
    #endregion
}
