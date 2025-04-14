using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject player;         // assign  player object in Inspector
    public float moveStep = 1f;     // how far player moves per input
    public float xMin = -50f, xMax = 50f;  // x-axis boundaries
    public float zMin = 100f, zMax = 200f; // z-axis boundaries

    private float xPos = 20f;
    private float zPos = 20f;

    void Start()
    {
        // start position, can be changed to match the scene
        xPos = player.transform.position.x;
        zPos = player.transform.position.z;
    }

    void Update()
    {
        // Keyboard movement (arrow keys)
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveLeft();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveRight();
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            MoveUp();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MoveDown();
        }
    }

    // UI Button Movement Functions:
    public void MoveLeft()
    {
        UnityEngine.Debug.Log("MoveLeft clicked");
        xPos -= moveStep;
        xPos = Mathf.Clamp(xPos, xMin, xMax);
        player.transform.position = new Vector3(xPos, 0f, zPos);
    }

    public void MoveRight()
    {
        UnityEngine.Debug.Log("MoveRight clicked");
        xPos += moveStep;
        xPos = Mathf.Clamp(xPos, xMin, xMax);
        player.transform.position = new Vector3(xPos, 0f, zPos);
    }

    public void MoveUp()
    {
        zPos -= moveStep;
        zPos = Mathf.Clamp(zPos, zMin, zMax);
        player.transform.position = new Vector3(xPos, 0f, zPos);
    }

    public void MoveDown()
    {
        zPos += moveStep;
        zPos = Mathf.Clamp(zPos, zMin, zMax);
        player.transform.position = new Vector3(xPos, 0f, zPos);
    }
}
