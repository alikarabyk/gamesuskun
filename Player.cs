using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 



public class Player : MonoBehaviour
{

    public float speed;
    public Rigidbody2D rigidbody;
    public float jumpSpeed;
    public Animator anim; 
    public int life;
    public float damagedTime; //Karakterimiz hasar ald���nda di�er hasar� almadan zaman vermek i�in yapaca��m�z i�lemin ilk tan�mlama�s�n� yap�yoruz.
    public Color normalColor; // Karakterimizin hasar ald���n� daha iyi belirtmek i�in renk de�i�tirme yoluna gidece�iz. �ncelikle normal color karakterimizin normal rengi olacak bunu Start metoduna kodlayaca��z.
    public Color damagedColor; //Bu tan�mlamam�z ise hasar ald���nda de�i�ecek olan karakterin rengi olacak bunu da ayn� �ekilde kodlayaca��z. 
    public Text lifeText; //Hasar al�nd���n� belirten g�rseli ayarlamak i�in text tan�mlamam�z� yap�yoruz. 
    public UIManager UIManagerScript;
   

    // Start is called before the first frame update
    void Start()
    {
        normalColor = gameObject.GetComponent<SpriteRenderer>().color;  //Karakterimizin ba�lang�� rengini belirliyoruz.
        UIManagerScript = GameObject.Find("UI Manager").GetComponent<UIManager>();



    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Space) && gameObject.transform.Find("Foot").GetComponent<GroundCheck>().isGrounded )
        {
            rigidbody.AddForce(new Vector2(0, jumpSpeed));
        }

        if(damagedTime > 0)
        {
            damagedTime -= Time.deltaTime;
            if(gameObject.GetComponent<SpriteRenderer>().color == normalColor)   
            {                                                                      //E�er hasar al�rsak karakterimizin rengi normalColor de�erinden damagedColor de�erine ge�sin.
                gameObject.GetComponent<SpriteRenderer>().color = damagedColor;
            }
        }
        else
        {
            if(gameObject.GetComponent<SpriteRenderer>().color == damagedColor) 
            {                                                                      //Tam tersiyse hasar alm�yorsak normalColor de�erinde kalal�m.
                gameObject.GetComponent<SpriteRenderer>().color = normalColor;
            }
        }


       
    }


    void FixedUpdate()
    {
        float hor = Input.GetAxisRaw("Horizontal");

        anim.SetFloat("Speed", Mathf.Abs(hor)); 
        

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


    //Enemy tagl� bir objeye temas edildi�inde bir kere can�m�z gidiyordu bir daha can de�erinin d��mesi i�in yine temas gerekiyordu bu durumu Stay2D ile de�i�tirerek temasta bulundu�u s�re boyunca hasar�n devam etmesini ayarlad�k.
    //Kodlar�n kar��mamas� i�in de Hit isimli bir metod a�arak al�nan hasar kodlar�m�z� ve ayarlamal�r�m�z� oraya koyduk. Enter2D ve Stay2D lerin i�ine Hit metodunu �a��rma kodunu koyduk. 

    public void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.tag == "enemy" && damagedTime <= 0)  
        {
            Hit(); 
        }
    }


    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy" && damagedTime <= 0)
        {
            Hit();
        }
    }



    public void Hit()
    {
        life--;
        lifeText.text = life.ToString(); // Hasar al���m�zda can de�eri consolda yazarken bunu hem kod ile hem Unity panelden ayarlayarak tan�mlad���m�z text de de�i�iklik yapmas�n� ayarl�yoruz.ToString yapma sebebim �stte tan�mlamada int bir de�er olarak tan�mlamamd�r.
        damagedTime = 0.7f; //Damaged Time � 0.7 olarak tan�ml�yoruz. Yani bir hasar ald���nda 0.7 saniye bekle sonra yine hasar al.
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.9f, gameObject.transform.position.z);
        if (life <= 0)
        {
            UIManagerScript.GetComponent<Canvas>().enabled = true;
        }
    }

    public void UpdateLifeText()
    {
        lifeText.text = life.ToString();
    }


 
       


}
