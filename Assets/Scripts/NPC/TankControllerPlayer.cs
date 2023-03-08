using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TankControllerPlayer : MonoBehaviour
{
    [SerializeField] private ITankMoveController _tankMoveNps;
    [SerializeField] private ITurretRotation _tankTurretNps;
    private Camera mainCamera;

    private void Awake()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;

        if (_tankMoveNps == null)
            _tankMoveNps = GetComponentInChildren<ITankMoveController>();

        if (_tankTurretNps == null)
            _tankTurretNps = GetComponentInChildren<ITurretRotation>();
    }

    private void Update()
    {
        Vector2 movementVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        _tankMoveNps.Move(movementVector);

        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = mainCamera.nearClipPlane;
        Vector2 mouseWorldPosition = mainCamera.ScreenToWorldPoint(mousePosition);
        _tankTurretNps.RotationTurret(mouseWorldPosition);
        
        if (Input.GetMouseButtonDown(0)) this.GetComponentInChildren<GunsController>().GunsShoot();
    }
}
