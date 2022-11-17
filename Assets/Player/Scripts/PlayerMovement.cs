using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Conponents
    private Rigidbody2D rb2d;

    //MOVEMENT
    public float speed = 10;
    float dirX;

    //Jumping
    float jump;
    float jumpTime = 0.5f;
    public float maxJumpTime = 0.5f;
    public bool grounded;
    bool doubleJump = true;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        DirectionalMovement();
        Jumping();
    }

    void DirectionalMovement()
    {
        dirX = Input.GetAxis("Horizontal");
        transform.Translate(transform.right * dirX * speed * Time.deltaTime);
    }


    void Jumping()
    {
        jump = Input.GetAxis("Jump");
        if (jump == 1)
        {
            jumpTime -= Time.deltaTime;

            Debug.Log(jumpTime);
            Debug.Log(doubleJump);

            if (jumpTime > 0)
            {
                rb2d.AddForce(transform.up, ForceMode2D.Impulse);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            grounded = true;
            jumpTime = maxJumpTime;
            doubleJump = true;
        }
    }
    void OnCollisionExit2D(Collision2D Collider)
    {
        if (Collider.gameObject.layer == 6)
        {
            grounded = false;
        }
    }

}