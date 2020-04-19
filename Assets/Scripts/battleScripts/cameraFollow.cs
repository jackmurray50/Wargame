using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/*
This is the script that forces the camera to follow the cameraController. It'll handle the cameras rotation
and zoom distance. 
*/

public class cameraFollow : MonoBehaviour
{
    private float rotationSpeed = 2f;
    private Transform cameraController;
    private InputMaster controls;
    float zoomInput = 0f;
    float rotateInput = 0f;
    Vector3 offset;

    private int frameWait = 2;
    private bool zooming = false;

    float rotationAngle = 180f;

    void Awake(){
        //Set offset to a reasonable level
        offset = new Vector3(0,10,2);
        controls = new InputMaster();

        controls.battleInputs.CameraRotation.performed += e => {
            rotateInput = e.ReadValue<float>();        
        };
        controls.battleInputs.CameraRotation.canceled += e => {
            //tell the camera to stop rotating
            rotateInput = 0; 
        }; 
        //When a player scrolls in or out, tell the camera to zoom in
        controls.battleInputs.CameraZoom.started += e =>{
            zoomInput = -e.ReadValue<float>();
            zooming = true;
        };

        //Set camera to the proper camera object
        bool foundCamera = false;
        for(int i = 0; i < transform.parent.childCount && !foundCamera; i++){
            if(transform.parent.GetChild(i).name == "CameraController"){
                cameraController = transform.parent.GetChild(i);
                foundCamera = true;
            }
        }
        if(!foundCamera){
            Debug.Log("Camera not found");
        }
        

    }

    void FixedUpdate(){
        
        zoomCamera(zoomInput);
        rotateCamera(rotateInput);
        transform.position = cameraController.position + offset;
        transform.LookAt(cameraController);
        if(zooming){
            if(frameWait == 0){
                frameWait = 2;
                zoomInput = 0;
                zooming = false;
            }else{
                frameWait--;
            }
        }
        
        
    }

    void rotateCamera(float direction){
        //Move the camera in an arc around a fixed point, while enforcing its look-at direction.
        //Essentially just making the camera follow a circle around the cameraController
        if(direction != 0){
            //Get the desired angle
            rotationAngle += direction *rotationSpeed;

            if(rotationAngle > 360){
                rotationAngle -= 360;
            }
            if(rotationAngle < 0){
                rotationAngle += 360;
            }
            //Getting radius by figuring out the hypotenuse of X and Z, making sure to absolute it
            float radius = Mathf.Abs(Mathf.Sqrt(Mathf.Pow(offset.x, 2) + Mathf.Pow(offset.z, 2)));
            Debug.Log(rotationAngle);
            //Set the X and Z coordinates to comply with the new rotation angle while maintaining the same radius
            offset = new Vector3(radius *Mathf.Cos(rotationAngle * Mathf.PI/180), offset.y, radius * Mathf.Sin(rotationAngle * Mathf.PI/180));
        }
    }
    void zoomCamera (float direction){
        //Check to make sure that the camera wants to move before bothering with taking up resources
        if(direction != 0){
            //'scale' the offset relative to the distance between offset and camera, constraining it to a few units
            direction /= 120;
            direction *= 1.3f; //Setting sensitivity
            //Make sure to scale the offset relative to how close it is to the item. IT should be a logarithmic functionz
            Vector3 newOffset = new Vector3(offset.x, 
                offset.y + direction, offset.z);
            //Make sure that the new offset is within acceptable parameters. If so, commit it.
            if(newOffset.y > 10 && newOffset.y < 35)
                offset = newOffset;
        }
    }//end zoomCamera

    void OnEnable(){
        controls.Enable();
    }
    void OnDisable(){
        controls.Disable();
    }

    void Start(){
        // rotateCamera(1);
        // rotateCamera(-1);
    }

    Vector3 RotateAroundPoint(Vector3 point, Vector3 pivot, Quaternion angle){
        return angle * (point - pivot) + pivot;
    }
}
