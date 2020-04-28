using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

 
    public int speed=10;
    // Update is called once per frame
    void Update()
    {
        float moveSideWays = Input.GetAxis("Horizontal");

        if (moveSideWays != 0)
        {
            transform.Translate(moveSideWays * Time.deltaTime * speed, 0f, 0f);
        }
    }
}
