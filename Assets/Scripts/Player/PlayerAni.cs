using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAni : MonoBehaviour
{
    private Animator ani;
    private PlayerInput _playerInput;
    private PlayerC _playerC;
    private void Start()
    {
        ani = GetComponent<Animator>();
        _playerInput = GetComponentInParent<PlayerInput>();
        _playerC = GetComponentInParent<PlayerC>();
    }

    public void IdleToRun()
    {
        ani.SetFloat("IsRun", Mathf.Abs(_playerInput.X));
    }
    public void IdleToUp()
    {
        ani.SetBool("IsUp", true) ;
        ani.SetBool("IsDown", false);
        ani.SetBool("IsGround", false);

    }

    public void UpToDown()
    {
        ani.SetBool("IsDown", true);
        ani.SetBool("IsUp", false);
    }

    public void DownToIdle()
    {
        ani.SetBool("IsDown", false);
        ani.SetBool("IsGround", true);
    }

    public void Attacking()
    {
        ani.SetTrigger("IsAttack");
    }

    public void AttackEventEnd()
    {
        //GetComponentInParent<PlayerC>().curState = PlayerC.PlayerState.Normal;
        _playerInput.IsAttack = false;
        ani.ResetTrigger("IsAttack");
        Debug.Log("¹¥»÷½áÊø");
    }
    public void JumpAttackEventEnd()
    {
        _playerInput.JumpAttacking = false;
    }
    public void JumpAttacking(bool a)
    {
        ani.SetBool("JumpAttack", a);
    }

    public void ClearAllAnimator()
    {
        ani.SetBool("IsUp", false);
        ani.SetBool("IsDown", false);
        ani.SetBool("IsGround", false);
        ani.SetBool("JumpAttack", false);
    }

}
