using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    //Components Connected to the same gameObject as this one.

    //Components Connected to other gameObjects.
    Text scoreTxt;

    //public properties
    public float speed;

    //private properties
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        //init my components

        //init other components
        scoreTxt = GameObject.Find("Score").GetComponent<Text>();

        //init private properties
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        transform.position += h * Vector3.right * Time.deltaTime * speed;
    }


    //Called when my gameObject collides with another
    //Requires at least 1 of the gameObjects to have a Rigidbody.
    private void OnCollisionEnter(Collision collision)
    {
        score += 10;
        scoreTxt.text = "Score: " + score;
        
        // hide score with scoreTxt.text = "";
    }    
}
