using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class character : MonoBehaviour
{
    
    public float speed = 10f;
    public float maxSpeed = 5f;
    public float jumpPower = 5f;
    float timeAux;

    public bool grounded, plataforma, muerte, pared, pared_1, salto, right, left;
    private bool jump;
    bool boolsoundsalto;

    public GameObject explosion;
    public GameObject final;
    public GameObject finaltime;
    private Rigidbody2D rb2d;

    private Animator animate;
  
    public int level ;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        animate = GetComponent<Animator>();

        timeAux = Time.time;      
    }

    // Update is called once per frame
    void Update()
    {
        float timeDif = Time.time - timeAux;

        //Movimiento PC

        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            rb2d.AddForce(Vector3.right * speed * Time.deltaTime);

            transform.eulerAngles = new Vector3(0, 0, 0);
            if (rb2d.velocity.x > maxSpeed)
            {
                rb2d.velocity = new Vector3(maxSpeed, rb2d.velocity.y, 0);
            }
        }

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            rb2d.AddForce(Vector3.left * speed * Time.deltaTime);

            transform.eulerAngles = new Vector3(0, 180, 0);
            if (rb2d.velocity.x < -maxSpeed)
            {
                rb2d.velocity = new Vector3(-maxSpeed, rb2d.velocity.y, 0);
            }
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (grounded || plataforma)
            {
                jump = true;

                soundmusic.boolsoundsalto = true;
            }
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (pared_1)
            {
                jump = false;

                Vector3 salto = new Vector3(-100, 450, 0);
                rb2d.AddForce(salto);
                transform.eulerAngles = new Vector3(0, 180, 0);
                soundmusic.boolsoundsalto = true;
            }
            else if (pared)
            {
                jump = false;

                Vector3 salto = new Vector3(100, 450, 0);
                rb2d.AddForce(salto);
                transform.eulerAngles = new Vector3(0, 0, 0);
                soundmusic.boolsoundsalto = true;
            }
        }

        //Movimiento telefono

        if (right == true)
        {
            rb2d.AddForce(Vector3.right * speed * Time.deltaTime);

            transform.eulerAngles = new Vector3(0, 0, 0);
            if (rb2d.velocity.x > maxSpeed)
            {
                rb2d.velocity = new Vector3(maxSpeed, rb2d.velocity.y, 0);
            }
        }

        if (left == true)
        {
            rb2d.AddForce(Vector3.left * speed * Time.deltaTime);

            transform.eulerAngles = new Vector3(0, 180, 0);
            if (rb2d.velocity.x < -maxSpeed)
            {
                rb2d.velocity = new Vector3(-maxSpeed, rb2d.velocity.y, 0);
            }
        }

        if (salto == true)
        {
            if (grounded || plataforma)
            {
                jump = true;

                soundmusic.boolsoundsalto = true;
            }

            salto = false;

            if (pared_1)
            {
                jump = false;

                Vector3 salto = new Vector3(-100, 450, 0);
                rb2d.AddForce(salto);
                transform.eulerAngles = new Vector3(0, 180, 0);
                soundmusic.boolsoundsalto = true;
            }
            else if (pared)
            {
                jump = false;

                Vector3 salto = new Vector3(100, 450, 0);
                rb2d.AddForce(salto);
                transform.eulerAngles = new Vector3(0, 0, 0);
                soundmusic.boolsoundsalto = true;
            }
        }   
    }

    private void FixedUpdate()
    {
        if (jump)
        {
            rb2d.AddForce(Vector3.up * jumpPower, ForceMode2D.Impulse);
            jump = false;
        }
    }
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Suelo_escenario")
        {

            grounded = true;

        }

        if (collision.transform.tag == "pared_rebote")
        {
            jump = false;
            
            grounded = false;
            pared = true;
            Vector3 pos = new Vector3(transform.position.x , transform.position.y, transform.position.z);
            GameObject clone = Instantiate(explosion, pos, Quaternion.identity) as GameObject;
            clone.SetActive(true);

        }

        if (collision.transform.tag == "pared_rebote_1")
        {
            jump = false;
            
            grounded = false;
            pared_1 = true;
            Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            GameObject clone = Instantiate(explosion, pos, Quaternion.identity) as GameObject;
            clone.SetActive(true);

        }

        if (collision.transform.tag == "enemy" || collision.transform.tag == "water")
        {

            
           


            if (level == 1)
            {
                SceneManager.LoadScene(1);
            }
            if (level == 2)
            {
                SceneManager.LoadScene(2);
            }
           
            
           

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "final")
        {
            Timer.tempo++;
            Destroy(gameObject, 0.05f);
            final.SetActive(true);
            finaltime.SetActive(false);

        }

        if (collision.transform.tag == "enemy" || collision.transform.tag == "bola")
        {


            if (level == 1)
            {
                SceneManager.LoadScene(1);
            }
            if (level == 2)
            {
                SceneManager.LoadScene(2);
            }


        }
    }

   

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "pared_rebote_1")
        {
            pared_1 = false;

        }

        if (collision.transform.tag == "pared_rebote")
        {
            pared = false;

        }

        if (collision.transform.tag == "Suelo_escenario")
        {
            grounded = false;

        }

        if (collision.transform.tag == "Plataforma")
        {
            grounded = false;
            this.transform.parent = null;

        }
    }

    public void Salto()
    {
    salto = true;
    }

    public void izquierdaON()
    {
    left = true;
    }

    public void izquierdaOFF()
    {
    left = false;
    }

    public void derechaON()
    {
    right = true;
    }

    public void derechaOFF()
    {
    right = false;
    }

}




 
