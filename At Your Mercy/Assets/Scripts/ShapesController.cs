using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapesController : MonoBehaviour
{

    public GameObject[] playableShapes;
    public int shapeIndex;

    public GameObject currentShape;
    //GameObject valkyrieShape;

    public float cooldown;
    public float duration;
    bool transformed;
    public bool isOnActive = false;
    public bool isInCooldown = false;
    public bool isInitialSpawned = false;

    private HorseMovement horse;

    // Start is called before the first frame update
    void Start()
    {
        shapeIndex = 0;
        // //valkyrieShape = GameObject.FindGameObjectWithTag("Player");
        //playableShapes = GameObject.FindGameObjectsWithTag("Player");
        currentShape = playableShapes[2];
        //shapeIndex = 1;

        EnableOne(2);
        horse = playableShapes[0].GetComponent<HorseMovement>();
    }
    private void Awake()
    {

        DontDestroyOnLoad(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        if(horse.gameObject.activeInHierarchy == false){
            Physics2D.IgnoreLayerCollision(8, 9, true);
        }
        transform.position = currentShape.transform.position;
         if(!isOnActive){
            if (Input.GetAxis("change horse")> 0f || Input.mouseScrollDelta.y >0f)
             { 
                 if(shapeIndex == 1){
                         shapeIndex = 1;
                 }
                 else{
                     shapeIndex++; 
                 }
             } 
             else if (Input.GetAxis("change horse") < 0f || Input.mouseScrollDelta.y <0f)  
             { 
                 if(shapeIndex == 0){
                     shapeIndex = 0;
                 }
                 else{
                     shapeIndex--;
                 }
             }
             //Debug.Log(shapeIndex);

             if(!isInCooldown){
                 if(Input.GetAxis("transform")>0 || Input.GetKeyDown(KeyCode.LeftAlt)){
                     EnableOne(shapeIndex);
                     transformed = true;
                     StartCoroutine("ResetActive");
                     StartCoroutine("GoCooldown");
                 }
             }
             else if(isInCooldown){
                //  if(!isInitialSpawned){
                //      GameObject newShape = SpawnPlayer(0);
                //      Debug.Log("test Message");
                //      Destroy(currentShape.gameObject);
                //      isInitialSpawned = true;
                //      currentShape = newShape;
                //      //Debug.Log("test Message");
                //  }
                //  else if(isInitialSpawned && !isInCooldown){
                //      isInitialSpawned = false;
                //  }
                //Debug.Log("awdwdawdadwa");
                EnableOne(2);
              
             }
          
          
         }

         foreach(GameObject g in playableShapes){
             g.transform.position = this.transform.position;
         }
    }

    GameObject SpawnPlayer(int shapeIndex){
        Vector2 spawnPos = new Vector2(transform.position.x, transform.position.y);
        GameObject player = Instantiate(playableShapes[shapeIndex], spawnPos, Quaternion.identity);
        return player;
    }

    IEnumerator GoCooldown(){
        isInCooldown = true;
        yield return new WaitForSeconds(duration + cooldown);
        isInCooldown = false;
    }
        IEnumerator ResetActive(){
        isOnActive = true;
        yield return new WaitForSeconds(duration);
        isOnActive = false;
    }

    public void EnableOne(int index){
        foreach(GameObject g in playableShapes){
            if(playableShapes[index] == g){
                g.SetActive(true);
                currentShape = g;
            }
            else{
               g.SetActive(false); 
            }
            
        }
    }

}
