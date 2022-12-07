using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   
    // calls to other game objects
    public Transform orientation;

    public AudioSource walkingAudioSource;

    // Player Attributes
    public float playerSpeed = 6f;

    public float groundDrag;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;
    Rigidbody rb;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    private void Update()
    {
        MyInput();
        SpeedControl();

        rb.drag = groundDrag;
    }

    private void FixedUpdate(){
        MovePlayer();
    }

    // Get player inputs
    private void MyInput(){
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        // print($"horizontal: {horizontalInput} vertical: {verticalInput}");
    }

    // Calculate players movement to be applied and apply it
    private void MovePlayer(){
        if(GameManager.instance.playerHiddenState){
            return;
        }
        // calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        // print($"moveDirection: {moveDirection}");
        // apply the movement
        rb.AddForce(moveDirection.normalized * playerSpeed * 10f, ForceMode.Force);

        // play walking sounds if the player is walking
        if((verticalInput != 0 || horizontalInput != 0) && !walkingAudioSource.isPlaying){
            walkingAudioSource.Play();
        }
        if(verticalInput == 0 && horizontalInput == 0){
            walkingAudioSource.Stop();
        }
    }
    
    private void SpeedControl(){
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        if(flatVel.magnitude > playerSpeed){
            Vector3 limitedVel = flatVel.normalized * playerSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }
}
