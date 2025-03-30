using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerRotate : MonoBehaviour
{
    // Start is called before the first frame update
    public float VerticalInput;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        VerticalInput = Input.GetAxis("Vertical");
        

        if (VerticalInput != 0)
        {
            float targetRotationY = VerticalInput > 0 ? 0 : 180f;

            // If moving right (positive input), face right (normal scale)
            if (VerticalInput > 0)
            {
                transform.rotation = new Quaternion(0, 0, 0, 0);
            }
            // If moving left (negative input), face left (flip the X scale)
            else
            {
                transform.rotation = new Quaternion(0, 180, 0, 0);
            }
        }
    }
}
