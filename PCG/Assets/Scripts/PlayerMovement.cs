using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] CharacterController playerController;
    [SerializeField] float playerSpeed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            playerController.Move(new Vector3(0, 0, 1) * Time.deltaTime * playerSpeed);
        }
        if(Input.GetKey(KeyCode.A))
        {
            playerController.Move(new Vector3(-1, 0, 0) * Time.deltaTime * playerSpeed);
        }
        if(Input.GetKey(KeyCode.S))
        {
            playerController.Move(new Vector3(0, 0, -1) * Time.deltaTime * playerSpeed);
        }
        if(Input.GetKey(KeyCode.D))
        {
            playerController.Move(new Vector3(1, 0, 0) * Time.deltaTime * playerSpeed);
        }
    }
}
