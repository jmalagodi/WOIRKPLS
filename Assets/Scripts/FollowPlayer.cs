using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject Player;  // The player object you want to follow
    private Vector3 offset;    // The offset between the follower and the player

    void Start()
    {
        // You can define an initial offset here if needed
        offset = new Vector3(1, 0, 0); // For example, 2 units in the X direction
    }

    void Update()
    {

        transform.position = new Vector3(Player.transform.position.x + offset.x, Player.transform.position.y + offset.y, transform.position.z);

    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
    }
}