using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)  
    {
        if(collision.tag == "Player")  // Eðer benim bu kodu verdiðim nesne Player etiketli bir nesne ile temas ederse life deðerini 1 arttýr. ve bu nesneyi yok et. life deðeri 3 den büyükse deðer arttýrma !
        {
            if(collision.gameObject.GetComponent<Player>().life < 3 )
            {
                collision.gameObject.GetComponent<Player>().life++;
                collision.gameObject.GetComponent<Player>().UpdateLifeText();
                Destroy(gameObject);
            }
        }
    }



}