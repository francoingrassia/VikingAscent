using UnityEngine;

public class Movement_Manager : MonoBehaviour
{
    public Rigidbody2D rb;
    public float velocidad, velocidadSalto, velocidadWallJump;
    public bool canJump = true;
    public bool wallJump = false;
    public Transform groundCheck;
    public LayerMask ground;
    public Animator anim;
    Game_Controller gameController;
    public float velocidadCaida;
    public float velocidadPermitida;
    public int wallAux;
    private SoundController soundController;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        gameController = FindObjectOfType<Game_Controller>().GetComponent<Game_Controller>();
        soundController = GetComponent<SoundController>();
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
        

        ////Controla el salto
        //canJump = Physics2D.OverlapCircle(groundCheck.position, .2f, ground);
        //if (canJump)
        //{
        //    wallAux = 0;
        //}
        //if (Input.GetKeyDown(KeyCode.W))
        //{
        //    if (canJump)
        //    {
        //        wallAux = 0;
        //        canJump = false;
        //        rb.AddForce(new Vector2(rb.velocity.x, velocidadSalto));
        //    }
        //    else if (wallJump && wallAux > 0)
        //    {
        //        wallJump = false;
        //        wallAux = 0;
        //        rb.AddForce(new Vector2(rb.velocity.x, velocidadSalto));
        //    }
        //}


    }
    private void Update()
    {
        canJump = Physics2D.OverlapCircle(groundCheck.position, .3f, ground);
        if (canJump)
        {
            wallAux = 0;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (canJump)
            {
                wallAux = 0;
                canJump = false;
                rb.AddForce(new Vector2(rb.velocity.x, velocidadSalto));
                soundController.SeleccionAudio(0, 0.6f);
            }
            else if (wallJump && wallAux > 0)
            {
                wallJump = false;
                wallAux = 0;
                rb.AddForce(new Vector2(rb.velocity.x, velocidadWallJump));
                soundController.SeleccionAudio(0, 0.6f);
            }
        }
        
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Wall>())
        {
            wallJump = true;
            wallAux = 1;
        }
        if (collision.gameObject.GetComponent<Piso>())
        {
            if (canJump)
            {
                soundController.SeleccionAudio(Random.Range(1, 7), 0.1f);
            }
        }
    }
}
