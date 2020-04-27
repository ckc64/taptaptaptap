using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour

{

    [SerializeField] private int jumpForce = 10;
    public Rigidbody2D rigidbody;
 

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(Vector2.up);
            rigidbody.velocity = Vector2.up * jumpForce;
        }
    }
}
