using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricPlayerMovementController : MonoBehaviour
{

    public float movementSpeed = 1.5f;
    public Camera myCamera;
    //IsometricCharacterRenderer isoRenderer;
    SpriteRenderer sprite;
    public GameObject gridObject;
    public Sprite NE;
    public Sprite NW;
    public Sprite SE;
    public Sprite SW;

    Rigidbody2D rbody;

    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
        //isoRenderer = GetComponentInChildren<IsometricCharacterRenderer>();
        sprite = GetComponent<SpriteRenderer>();
        gridObject = GameObject.FindGameObjectWithTag("Grid"); 
        if (!gridObject)
        {
            print("Cannot find Grid."); 
        }
    }


    Vector2 FindDirection(Vector2 mousePosition, Vector2 characterPosition)
    {
        Vector2 moveDirection;

        //Check if x and y direction compared to mouse is negative or positive
        moveDirection.x = characterPosition.x < mousePosition.x ? 1 : -1;
        moveDirection.y = characterPosition.y < mousePosition.y ? 1 : -1;


        return moveDirection;
    }

    void SetSprite(Vector2 moveDirection)
    {
        //Both positive: NE
        if (moveDirection.x > 0 && moveDirection.y > 0)
        {
            sprite.sprite = NE;
        }

        //Y positive, X negative: NW
        else if (moveDirection.x < 0 && moveDirection.y > 0)
        {
            sprite.sprite = NW;
        }

        //Both negative: SW
        else if (moveDirection.x < 0 && moveDirection.y < 0)
        {
            sprite.sprite = SW;
        }

        else
        {
            sprite.sprite = SE;
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButton(0)) {
            //Get mouse position
            Vector3 mousePosition = myCamera.ScreenToWorldPoint(Input.mousePosition);

            //Check which diagonal the player is going in
            var moveVector = FindDirection(mousePosition, transform.position);


            SetSprite(moveVector);

            //Execute movement
            transform.Translate(moveVector * Time.deltaTime * movementSpeed);
        }
    }
}
