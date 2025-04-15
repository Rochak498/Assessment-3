using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float moveSpeed = 5f; // speed of movement

    void Update()
    {
        // Get input from arrow keys
        float moveX = Input.GetAxisRaw("Horizontal"); // Left (-1) or Right (1)
        float moveY = Input.GetAxisRaw("Vertical");   // Down (-1) or Up (1)

        // Create a movement vector
        Vector3 moveDirection = new Vector3(moveX, 0f, moveY).normalized;

        // Apply movement
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }
}
