using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    
    public float X, Y;
    public bool IsJump;
    public bool IsAttack;
    public bool IsRoll;
    public bool JumpAttacking;
    void Update()
    { 
        X = Input.GetAxisRaw("Horizontal");
        Y = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.W)&& !IsJump)
        {
            IsJump = Input.GetKeyDown(KeyCode.W);
        }
        if (Input.GetKeyDown(KeyCode.J)&& !IsAttack)
        {
            IsAttack = Input.GetKeyDown(KeyCode.J);

        }
        if (Input.GetKeyDown(KeyCode.Space) && !IsRoll)
        {
            IsRoll = Input.GetKeyDown(KeyCode.Space);
        }
        if (Input.GetKeyDown(KeyCode.K) && !JumpAttacking)
        {
            JumpAttacking = Input.GetKeyDown(KeyCode.K);
        }


    }
}
