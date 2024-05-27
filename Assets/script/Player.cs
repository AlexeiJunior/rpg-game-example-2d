using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public float speed = 1;
	private Animator anim;
	private Rigidbody2D rb;
	private bool playerMoving;
	private Vector2 lastMove;
	private static bool playerExist;

	void Start () {
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();

		if(!playerExist){
			DontDestroyOnLoad(transform.gameObject);
			playerExist = true;
		}else{
			Destroy(gameObject);
		}
	}
	
	void Update () {
		playerMoving = false;

		if(Input.GetAxisRaw("Horizontal") > 0.1f || Input.GetAxisRaw("Horizontal") < -0.1f){
			//transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime,0,0));
			rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, rb.velocity.y);
			playerMoving = true;
			lastMove = new Vector2(Input.GetAxisRaw("Horizontal"),0);
		}
		if(Input.GetAxisRaw("Vertical") > 0.1f || Input.GetAxisRaw("Vertical") < -0.1f){
			//transform.Translate(new Vector3(0,Input.GetAxisRaw("Vertical") * speed * Time.deltaTime,0));
			rb.velocity = new Vector2(rb.velocity.x, Input.GetAxisRaw("Vertical") * speed);
			playerMoving = true;
			lastMove = new Vector2(0,Input.GetAxisRaw("Vertical"));
		}

		if(Input.GetAxisRaw("Horizontal") < 0.1f && Input.GetAxisRaw("Horizontal") > -0.1f) rb.velocity = new Vector2(0, rb.velocity.y);
		if(Input.GetAxisRaw("Vertical") < 0.1f && Input.GetAxisRaw("Vertical") > -0.1f) rb.velocity = new Vector2(rb.velocity.x, 0);

		anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
		anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
		anim.SetFloat("LastMoveX", lastMove.x);
		anim.SetFloat("LastMoveY", lastMove.y);
		anim.SetBool("PlayerMoving", playerMoving);
	}

	public void setLastMove(Vector2 lastMove){
		this.lastMove = lastMove;
	}
}
