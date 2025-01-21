using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    public Animator animator;
    public float speed_magnitude = 5.0f;
    public float walkSpeed = 5.0f; // Adjust the walk speed as needed
    public float runSpeed = 10.0f; // Adjust the run speed

    public float walkSpeed_f = 0.5f; // Adjust the walk speed as needed
    public float runSpeed_f = 0.7f; // Adjust the run speed as needed
    // Start is called before the first frame update
    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = (transform.right * x + transform.forward * z) * speed_magnitude * Time.deltaTime;
        transform.position += move;
        crouch(); //1. Call the function crouch
        
        setMovement(x,z);
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            animator.SetInteger("WeaponType_int", 1);
            animator.SetBool("Shoot_b", true);
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            animator.SetInteger("WeaponType_int", 0);
            animator.SetBool("Shoot_b", false);

        }
    }
    void crouch() //2. functions come one after the other
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            animator.SetBool("Crouch_b", true);
        }
        else if (Input.GetKeyUp(KeyCode.C))
        {
            animator.SetBool("Crouch_b", false);
        }
    }
    
    


    

    void setMovement(float x, float z)
    {
        // Calculate the speed based on player input magnitude
        float inputMagnitude = new Vector2(x, z).magnitude;
        // Determine whether the player is walking or running based on the input magnitude
        if (Input.GetKey(KeyCode.LeftShift) && inputMagnitude > 0.1f) // Check if LeftShift is pressed
        {
            animator.SetFloat("Speed_f", runSpeed_f);
            speed_magnitude = runSpeed;
        }
        else if (inputMagnitude > 0.1f)
        {
            animator.SetFloat("Speed_f", walkSpeed_f);
            speed_magnitude = walkSpeed;
        }
        else
        {
            animator.SetFloat("Speed_f", 0.0f);
        }
    }

}