using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Conponents
    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private BoxCollider2D groundCheck;
    [SerializeField] private LayerMask groundLayer;

    //MOVEMENT
    public float speed = 10;
    float dirX;

    //Jumping
    float jump;
    float jumpTime = 0.5f;
    [SerializeField] private int jumpForce = 10;
    [SerializeField] private float maxJumpTime = 0.5f;
    private bool isGrounded;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Jumping();
    }

    private void FixedUpdate()
    {
        DirectionalMovement();
    }

    void DirectionalMovement()
    {
        dirX = Input.GetAxis("Horizontal");
        transform.Translate(transform.right * dirX * speed * Time.deltaTime);
    }


    void Jumping()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb2d.AddForce(Vector2.up * jumpForce * 200);
        }
        
        jump = Input.GetAxis("Jump");

        if (jump == 1 && !isGrounded)
        {
            jumpTime -= Time.deltaTime;
        
            Debug.Log(jumpTime);
        
            if (jumpTime > 0)
            {
                rb2d.AddForce(transform.up * 1.4f, ForceMode2D.Impulse);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            isGrounded = true;
            jumpTime = maxJumpTime;
        }
    }
    void OnCollisionExit2D(Collision2D Collider)
    {
        if (Collider.gameObject.layer == 6)
        {
            isGrounded = false;
        }
    }

}