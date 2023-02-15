using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankConlrollerIlya : MonoBehaviour
{

 //   public Rigidbody2D rd2d;
 //   private Vector2 movementVector;
 //   public float maxSpeed = 10; //скорость
 //   public float rotationSpeed = 100; //скорость вращения танка
 //   public float turretRotationSpeed = 150; //скорость вращения турели
    [SerializeField] private float speedBullet;
 //   private float smokeStep=1;   //количество дыма

    public Transform turretParent;
    //public transform firepoint;

    public GameObject projectilePrefab;
    //public ParticleSystem smokeEffect;

    public TankMoverPlayer tankMover;
    public AimTurretPlayer aimTurretPlayer;
    public GunPlayer[] gunPlayers;


    // переменные для из прееноса инпута
    private Camera mainCamera;
  //  public float timeReload;
   // private bool reload; нужно перенести в скрипт выстрела
   // private float currentTimeReload;

       

    private void Awake()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;

        if (tankMover == null)
            tankMover = GetComponentInChildren<TankMoverPlayer>();

        if (aimTurretPlayer == null)
            aimTurretPlayer = GetComponentInChildren<AimTurretPlayer>();

        if (gunPlayers == null || gunPlayers.Length == 0)
        {
            gunPlayers = GetComponentsInChildren<GunPlayer>();
        }
        // rd2d = GetComponent<Rigidbody2D>();

    }


    public void FixedUpdate()
    {
        Vector2 movementVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        tankMover.Move(movementVector);


        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = mainCamera.nearClipPlane;
        Vector2 mouseWorldPosition = mainCamera.ScreenToWorldPoint(mousePosition);
        // return mouseWorldPosition;
        aimTurretPlayer.Aim(mouseWorldPosition);


        if (Input.GetMouseButtonDown(0)) // нажимаем лкл - выстрел
        {
            gunPlayers[0].shoot();
            // делаем выстрел

        }

    }


    public void HandleShoot()
    {
        foreach (var gunPlayer in gunPlayers)
        {
            gunPlayer.shoot();
        }
        //GameObject projectileOdject = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        //var bullet = projectileOdject.GetComponent<Rigidbody2D>();
        //bullet.AddForce(firePoint.up * speedBullet, ForceMode2D.Impulse);
        //Debug.Log("Shooting");

    }
    

    public void HandleMoveBody(Vector2 movementVector)
    {
        tankMover.Move(movementVector);
     //   this.movementVector = movementVector; 
        //if (movementVector.x !=0 || movementVector.y !=0)
        //{
        //    SmokeEffect(smokeStep,true);
        //}    
        //else
        //{
        //    SmokeEffect(smokeStep);
        //}    
    }

    public void HandleTurretMovement(Vector2 pointerPosition)
    {
        aimTurretPlayer.Aim(pointerPosition);

     //   var turretDirection = (Vector3)pointerPosition - turretParent.position;
     //   var desiredAngle = Mathf.Atan2(turretDirection.y, turretDirection.x) * Mathf.Rad2Deg;
     //   var rotatrionStep = turretRotationSpeed * Time.deltaTime;
     //   turretParent.rotation = Quaternion.RotateTowards(turretParent.rotation, Quaternion.Euler(0, 0, desiredAngle), rotatrionStep);
    }

   // private void FixedUpdate()
  //  {
  //      rd2d.velocity = (Vector2)transform.up * movementVector.y * maxSpeed * Time.fixedDeltaTime;
  //      rd2d.MoveRotation(transform.rotation * Quaternion.Euler(0, 0, -movementVector.x * rotationSpeed * Time.fixedDeltaTime));
  //  }

    //public override void SetDamage(float damage)
    //{
    //    base.SetDamage(damage);
    //    //UI.instance.SetValue(_currentHpObject/_maxHp);
    //    smokeStep = _maxHp / _currentHpObject*3;
    //    SmokeEffect(smokeStep);
    //    UI.instance.SetValue(_currentHpObject / (float)_maxHp);
    //}
    //public override void SetHeal(float heal)
    //{
    //    base.SetHeal (heal);
    //    smokeStep = _maxHp / _currentHpObject * 3;
    //    SmokeEffect(smokeStep);
    //    UI.instance.SetValue(_currentHpObject / (float)_maxHp);
    //    //  UI.instance.SetValue(_currentHpObject / _maxHp);
    //    // smokeStep = _maxHp / _currentHpObject * 3;
    //    // var emission = smokeEffect.emission;
    //    // emission.rateOverTime = smokeStep;
    //}

    //private void SmokeEffect (float valueSmoke, bool gus=false)
    //{
    //    var emission = smokeEffect.emission;
    //    if (!gus)
    //    {
    //        emission.rateOverTime = valueSmoke;
    //    }
    //    else
    //    {
    //        emission.rateOverTime = valueSmoke*2f;
    //    }
    //}
}

