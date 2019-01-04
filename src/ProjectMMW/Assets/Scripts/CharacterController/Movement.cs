using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    CharacterController characterController;

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
            characterController.Move(Vector3.forward);
            //transform.Translate(Vector3.forward);
        }

        if (Input.GetKey(KeyCode.S))
        {
            characterController.Move(Vector3.back);
            //transform.Translate(Vector3.back);
        }

        if (Input.GetKey(KeyCode.A))
        {
            characterController.Move(Vector3.left);
            //transform.Translate(Vector3.left);
        }

        if (Input.GetKey(KeyCode.D))
        {
            characterController.Move(Vector3.right);
            //transform.Translate(Vector3.right);
        }
    }
}
