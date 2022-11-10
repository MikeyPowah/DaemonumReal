using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    
    public Rigidbody rigidbody;
    public float moveSpeed;
    [SerializeField] private InteractionPromptUI _interactionPromptUI;
    private Vector2 moveInput;
    // Start is called before the first frame update
    void Start()
    {
        
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!_interactionPromptUI.IsDisplayed) _interactionPromptUI.Open();
            else _interactionPromptUI.Close();
        }else if (!_interactionPromptUI.IsDisplayed){
            moveInput.x = Input.GetAxisRaw("Horizontal");
            moveInput.y = Input.GetAxisRaw("Vertical");
            moveInput.Normalize();
            
            rigidbody.velocity = new Vector3(-moveInput.x * moveSpeed, rigidbody.velocity.y, -moveInput.y * moveSpeed);
        }
        

    }
}
