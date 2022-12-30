using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public float speed = 3f;
    public float followRadius = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        // D��man objesi karakterimize do�ru hareket etmelidir
        float distance = Vector2.Distance(transform.position, player.position);
        if (distance <= followRadius)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }


    }








}

