using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    public int speedRotation =100;
    public Vector2 move;
    public int speed = 2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
            transform.Rotate(0,0, speedRotation*Time.deltaTime);

        if (Input.GetKey(KeyCode.D))
            transform.Rotate(0, 0, -speedRotation * Time.deltaTime);

        if (Input.GetKey(KeyCode.W))
            transform.Translate(Vector2.down * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.S))
            transform.Translate(Vector2.up * Time.deltaTime);
    }
    
    // public float moveSpeed;
    //
    // Rigidbody2D rigidbody2d;
    // // Start is called before the first frame update
    // void Start()
    // {
    //     rigidbody2d = GetComponent<Rigidbody2D>();
    // }
    //
    // // Update is called once per frame
    // void Update()
    // {
    //     float horizontal = Input.GetAxis("Horizontal");
    //     float vertical = Input.GetAxis("Vertical");
    //     
    //     Vector2 position = rigidbody2d.position;      
    //     position.x = position.x + moveSpeed * horizontal * Time.deltaTime;
    //     position.y = position.y + moveSpeed * vertical * Time.deltaTime;
    //
    //     rigidbody2d.MovePosition(position);
    // }
}
