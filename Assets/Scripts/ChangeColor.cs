using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public GameObject bottom;
    private Renderer bottomRenderer;

    float coolDown= 0.1f;
    float timeStamp;
    bool canChange = true;

    void Update(){
        //Get the Renderer component from the new cube
        bottomRenderer = bottom.GetComponent<Renderer>();

        //Call SetColor using the shader property name "_Color" and setting the color to red
        if(canChange && Input.GetKeyDown(KeyCode.Z)){ // color is red
           bottomRenderer.material.SetColor("_Color", Color.red);
           changeToWhite();
        }
        else if(canChange && Input.GetKeyDown(KeyCode.X)){ //color is blue
            bottomRenderer.material.SetColor("_Color", Color.blue);
            changeToWhite();
        }
        else if(canChange && Input.GetKeyDown(KeyCode.C)) { // color is yellow
            bottomRenderer.material.SetColor("_Color", Color.yellow);
            changeToWhite();
        }
        else if(Time.time >= timeStamp){
            bottomRenderer.material.SetColor("_Color", Color.white);
            canChange = true;
        }
    }

    void changeToWhite(){
        timeStamp= Time.time + coolDown;
        canChange = false;
    }

}
