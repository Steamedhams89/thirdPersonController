using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f; //meters per second, shows up in inspector and can be edited.(public)
    public float rotationSpeed = 280.0f;

    float horizontal;
    float vertical;      //float variables that hold horizontal and vertical input



    private void Update()
    {
        Vector3 moveDirection = Vector3.forward * vertical + Vector3.right * horizontal;  //player movement

       
        Vector3 projCamForward = Vector3.ProjectOnPlane(Camera.main.transform.forward, Vector3.up);
        Quaternion rotationToCam = Quaternion.LookRotation(projCamForward, Vector3.up); 

        moveDirection = rotationToCam * moveDirection;
        Quaternion rotationToMoveDirection = Quaternion.LookRotation(moveDirection, Vector3.up);
        
        
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotationToMoveDirection, rotationSpeed * Time.deltaTime);

        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    public void onMoveInput(float horizontal, float vertical)
    {
        this.vertical = vertical;
        this.horizontal = horizontal;
        Debug.Log($"i farted {vertical}, {horizontal}");
    }


}
