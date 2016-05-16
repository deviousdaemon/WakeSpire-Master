using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    private float moveSpeed;
    private float walkSpeed;
    private Animator animator;
    private bool playerMoving;
    private Vector2 lastMove;

	// Use this for initialization
	void Start () {
        walkSpeed = 4f;
        moveSpeed = 6f;
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        playerMoving = false;
        //Walking
        if (Input.GetAxisRaw("Horizontal") >= 0.35 && Input.GetAxisRaw("Horizontal") < 0.75 || Input.GetAxisRaw("Horizontal") <= -0.35 && Input.GetAxisRaw("Horizontal") > -0.75){
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * walkSpeed * Time.deltaTime, 0f, 0f));
            playerMoving = true;
            lastMove = new Vector2(Input.GetAxis("Horizontal"), 0f);
        }

        if (Input.GetAxisRaw("Vertical") >= 0.35 && Input.GetAxisRaw("Vertical") < 0.75 || Input.GetAxisRaw("Vertical") <= -0.35 && Input.GetAxisRaw("Vertical") > -0.75) {
            transform.Translate(new Vector3(0, Input.GetAxisRaw("Vertical") * walkSpeed * Time.deltaTime, 0f));
            playerMoving = true;
            lastMove = new Vector2(0f, Input.GetAxis("Vertical"));
        }

        //Running
        if (Input.GetAxisRaw("Horizontal") >= 0.75 || Input.GetAxisRaw("Horizontal") <= -0.75) {
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
            playerMoving = true;
            lastMove = new Vector2(Input.GetAxis("Horizontal"), 0f);
        }

        if (Input.GetAxisRaw("Vertical") >= 0.75 || Input.GetAxisRaw("Vertical") <= -0.75) {
            transform.Translate(new Vector3(0, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
            playerMoving = true;
            lastMove = new Vector2(0f, Input.GetAxis("Vertical"));
        }
        animator.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        animator.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        animator.SetBool("PlayerMoving", playerMoving);
        animator.SetFloat("LastX", lastMove.x);
        animator.SetFloat("LastY", lastMove.y);
	}
}
