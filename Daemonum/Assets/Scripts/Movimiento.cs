using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    
    public Rigidbody rigidbody;
    public float moveSpeed;

    private Vector2 moveInput;
    // Start is called before the first frame update
    void Start()
    {
        
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        moveInput.Normalize();
        
        rigidbody.velocity = new Vector3(-moveInput.x * moveSpeed, rigidbody.velocity.y, -moveInput.y * moveSpeed);

    }
}
