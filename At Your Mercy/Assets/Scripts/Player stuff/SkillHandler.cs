using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillHandler : MonoBehaviour
{
    public ShapesController shapesController;
    private Image Image;


    [SerializeField] List<Sprite> icons;
    [SerializeField] Color activeColor;
    [SerializeField] Color cooldownColor;
    [SerializeField] Color defaultColor;

    // Start is called before the first frame update
    void Start()
    {
        Image = GetComponent<Image>();
        //shapesController = FindObjectOfType<ShapesController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Image.color = defaultColor;
        Image.sprite = icons[shapesController.shapeIndex];
        
        if(shapesController.isOnActive){
            Image.color = activeColor;
            Image.fillAmount -= 1 / shapesController.duration * Time.deltaTime;
        }
        else if(shapesController.isInCooldown){
            Image.fillAmount += 1 / shapesController.cooldown * Time.deltaTime;
            Image.color = cooldownColor;
            //Image.fillClockwise = true;
        }
        else{
            Image.fillAmount = 1;
        }

        //Debug.Log(shapesController.shapeIndex);
           
    }
}
