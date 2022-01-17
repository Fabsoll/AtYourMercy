using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeController : MonoBehaviour
{
    // References for player's scripts
    private PlayerMovement playerMovement;

    // Class to store data of shapes
    [System.Serializable]
    public class Shape{
        public string name;
        public Sprite sprite;
        public float movementSpeed;
        public float jumpHeigh;
    }

    // List of all shapes 
    public Shape[] shapes;

    // Variables
    public int shapeIndex;
    public float cooldown;
    public float duration;
    
    public bool isOnActive = false;
    public bool isInCooldown = false;

    public Shape currentShape;

    // Start is called before the first frame update
    void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        shapeIndex = 1;
    }
    void Start()
    {
        AssignInitialShape(shapes[0]);
    }

    // Update is called once per frame
    void Update()
    {
        if(!isOnActive){
            if (Input.GetAxis("Mouse ScrollWheel") > 0f ) 
            { 
                if(shapeIndex >= shapes.Length - 1){
                    shapeIndex = 1;
                }
                else{
                    shapeIndex++; 
                }
            } 
            else if (Input.GetAxis("Mouse ScrollWheel") < 0f )  
            { 
                if(shapeIndex == 1){
                    shapeIndex = shapes.Length - 1;
                }
                else{
                    shapeIndex--;
                }
            }
            if(!isInCooldown){
                if(Input.GetKeyDown(KeyCode.F)){
                    if(shapeIndex != 0){
                        AssignShape(shapes[shapeIndex]);
                    }
                }
            }
            else if(isInCooldown){
                AssignInitialShape(shapes[0]);
            }
        }
    }

    private void AssignShape(Shape shape){
        currentShape = shape;
        this.gameObject.GetComponent<SpriteRenderer>().sprite = shape.sprite;
        playerMovement.movementSpeed = shape.movementSpeed;
        //playerMovement.jumpForce = shape.jumpHeigh;
        isOnActive = true;
        isInCooldown = true;
        StartCoroutine("ResetActive");
        StartCoroutine("GoCooldown");
    }
    private void AssignInitialShape(Shape shape)
    {
        currentShape = shape;
        this.gameObject.GetComponent<SpriteRenderer>().sprite = shape.sprite;
        playerMovement.movementSpeed = shape.movementSpeed;
        //playerMovement.jumpForce = shape.jumpHeigh;
    }

    IEnumerator ResetActive(){
        yield return new WaitForSeconds(duration);
        isOnActive = false;
    }

    IEnumerator GoCooldown(){
        yield return new WaitForSeconds(duration + cooldown);
        isInCooldown = false;
    }
}
