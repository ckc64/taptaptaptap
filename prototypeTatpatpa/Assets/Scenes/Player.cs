using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour

{

    [SerializeField] private int jumpForce = 10;
    [SerializeField] private Rigidbody2D rigidbody2d;
 

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(Vector2.up);
            rigidbody2d.velocity = Vector2.up * jumpForce;
        }
    }


}
