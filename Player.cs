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
    public float damagedTime; //Karakterimiz hasar aldýðýnda diðer hasarý almadan zaman vermek için yapacaðýmýz iþlemin ilk tanýmlamaýsýný yapýyoruz.
    public Color normalColor; // Karakterimizin hasar aldýðýný daha iyi belirtmek için renk deðiþtirme yoluna gideceðiz. Öncelikle normal color karakterimizin normal rengi olacak bunu Start metoduna kodlayacaðýz.
    public Color damagedColor; //Bu tanýmlamamýz ise hasar aldýðýnda deðiþecek olan karakterin rengi olacak bunu da ayný þekilde kodlayacaðýz. 
    public Text lifeText; //Hasar alýndýðýný belirten görseli ayarlamak için text tanýmlamamýzý yapýyoruz. 
    public UIManager UIManagerScript;
   

    // Start is called before the first frame update
    void Start()
    {
        normalColor = gameObject.GetComponent<SpriteRenderer>().color;  //Karakterimizin baþlangýç rengini belirliyoruz.
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
            {                                                                      //Eðer hasar alýrsak karakterimizin rengi normalColor deðerinden damagedColor deðerine geçsin.
                gameObject.GetComponent<SpriteRenderer>().color = damagedColor;
            }
        }
        else
        {
            if(gameObject.GetComponent<SpriteRenderer>().color == damagedColor) 
            {                                                                      //Tam tersiyse hasar almýyorsak normalColor deðerinde kalalým.
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


    //Enemy taglý bir objeye temas edildiðinde bir kere canýmýz gidiyordu bir daha can deðerinin düþmesi için yine temas gerekiyordu bu durumu Stay2D ile deðiþtirerek temasta bulunduðu süre boyunca hasarýn devam etmesini ayarladýk.
    //Kodlarýn karýþmamasý için de Hit isimli bir metod açarak alýnan hasar kodlarýmýzý ve ayarlamalýrýmýzý oraya koyduk. Enter2D ve Stay2D lerin içine Hit metodunu çaðýrma kodunu koyduk. 

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
        lifeText.text = life.ToString(); // Hasar alýðýmýzda can deðeri consolda yazarken bunu hem kod ile hem Unity panelden ayarlayarak tanýmladýðýmýz text de deðiþiklik yapmasýný ayarlýyoruz.ToString yapma sebebim üstte tanýmlamada int bir deðer olarak tanýmlamamdýr.
        damagedTime = 0.7f; //Damaged Time ý 0.7 olarak tanýmlýyoruz. Yani bir hasar aldýðýnda 0.7 saniye bekle sonra yine hasar al.
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
