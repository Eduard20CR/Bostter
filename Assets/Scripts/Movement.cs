using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float rotationThrust = 100f;
    [SerializeField] float mainThrust = 1000f;

    private Rigidbody rb ;
    // Start is called before the first frame update
    void Start()
    {
         rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    private void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            

            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        } 
    }

    private void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))    
        {
            rotateRocket(rotationThrust);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rotateRocket(-rotationThrust);
        }
    }

    private void rotateRocket(float rotationThisFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false;
    }

}
