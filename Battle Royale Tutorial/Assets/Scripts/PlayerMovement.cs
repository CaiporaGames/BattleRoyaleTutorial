using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float sensitivity;
    [SerializeField] float minView;
    [SerializeField] float maxView;
    [SerializeField] Transform cameraTransform;



    CharacterController cc;
    Vector3 move;
    float mouseX;
    float mouseY;


    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        Look();
    }

    void MovePlayer()
    {
        move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        move = Vector3.ClampMagnitude(move, 1);
        move = transform.TransformDirection(move);
        cc.SimpleMove(speed * move);
    }

    void Look()
    {
        mouseX = Input.GetAxis("Mouse X") * sensitivity;
        transform.Rotate(0, mouseX, 0);

        mouseY -= Input.GetAxis("Mouse Y") * sensitivity;
        mouseY = Mathf.Clamp(mouseY, minView, maxView);
        cameraTransform.localRotation = Quaternion.Euler(mouseY, 0,0);
    }
}
