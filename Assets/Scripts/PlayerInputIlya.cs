using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInputIlya : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;
    public UnityEvent OnShoot = new UnityEvent();
    public UnityEvent<Vector2> OnMoveBody = new UnityEvent<Vector2>();
    public UnityEvent<Vector2> OnMoveTurret = new UnityEvent<Vector2>();
    public float timeReload;
    private bool reload;
    private float currentTimeReload;

    private void Awake()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;
    }

   
    void Update()
    {
        GetBodyMovement();
        GetTurretMovement();
        GetShootingInput();


        currentTimeReload -= Time.deltaTime;
       // Debug.Log(currentTimeReload);
        if (currentTimeReload < 0)
        {
            reload = true;
        }
    }

    private void GetShootingInput()
    {
        if (Input.GetMouseButtonDown(0) && reload)
        {
            OnShoot?.Invoke();
            reload = false;
            currentTimeReload = timeReload;
        }
    }

    private void GetTurretMovement()
    {
        OnMoveTurret?.Invoke(GetMousePosition());
    }

    private Vector2 GetMousePosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = mainCamera.nearClipPlane;
        Vector2 mouseWorldPosition = mainCamera.ScreenToWorldPoint(mousePosition);
        return mouseWorldPosition;
    }

    private void GetBodyMovement()
    {
        Vector2 movementVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        OnMoveBody?.Invoke(movementVector.normalized);
    }
}