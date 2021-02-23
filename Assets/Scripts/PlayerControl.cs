using UnityEngine;
public class PlayerControl : MonoBehaviour{
	private Animator anim;
	private CharacterController controller;
	private Vector3 moveDirection;

	public float speed = 5.0f;
	public float gravity = 15.0f;
	public float jumpSpeed = 10.0f;
    private float animationDuration = 3.0f;

	void Start (){
		controller = GetComponent <CharacterController>();
		anim = gameObject.GetComponentInChildren<Animator>();
		anim.SetBool("isRunning",true);	
	}

	void Update (){
		if(Time.time < animationDuration){
	        controller.Move (new Vector3(0,0,speed)* Time.deltaTime);
			return;
		}

		if (controller.isGrounded){
            moveDirection = new Vector3 (Input.GetAxis ("Horizontal"), 0, speed);
            moveDirection = transform.TransformDirection (moveDirection);
			if(Input.GetButton("Jump")){
                moveDirection.y = jumpSpeed;
			}					
        }
        moveDirection.y -= (gravity*2) * Time.deltaTime;
        controller.Move (moveDirection* Time.deltaTime);
		if(Input.GetKeyDown(KeyCode.LeftArrow)){
			transform.Rotate(0,-90,0);
		}
		if(Input.GetKeyDown(KeyCode.RightArrow)){
			transform.Rotate(0,90,0);
		}
	}
}
