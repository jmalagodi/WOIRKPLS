using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public bool touching;
    void Start()
    {
        GetComponent<Collider>().enabled = true;
        touching = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!touching)
        {
            GetComponent<Collider>().enabled = true;
        }

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player2"))
        {
            Debug.Log(touching);
            touching = true;
            GetComponent<Collider>().enabled = false;
            
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player2"))
        {
            Debug.Log(touching);
            touching = false;
            GetComponent<Collider>().enabled = true;

        }
    }


}
