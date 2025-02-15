using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterController : MonoBehaviour
{
    public float speed = 6.0f;
    public float jumpForce = 10.0f;

    private Animator animator;
    private Rigidbody2D body;
    private SpriteRenderer spriteRenderer;
    private Quaternion initialRotation;
    private bool inAir;

    void Start()
    {
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        initialRotation = transform.rotation;
    }

    float ClampAngle(float angle, float from, float to)
    {
        // accepts e.g. -80, 80
        if (angle < 0f) angle = 360 + angle;
        if (angle > 180f) return Mathf.Max(angle, 360 + from);
        return Mathf.Min(angle, to);
    }

    void Update()
    {
        Vector3 rot = transform.rotation.eulerAngles;
        rot.z = ClampAngle(rot.z, -10f, 10f);
        transform.eulerAngles = rot;

        float axis = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(axis * speed, body.velocity.y);

        if (axis == 0.0F)
        {
            animator.SetBool("Running", false);
        }
        else
        {
            animator.SetBool("Running", true);

            if (axis < 0)
            {
                spriteRenderer.flipX = true;
            }
            else
            {
                spriteRenderer.flipX = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.W) && !inAir)
        {
            body.AddForce(new Vector2(jumpForce, jumpForce), ForceMode2D.Impulse);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Void"))
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
    }
}
