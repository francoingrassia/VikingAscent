using UnityEngine;

public class Movement_Manager : MonoBehaviour
{
    public Rigidbody2D rb;
    public float velocidad, velocidadSalto;
    public bool canJump = true;
    public bool wallJump = false;
    public Transform groundCheck;
    public LayerMask ground;
    public Animator anim;
    Game_Controller gameController;
    public float velocidadCaida;
    public float velocidadPermitida;
    public int wallAux;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        gameController = FindObjectOfType<Game_Controller>().GetComponent<Game_Controller>();
    }

    private void FixedUpdate()
    {
        //Controla el movimiento del player
        rb.velocity = new Vector2(velocidad *Input.GetAxis("Horizontal"), rb.velocity.y);

        //Controla la animación y dirección al correr 
        if (Input.GetAxis("Horizontal") > 0)
        {
            anim.SetBool("run", true);
            GetComponent<SpriteRenderer>().flipX = false;
        }
        
        if (Input.GetAxis("Horizontal") < 0)
        {
            anim.SetBool("run", true);
            GetComponent<SpriteRenderer>().flipX = true;
        }

        if (Input.GetAxis("Horizontal") == 0)
        {
            anim.SetBool("run", false);
        }

        //Controla el salto
        canJump = Physics2D.OverlapCircle(groundCheck.position, .2f, ground);
        if (Input.GetKey(KeyCode.W) && canJump)
        {
            canJump = false;
            rb.AddForce(new Vector2(rb.velocity.x , velocidadSalto));

        }

        //Daño por caida
        if (!canJump)
        {
            velocidadCaida = rb.velocity.y;
        }
        else 
        {
            if (velocidadCaida < velocidadPermitida)
            {
                gameController.life -= 1;
                velocidadCaida = 0;
            }
        }

        //Control salto en pared
        if (canJump)
        {
            wallAux = 1;
        }

        if (Input.GetKeyDown(KeyCode.W) && wallJump && !canJump)
        {
            wallJump = false;
            wallAux = 0;
            rb.AddForce(new Vector2(rb.velocity.x, velocidadSalto));
            Debug.Log("salte");
        }
        Debug.Log(wallAux);
        
        
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Wall>())
        {
            wallJump = true;
            Debug.Log("tocando");
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Wall>())
        {
            wallJump = false;
        }
    }

}
