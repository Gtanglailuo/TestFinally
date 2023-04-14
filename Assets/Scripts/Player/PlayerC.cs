using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerC : MonoBehaviour
{

    public bool IsAirAttack;
    private PlayerInput _playerInput;

    private PlayerAni _playerAni;

    private Rigidbody2D ri;

    public Vector2 dir;
    public bool isGround;
    public float speed,distance;
    public LayerMask layer;
    public Vector2 vec1, vec2;
    public float jumpForce, fallMultiplier, lowJumpMultiplier;
    public enum PlayerState 
    {
        Normal,Jump,Attack,Hurt,Death,Roll
    }
    public PlayerState curState;
    private void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        ri = GetComponent<Rigidbody2D>();
        _playerAni = GetComponentInChildren<PlayerAni>();
        curState = PlayerState.Normal;
    }
    private void Update()
    {
        dir.Set(_playerInput.X, _playerInput.Y);
        Face(_playerInput.X);
        isGround = IsGround();

        if (_playerInput.IsJump && isGround)
        {
            curState = PlayerState.Jump;         
        }
        if (_playerInput.IsAttack&&isGround)
        {
            curState = PlayerState.Attack;
        }

    }
    private void FixedUpdate()
    {
        switch (curState)
        {
            case PlayerState.Normal:
                break;
            case PlayerState.Jump:
                Jump();
                break;
            case PlayerState.Attack:
                _playerAni.Attacking();
                break;
            case PlayerState.Hurt:
                break;
            case PlayerState.Death:
                break;
            case PlayerState.Roll:
                break;
            default:
                break;
        }  
        Move();
    }

    private void Move()
    {
        if (_playerInput.IsAttack&&isGround)
        {
            _playerAni.ClearAllAnimator();
            _playerInput.IsJump = false;
            ri.velocity = Vector2.zero;
            return;
        }
        ri.velocity = new Vector2(dir.x * speed, ri.velocity.y);
        _playerAni.IdleToRun();
    }
    void Jump()
    {
        
        if (_playerInput.IsJump && isGround)
        {
            ri.velocity = Vector2.up * jumpForce;
        }
        

            if (ri.velocity.y < 0)//œ¬
            {
                ri.velocity += Vector2.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
                if (_playerInput.JumpAttacking && !isGround && !this.GetComponentInChildren<Animator>().GetCurrentAnimatorStateInfo(0).IsName("AirAttack"))
                {
                    Debug.Log("Ã¯‘æ");
                    _playerAni.JumpAttacking(true);
                }
                else
                {
                    _playerAni.UpToDown();
                }

            }
            else if (ri.velocity.y > 0)//…œ
            {
                ri.velocity += Vector2.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
                if (_playerInput.JumpAttacking && !isGround && !this.GetComponentInChildren<Animator>().GetCurrentAnimatorStateInfo(0).IsName("AirAttack"))
                {
                    Debug.Log("Ã¯‘æ");
                    _playerAni.JumpAttacking(true);
                }
                else
                {
                    _playerAni.IdleToUp();
                }
                
            }
        if (isGround)
        {
            _playerAni.DownToIdle();
            
        }
        _playerInput.IsJump = false;
    }
    public bool IsGround()
    {
        Vector2 pos = new Vector2(transform.position .x,transform.position.y);
        Ray2D ray1 = new Ray2D(pos + vec1, Vector2.down);
        Ray2D ray2 = new Ray2D(pos + vec2, Vector2.down);

        bool is1= Physics2D.Raycast(ray1.origin,ray1.direction, distance, layer);
        bool is2= Physics2D.Raycast(ray2.origin,ray2.direction, distance, layer);

        Debug.DrawLine(ray1.origin, ray1.origin+ray1.direction* distance, Color.red);
        Debug.DrawLine(ray2.origin, ray2.origin + ray2.direction * distance, Color.red);

        return is1||is2;
    }

    void Face(float x)
    {
        if (x != 0)
        {
            transform.localScale = new Vector3(1* x, 1, 1);
        }
    }

}
