﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{   

    Rigidbody2D body;

    float horizontal;
    float vertical;
    bool lookingRight; // bool = boolean

    [Tooltip("Velocidad")]
    public float runSpeed = 20.0f;
    
    // Start is called before the first frame update
    void Start() {
        body = GetComponent<Rigidbody2D>();

        this.lookingRight = true;
    }

    void Update () {
        // Edit -> Project Settings -> Input Manager -> Axes
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if ((horizontal == 1 && !lookingRight) || (horizontal == -1 && lookingRight)) {
            this.Flip();
        }
    }

    void FixedUpdate() {  
        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }

        // Flip() - so that the object looks away
    void Flip() {
        lookingRight = !lookingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}






