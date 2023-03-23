using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody playerRb;
    private float jumpForce = 100f;
    private float gravityMod = 15f;
    private bool isGrounded = true;

    private bool isDead = false;

    public bool areWeDead(){
        return isDead;
    }

    public void die(){
        isDead = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravityMod;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded ){
            float mass = gameObject.GetComponent<Rigidbody>().mass;
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * mass * jumpForce,ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision){
        Debug.Log("I touched " + collision.gameObject.name);
        if(collision.gameObject.CompareTag("Ground")){
            Debug.Log("Enter ground");
            isGrounded = true;
        }else if(collision.gameObject.CompareTag("Obstacle")){
            // die internally
            die();
        }
    }
}
