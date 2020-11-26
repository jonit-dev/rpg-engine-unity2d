using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGridMovement : MonoBehaviour
{


    // Reference: https://www.youtube.com/watch?v=AiZ4z4qKy44

    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private Rigidbody2D rigidBody2D;

    private bool isMoving;
    private Vector3 origPos, targetPos;
    private float timeToMove = 0.2f; //time to move from one grid to another

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        Input.GetAxisRaw("Horizontal");
    }



    void FixedUpdate() // works the same as Update() method, but in a fixed timer manner, avoiding hardware constraints to our code
    {

        if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) && !isMoving)
        {
            StartCoroutine(MovePlayer(Vector3.up));
        }
        if ((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) && !isMoving)
        {
            StartCoroutine(MovePlayer(Vector3.down));
        }
        if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) && !isMoving)
        {
            StartCoroutine(MovePlayer(Vector3.left));
        }
        if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) && !isMoving)
        {
            StartCoroutine(MovePlayer(Vector3.right));
        }
    }

    private IEnumerator MovePlayer(Vector3 direction)
    {

        isMoving = true;

        float elapsedTime = 0;

        origPos = transform.position;
        targetPos = origPos + direction;

        while (elapsedTime < timeToMove)
        {
            transform.position = Vector3.Lerp(origPos, targetPos, (elapsedTime / timeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;

        isMoving = false;

    }


}
