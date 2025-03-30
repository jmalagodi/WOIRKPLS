using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button1 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject SpikeWall;
    void Start()
    {
        SpikeWall.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player2"))
        {
            SpikeWall.gameObject.SetActive(false);
        }
    }
}
