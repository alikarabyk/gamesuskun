using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //c

public class Player : MonoBehaviour
{

    public float speed;
    public Rigidbody2D rigidbody;
    public float jumpSpeed;
    public Animator anim; //a
    public int life; //c 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Space) && gameObject.transform.Find("Foot").GetComponent<GroundCheck>().isGrounded )
        {
            rigidbody.AddForce(new Vector2(0, jumpSpeed));
        }
    }


    void FixedUpdate()
    {
        float hor = Input.GetAxisRaw("Horizontal");

        anim.SetFloat("Speed", Mathf.Abs(hor)); //a
        

        rigidbody.velocity = new Vector2(hor * speed, rigidbody.velocity.y); 


        if (hor > 0.1f)
        {
            gameObject.transform.localScale = new Vector3(Mathf.Abs(gameObject.transform.localScale.x), gameObject.transform.localScale.y, 0);
        }
        else if (hor < -0.1f)
        {
            gameObject.transform.localScale = new Vector3(-Mathf.Abs(gameObject.transform.localScale.x), gameObject.transform.localScale.y, 0);
        }

       

    }


    public void OnCollisionEnter2D(Collision2D collision) //c
    {
        if (collision.gameObject.tag == "enemy")
        {
            life--;
            Debug.Log("Can : " + life);
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.9f, gameObject.transform.position.z);
            if(life <= 0)
            {
                SceneManager.LoadScene("oyun");
            }
        }
    }



}
