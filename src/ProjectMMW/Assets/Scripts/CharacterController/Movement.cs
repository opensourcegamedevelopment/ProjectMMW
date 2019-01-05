using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 0.5f;

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
        if (Input.GetKey(KeyCode.W))
        {
            float tempRotationY = cameraPivot.transform.eulerAngles.y;

            //reset camera roation
            cameraPivot.GetComponent<CameraPivot>().rotationX = 0;

            //rotate object along with camera
            transform.localRotation = Quaternion.Euler(0, tempRotationY, 0);
            
            characterController.Move(transform.forward * speed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            characterController.Move(-transform.forward * speed / 2);
        }

        if (Input.GetKey(KeyCode.A))
        {
            characterController.Move(-transform.right * speed / 2);
        }

        if (Input.GetKey(KeyCode.D))
        {
            characterController.Move(transform.right * speed / 2);
        }


    }
}
