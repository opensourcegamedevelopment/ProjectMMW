using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 50f;
    public float gravity = 9.8f;
    public float jumpSpeed = 8;
    public float boostModifier = 3;
    public bool canHover = true;


    private float vSpeed = 0; // current vertical velocity
    private float boostSpeed = 1;


    CharacterController characterController;
    public Transform cameraPivot;

    // Start is called before the first frame update
    void Start()
    {
        characterController = gameObject.GetComponent<CharacterController>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            boostSpeed = boostModifier;
        }
        else
        {
            boostSpeed = 1;
        }

        Vector3 velocity = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            float tempRotationY = cameraPivot.transform.eulerAngles.y;

            //reset camera roation
            cameraPivot.GetComponent<CameraPivot>().rotationX = 0;

            //rotate object along with camera
            transform.localRotation = Quaternion.Euler(0, tempRotationY, 0);

            velocity = transform.forward * speed * boostSpeed;
            //characterController.Move(transform.forward * speed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            float tempRotationY = cameraPivot.transform.eulerAngles.y;

            //reset camera roation
            cameraPivot.GetComponent<CameraPivot>().rotationX = 0;

            //rotate object along with camera
            transform.localRotation = Quaternion.Euler(0, tempRotationY, 0);

            velocity = -transform.forward * speed * boostSpeed / 2;
            //characterController.Move(-transform.forward * speed / 2);
        }

        if (Input.GetKey(KeyCode.A))
        {
            velocity = -transform.right * speed * boostSpeed / 2;
            //characterController.Move(-transform.right * speed / 2);
        }

        if (Input.GetKey(KeyCode.D))
        {
            velocity = transform.right * speed * boostSpeed / 2;
            //characterController.Move(transform.right * speed / 2);
        }


        if (canHover)
        {
            if (Input.GetKey("space"))
            { // unless it jumps:
                vSpeed = jumpSpeed;
            }
        }
        else
        {
            if (characterController.isGrounded)
            {
                vSpeed = 0; // grounded character has vSpeed = 0...
                if (Input.GetKey("space"))
                { // unless it jumps:
                    vSpeed = jumpSpeed;
                }
            }
        }

        // apply gravity acceleration to vertical speed:
        vSpeed -= gravity * Time.deltaTime;
        velocity.y = vSpeed; // include vertical speed in vel

        characterController.Move(velocity * Time.deltaTime);
    }
}
