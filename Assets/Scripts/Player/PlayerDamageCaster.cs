using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageCaster : DamageCaster
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag==name)
        {
            Debug.Log("Íæ¼Ò¹¥»÷µÄÊÇ"+name);



        }



    }






}
