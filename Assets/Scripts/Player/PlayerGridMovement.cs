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

    [SerializeField]
    private LayerMask raycastLayer;

    private bool isMoving;
    private Vector3 origPos, targetPos;
    private float timeToMove = 0.2f; //time to move from one grid to another



    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");



    }





    void FixedUpdate() // works the same as Update() method, but in a fixed timer manner, avoiding hardware constraints to our code
    {


        Debug.DrawRay(transform.position, movement, Color.red);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, movement, 1, raycastLayer);

        if (hit.collider == null)
        {
            if (!isMoving)
            {
                StartCoroutine(MovePlayer(movement));
            }
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
