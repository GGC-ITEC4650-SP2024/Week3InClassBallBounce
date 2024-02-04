using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallController : MonoBehaviour
{
    //Components Connected to the same gameObject as this one.
    AudioSource myAudio;
    Rigidbody myBod;

    //Components Connected to other gameObjects.
    FloorController floorCon;
    
    //public properties
    public AudioClip bounceSound; //Initialised in the inspector.

    // Start is called before the first frame update
    void Start()
    {
        //init my components
        myAudio = GetComponent<AudioSource>();
        myBod = GetComponent<Rigidbody>();

        //init other components
        floorCon = GameObject.Find("Floor").GetComponent<FloorController>();

        float x = Random.Range(-3f, 3f);
        myBod.velocity = new Vector3(x, 5, 0);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        myAudio.PlayOneShot(bounceSound);
    }

    //Called when my gameObject collides with another
    //Requires at least 1 of the gameObjects to have a Rigidbody.
    private void OnTriggerEnter(Collider other) {
        if(other.name == "BonusBox") {
            GameObject g = Instantiate(gameObject);
            g.transform.position = new Vector3(0, 5, 0);

            floorCon.ballCounter++;
        }
    }    
}
