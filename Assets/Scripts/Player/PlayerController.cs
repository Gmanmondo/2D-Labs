using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float movementSpeed;
    [SerializeField] private float climbingSpeed;

    [Header("Jumping")]
    [SerializeField] private float jumpVelocity;
    [SerializeField] private float groundingCheckDistance;
    [SerializeField] private LayerMask groundLayer;

    [Header("Stopping")]
    [SerializeField] private float stoppingDistance;
    [SerializeField] private LayerMask wallLayer;

    public Animator animator;

    private Rigidbody2D rb;
    private float gravityScale;
    private int playerDirection;
    public float maxHealth = 28f;
    private float currentHealth = 28f;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        gravityScale = rb.gravityScale;
    }

    private void Update()
    {
        Walking();
        Jumping();

        currentHealth -= Time.deltaTime;
        float healthNormalized = currentHealth / maxHealth;

        HealthBar healthBar = HealthBar.GetInstance();
        if (healthBar != null)
        {
            healthBar.SetHealth(healthNormalized);
        }
    }

    private void Walking()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) animator.SetBool("isMoving", true);
        else  animator.SetBool("isMoving", false);

        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D)) animator.SetBool("isMoving", false);

        if (Input.GetKey(KeyCode.D) && !CheckIfPlayerShouldStop(Vector2.right)) {
            transform.position += transform.right * movementSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            playerDirection = 1;
        }

        if (Input.GetKey(KeyCode.A) && !CheckIfPlayerShouldStop(Vector2.left)) {
            transform.position += transform.right * movementSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 180, 0);
            playerDirection = -1;
        }
    }

    private void Jumping() {
        var isGrounded = CheckIfGrounded();

        if (isGrounded) {
            animator.SetBool("isInAir", false);

            if (Input.GetKeyDown(KeyCode.Space)) {
                rb.AddForce(transform.up * jumpVelocity, ForceMode2D.Impulse);
            }
        }
        else {
            animator.SetBool("isInAir", true);
        }
    }

    // private void OnTriggerStay2D(Collider2D other) {
    //     if (other.CompareTag("Climbable")){
    //         ClimbLadder();
    //         animator.SetBool("isClimbing", true);
    //     }
    //     else{
    //         animator.SetBool("isClimbing", false);
    //     }
    // }

    // private void ClimbLadder() {
    //     rb.gravityScale = 0f;
    //     if (Input.GetKey(KeyCode.W) && !CheckIfPlayerShouldStop(Vector2.up)) {
    //         transform.position += transform.up * climbingSpeed * Time.deltaTime;
    //     }
    //     if (Input.GetKey(KeyCode.S) && !CheckIfPlayerShouldStop(Vector2.down)) {
    //         transform.position += -transform.up * climbingSpeed * Time.deltaTime;
    //     }
    // }

    // private void OnTriggerExit2D(Collider2D other) {
    //     rb.gravityScale = gravityScale;
    //     animator.SetBool("isClimbing", false);
    // }

    // private void OnCollisionEnter2D(Collision2D other) {
    //     if (other.collider.CompareTag("Enemy Bullet")) {
    //         GetComponent<Player>().TakeDamage(2);
    //         // Destroy(other.gameObject);
    //         other.gameObject.GetComponent<SpriteRenderer>().enabled = false;
    //         Destroy(other.gameObject, 1f);
    //     }
    // }

    private bool CheckIfGrounded() {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundingCheckDistance, groundLayer);
    
        if (hit.collider) return true;
        else return false;
    }

    private bool CheckIfPlayerShouldStop(Vector2 direction) {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, stoppingDistance, wallLayer);

        if (hit.collider)
        {
            return true;
        }
        else return false;
    }

    public int ReturnPlayerDirection()
    {
        return playerDirection;
    }

    //Here is the stuff for player health
    
}