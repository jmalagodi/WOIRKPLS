using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder;


public class Player2Controller : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce;
    public float VerticalInput;
    private float spawnTimer = 0f;
    public Rigidbody rb2;
    public bool isOnGround;
    public GameObject Player1;
    public GameObject projectile;
    public GameObject projectileSpawner;
    private float spawnCooldown = 2f;

    // Start is called before the first frame update
    void Start()
    {
        rb2 = GetComponent<Rigidbody>();
        
        spawnTimer = 2f;


    }

    // Update is called once per frame
    void Update()
    {
        VerticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * VerticalInput * speed * Time.deltaTime);
        spawnTimer += Time.deltaTime;

        if ((Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4)) && isOnGround) 
        {
            rb2.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
        if ((Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Keypad5)))
        {
            
           

            if (spawnTimer >= spawnCooldown)
            {

                SpawnProjectiles();
                spawnTimer = 0f;
            }
        }
        if (VerticalInput != 0)
        {
            float targetRotationY = VerticalInput > 0 ? 0 : 180f;

            // If moving right (positive input), face right (normal scale)
            if (VerticalInput > 0)
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
    private void SpawnProjectiles()
    {
        Instantiate(projectile, projectileSpawner.transform.position, projectileSpawner.transform.rotation);
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Player"))
        {
            isOnGround = true;

        }

        if (collision.gameObject.CompareTag("Spike"))
        {
            Debug.Log("Game Over");
            LivesCounterp1.instance.DecreaseLives();
            LivesCounterp1.instance.DecreaseLives();
            LivesCounterp1.instance.DecreaseLives();
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            LivesCounterp2.instance.DecreaseLives();
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
