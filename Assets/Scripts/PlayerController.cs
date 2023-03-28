using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;

    private Animator anim;
    private float jumpForce = 100f;
    private float gravityMod = 15f;
    private bool isGrounded = true;

    private bool isDead = false;

    private const string animDeathID = "Death1";
    private const string animJumpID = "NormalJump";
    private const string animRunID = "NormalRun";

    private AudioSource audioSrc;

    public AudioClip jumpSound;
    public AudioClip explosionSound;

    public ParticleSystem splatter;
    public ParticleSystem explosion;

    private void Awake(){
        playerRb = GetComponent<Rigidbody>();
        audioSrc = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        anim.SetBool(animRunID, true);
    }

    public bool areWeDead(){
        return isDead;
    }

    public void die(){
        Debug.Log("It looks like you died. ");
        anim.SetTrigger(animDeathID);
        explosion.Play();
        audioSrc.PlayOneShot(explosionSound);
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
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded && !isDead){
            
            anim.SetTrigger(animJumpID);
            
            splatter.Stop();
            audioSrc.PlayOneShot(jumpSound);
            
            float mass = gameObject.GetComponent<Rigidbody>().mass;
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * mass * jumpForce,ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision){
        Debug.Log("I touched " + collision.gameObject.name);
        if(collision.gameObject.CompareTag("Ground")){
            Debug.Log("Enter ground");
            splatter.Play();
            isGrounded = true;
        }else if(collision.gameObject.CompareTag("Obstacle")){
            // die internally
            die();
        }
    }
}
