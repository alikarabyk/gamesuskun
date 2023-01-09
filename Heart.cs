using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)  
    {
        if(collision.tag == "Player")  // E�er benim bu kodu verdi�im nesne Player etiketli bir nesne ile temas ederse life de�erini 1 artt�r. ve bu nesneyi yok et. life de�eri 3 den b�y�kse de�er artt�rma !
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