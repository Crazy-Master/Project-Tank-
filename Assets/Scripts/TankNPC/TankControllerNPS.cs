using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankControllerNPS : MonoBehaviour
{
    [SerializeField] private TankBaseNPS _tankBaseNps;
    [SerializeField] private TankTurretNPS _tankturretNps;
    private Camera mainCamera;
    
    private void Awake()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;
    }
    private void FixedUpdate()
    {
        Vector2 movementVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        _tankBaseNps.MoveBase(movementVector);
        
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = mainCamera.nearClipPlane;
        Vector2 mouseWorldPosition = mainCamera.ScreenToWorldPoint(mousePosition);
        _tankturretNps.HandleTurretMovement(mouseWorldPosition);
    }
    
       
    
}
