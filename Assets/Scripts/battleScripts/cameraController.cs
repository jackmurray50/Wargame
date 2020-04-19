using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class cameraController : MonoBehaviour
{
    private float screenSensitivityModifier = 10;

    //Reference to the inputmaster class, which handles inputs
    InputMaster controls; 
    [SerializeField]
    GameSettings gs;
    Transform follower;

    //Saves the direction in which the player wants to go as a 2d axis
    Vector2 movementInput = new Vector2(0,0);

    void Awake(){
        controls = new InputMaster();
        follower = transform.parent.GetComponentInChildren<cameraFollow>().transform;
        //When the player presses a movement key, set the movementInput to the proper values
        controls.battleInputs.CameraMovement.performed += e =>movementInput = e.ReadValue<Vector2>();
        //When the player stops pressing a key, reset the movementInput
        controls.battleInputs.CameraMovement.canceled += e => {
            movementInput.x = 0;
            movementInput.y = 0;
        };
        //If the mouse is on an edge of the screen, move it
        controls.battleInputs.MousePosition.performed += e => {
            //Width handling
            if(e.ReadValue<Vector2>().x > Screen.width * .99){
                movementInput.x = 1;
            }else if(e.ReadValue<Vector2>().x < Screen.width * .01){
                movementInput.x = -1;
            }else{
                movementInput.x = 0;
            }
            if(e.ReadValue<Vector2>().y > Screen.height * .99){
                movementInput.y = 1;
            }else if(e.ReadValue<Vector2>().y < Screen.height * .01){
                movementInput.y = -1;
            }else{
                movementInput.y = 0;
            }
        };


    }

    void Start(){
        
    }

    void OnEnable(){
        controls.Enable();
    }
    void onDisable(){
        controls.Disable();
    }

    void FixedUpdate(){        
        moveCamera(movementInput);
    }

    //Works out which way the player wants the camera moved, if at all, and performs the movement.
    void moveCamera(Vector2 direction){
        //Move the object in the direction the player's asking it to
        float cameraHeight = follower.position.y / 5;
        transform.rotation = follower.rotation;
        float y = transform.position.y;
        this.transform.Translate(direction.x * Time.deltaTime * screenSensitivityModifier * cameraHeight, 0,
            direction.y * Time.deltaTime * screenSensitivityModifier * cameraHeight *5);
        this.transform.position = new Vector3(transform.position.x, y, transform.position.z);
        //TODO: Clamp the controller to the map size

        
    }

    public void snapTo(GameObject target){
        transform.position = target.transform.position;
    }
    
}

