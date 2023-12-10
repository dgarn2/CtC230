using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{

    public CharacterController2D controller;
    float horMove = 0f;
    public float runSpeed = 45f;
    bool jump = false;
    bool crouch = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        
        if(Input.GetButtonDown("Jump")){
            jump = true;
           
            
        }


        if(Input.GetButtonDown("Crouch")){
            crouch = true;
            
        }else if (Input.GetButtonUp("Crouch")){
            crouch = false;
        }

    }

    void FixedUpdate()
    {
        
        controller.Move(horMove * Time.fixedDeltaTime, crouch ,jump);
        jump = false;
        
    }
}
