using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankControllerNPS : MonoBehaviour
{
    [SerializeField] private TankMoveNPS _tankMoveNps;
    [SerializeField] private TankTurretNPS _tankTurretNps;
    [SerializeField] private TankGunNPS[] _tankGunNps;
    private Camera mainCamera;

    private void Awake()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;

        if (_tankMoveNps == null)
            _tankMoveNps = GetComponentInChildren<TankMoveNPS>();

        if (_tankTurretNps == null)
            _tankTurretNps = GetComponentInChildren<TankTurretNPS>();

        if (_tankGunNps == null || _tankGunNps.Length == 0)
        {
            _tankGunNps = GetComponentsInChildren<TankGunNPS>();
        }
    }

    private void Update()
    {
        Vector2 movementVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        _tankMoveNps.MoveBase(movementVector);

        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = mainCamera.nearClipPlane;
        Vector2 mouseWorldPosition = mainCamera.ScreenToWorldPoint(mousePosition);
        _tankTurretNps.HandleTurretMovement(mouseWorldPosition);
        
        if (Input.GetMouseButtonDown(0)) HandleShoot();
    }

    public void HandleShoot()
    {
        foreach (var tankGunNPS in _tankGunNps)
        {
            tankGunNPS.Shoot();
        }
    }
}
