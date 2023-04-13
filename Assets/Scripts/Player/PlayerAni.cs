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
        ani.SetBool("IsFly", false);
    }

    public void IdleToRun()
    {
        ani.SetFloat("IsRun", Mathf.Abs(_playerInput.X));
    }
    public void IdleToUp()
    {
        ani.SetBool("IsUp", true) ;
        ani.SetBool("IsFly", true);
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
        ani.SetBool("IsDimian",this.GetComponentInParent<PlayerC>().isGround);
    }
    public void AttackingAir()
    {
        //_playerC.curState = PlayerC.PlayerState.Jump;
        ani.SetTrigger("IsAttack");
    }
    public void AttackEventEnd()
    {
        _playerC.curState = PlayerC.PlayerState.Normal;
        _playerInput.IsAttack = false;
        ani.ResetTrigger("IsAttack");
        Debug.Log("¹¥»÷½áÊø");
    }

    public void AttackFlyEventEnd()
    {
        _playerInput.IsAirAttack = false;
        ani.ResetTrigger("IsAttack");
        Debug.Log("ÌøÔ¾¹¥»÷½áÊø");
    }

    public void IsNotFly()
    {
        ani.SetBool("IsFly", false);
    }
    public void IsFly()
    {
        ani.SetBool("IsFly", true);
    }

}
