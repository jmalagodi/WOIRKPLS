using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controller : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce;
    public float horizontalInput;
    public Rigidbody rb;
    public bool isOnGround;
    public float gravityMod;
    public bool gameOver;
    public GameObject sword;
    public bool attacking;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sword.gameObject.SetActive(false);
        attacking = false;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
        if (!attacking)
        {
            if (Input.GetKeyDown(KeyCode.V))
            {
                sword.gameObject.SetActive(true);
                StartCoroutine(swordDelay(0.2f));

            }
        }   
            
     
            

            
        if (gameOver)
        {
            Debug.Log("Game Over");
        }
        if (horizontalInput != 0)
        {
            float targetRotationY = horizontalInput > 0 ? 0 : 180f;

            // If moving right (positive input), face right (normal scale)
            if (horizontalInput > 0)
            {
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            // If moving left (negative input), face left (flip the X scale)
            else
            {
                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
        }

    }
    IEnumerator swordDelay(float delay)
    {
        attacking = true;
        yield return new WaitForSeconds(delay);
        sword.gameObject.SetActive(false);
        yield return new WaitForSeconds(1.0f);
        attacking = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Player2"))
        {
            isOnGround = true;

        }

        if (collision.gameObject.CompareTag("Spike"))
        {
            gameOver = true;
            Debug.Log("Game Over");
            LivesCounterp1.instance.DecreaseLives();
            LivesCounterp1.instance.DecreaseLives();
            LivesCounterp1.instance.DecreaseLives();
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            LivesCounterp1.instance.DecreaseLives();
        }



    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyProjectile"))
        {

            Destroy(other.gameObject);
            LivesCounterp1.instance.DecreaseLives();

        }
    }
}
