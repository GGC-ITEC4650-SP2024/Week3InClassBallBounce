using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FloorController : MonoBehaviour
{
    public int ballCounter;

    Text gameOverTxt;

    // Start is called before the first frame update
    void Start()
    {
        gameOverTxt = GameObject.Find("GameOverMsg").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump")) {
            if(Time.timeScale == 0) {
                gameOverTxt.text = "";
                Time.timeScale = 1;
                SceneManager.LoadScene(0); 
            }
        }        
    }

    //Called when my gameObject collides with another
    //Requires at least 1 of the gameObjects to have a Rigidbody.
    private void OnTriggerEnter(Collider other) {
        // a ball just fell through me
        ballCounter--;
        if(ballCounter <= 0){
            // pause game
            Time.timeScale = 0;
            gameOverTxt.text = "Game Over\nSpace to Restart";
        }
        
    }
}
