using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEditor;
using UnityEngine;

public class EnemyAggroRanged : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pointA;
    public GameObject pointB;
    public GameObject player;
    public GameObject player2;
    public GameObject projectile;
    public GameObject projectileSpawner;
    public Rigidbody rb;
    private Transform currentPoint;
    public float speed;
    public bool patrol;
    public float aggroRange;
    public float fieldOfViewAngle = 60f;
    public Vector3 lookDirection2;
    private float spawnCooldown = 2f;
    private float spawnTimer = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentPoint = pointB.transform;
        patrol = true;
        spawnTimer = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = currentPoint.position - transform.position;
        Vector2 directionToPlayer = player.transform.position - transform.position;
        Vector2 directionToPlayer2 = player2.transform.position - transform.position;


        float angleToPlayer = Vector3.Angle(transform.right, directionToPlayer);
        float angleToPlayer2 = Vector3.Angle(transform.right, directionToPlayer2);
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
        float distanceToPlayer2 = Vector2.Distance(transform.position, player2.transform.position);

        GameObject closestPlayer = (distanceToPlayer < distanceToPlayer2) ? player : player2;

        Vector3 lookDirection = (closestPlayer.transform.position - transform.position).normalized;

        bool playerInSight = angleToPlayer < fieldOfViewAngle / 2f;
        bool player2InSight = angleToPlayer2 < fieldOfViewAngle / 2f;
      

        //Debug.Log((Vector2.Distance(transform.position, player.transform.position)));
        if (Vector2.Distance(transform.position, player.transform.position) < aggroRange && playerInSight || Vector2.Distance(transform.position, player2.transform.position) < aggroRange && player2InSight)
        {
            patrol = false;
        }

        if (patrol)
        {
            speed = 1.5f;
            spawnTimer = 2f;
            if (currentPoint == pointB.transform)
            {
                rb.velocity = new Vector2(speed, 0);
            }
            else
            {
                rb.velocity = new Vector2(-speed, 0);
            }
            if (Vector2.Distance(transform.position, currentPoint.position) < 1f && currentPoint == pointB.transform)
            {

                transform.Rotate(0, 180, 0);
                currentPoint = pointA.transform;
                Debug.Log("Point Hit");
              
            }
            if (Vector2.Distance(transform.position, currentPoint.position) < 1f && currentPoint == pointA.transform)
            {

                transform.Rotate(0, 180, 0);
                currentPoint = pointB.transform;
                Debug.Log("Other Point Hit");
                
            }
        }
        else 
        {
            speed = 0f;
            
            transform.Translate(lookDirection * -speed * Time.deltaTime);
            
            spawnTimer += Time.deltaTime;


            if (spawnTimer >= spawnCooldown) 
            {
                
                SpawnProjectiles(closestPlayer.transform.position);
                spawnTimer = 0f;
                
                
            }
            if (Vector2.Distance(transform.position, player.transform.position) > aggroRange && Vector2.Distance(transform.position, player2.transform.position) > aggroRange)
            {
                patrol = true;
            }
            if (lookDirection.x > 0)
            {
                // Player is to the right, make the enemy face right
                transform.localRotation = Quaternion.Euler(0, 0, 0); // Face right (no rotation on the y-axis)
            }
            else if (lookDirection.x < 0)
            {
                // Player is to the left, make the enemy face left
                transform.localRotation = Quaternion.Euler(0, 180, 0); // Face left (180 degrees on the y-axis)
            }

        }
       
    }
    public void SpawnProjectiles(Vector3 targetPosition)
    {

        GameObject newProjectile = Instantiate(projectile, projectileSpawner.transform.position, projectileSpawner.transform.rotation);
        newProjectile.GetComponent<ProjectileMove>().SetTargetPosition(targetPosition);

    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerWeapon"))
        {
            Destroy(gameObject);
        }

    }




}
