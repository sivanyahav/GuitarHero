using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCubeColor : MonoBehaviour
{
    public GameObject cube;
    private Renderer cubeRenderer;
    float rand; 
    void Start(){

        //Get the Renderer component from the new cube
        cubeRenderer = cube.GetComponent<Renderer>();

        //Call SetColor using the shader property name "_Color" and setting the color to red
        rand = Random.Range(0,4);
        if(rand < 1){ // color is red
            cubeRenderer.material.SetColor("_Color", Color.red);
        }
        else if(rand>1 && rand <3){ //color is blue
            cubeRenderer.material.SetColor("_Color", Color.blue);
        }
        else { // color is yellow
            cubeRenderer.material.SetColor("_Color", Color.yellow);
        }
    }


}
