//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class NPCTankController : MonoBehaviour
//{

//    [SerializeField] private float speedBullet;

//    public Transform turretParent;

//    public GameObject projectilePrefab;

//    public TankMoverPlayer tankMover;
//    public AimTurretPlayer aimTurretPlayer;
//    public GunPlayer[] gunPlayers;


//    // переменные для из прееноса инпута
//    private Camera mainCamera;



//    private void Awake()
//    {
//        if (mainCamera == null)
//            mainCamera = Camera.main;

//        if (tankMover == null)
//            tankMover = GetComponentInChildren<TankMoverPlayer>();

//        if (aimTurretPlayer == null)
//            aimTurretPlayer = GetComponentInChildren<AimTurretPlayer>();

//        if (gunPlayers == null || gunPlayers.Length == 0)
//        {
//            gunPlayers = GetComponentsInChildren<GunPlayer>();
//        }

//    }




//    public void Update()
//    {
//        //Vector2 movementVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
//        //tankMover.Move(movementVector);

//        //Vector3 mousePosition = Input.mousePosition;
//        //mousePosition.z = mainCamera.nearClipPlane;
//        //Vector2 mouseWorldPosition = mainCamera.ScreenToWorldPoint(mousePosition);
//        //aimTurretPlayer.Aim(mouseWorldPosition);

//        //if (Input.GetMouseButtonDown(0)) // нажимаем лкл - выстрел
//        //{
//        //    gunPlayers[0].Shoot();

//        //}

//    }

//    public void FixedUpdate()
//    {
//        if (_enemies.Count > 0)
//        {
//            if (_player != null)
//            {
//                var turretDirection = _player.position - turretParent.position;

//                var desiredAngle = Mathf.Atan2(turretDirection.y, turretDirection.x) * Mathf.Rad2Deg;

//                var rotatrionStep = turretRotationSpeed * Time.fixedDeltaTime;
//                turretParent.rotation = Quaternion.RotateTowards(turretParent.rotation,
//                Quaternion.Euler(0, 0, desiredAngle), rotatrionStep);


//                if (Quaternion.Angle(turretParent.rotation, Quaternion.Euler(0, 0, desiredAngle)) < 15)
//                {
//                    TowerGun();
//                }

//            }
//        }
//    }

//    public void HandleShoot()
//    {
//        foreach (var gunPlayer in gunPlayers)
//        {
//            gunPlayer.Shoot();
//        }
//    }


//    public void HandleMoveBody(Vector2 movementVector)
//    {
//        tankMover.Move(movementVector);
//    }

//    public void HandleTurretMovement(Vector2 pointerPosition)
//    {
//        aimTurretPlayer.Aim(pointerPosition);

//    }
//}
