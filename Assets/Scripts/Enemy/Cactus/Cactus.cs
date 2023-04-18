using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactus : MonoBehaviour
{
    public GameObject obj;
    public Transform point;
    public float attackDuration;
    private Animator animator;
    public float duration,time;
    public bool Attacking;

    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("IsAttack", false);
    }

    private void Update()
    {
        if (Attacking)
        {
            time += Time.deltaTime;
            if (time>=duration)
            {
                animator.SetBool("IsAttack",true);
                //当这个攻击动画播放完成之后等待一段时间然后继续播放


                time = 0;
            }
            
        } 
        else
        {
            animator.SetBool("IsAttack", false);
            time = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Player")
        {
            Attacking = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Attacking = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Attacking = false;
        }
    }
    public void CreateSpike()
    {
        GameObject spike = Instantiate(obj,point);
    }


    



}
