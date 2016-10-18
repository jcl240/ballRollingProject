using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	public float jumpForce = 1000f;
	public Transform groundCheck;
	public Camera mainCamera;
	[HideInInspector] public bool jump = false;

	private Rigidbody rb;
	private bool grounded = false;

	void Awake()
	{
		groundCheck = GameObject.Find("groundCheck").transform;
		mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
	}
	void Start ()
	{
		rb = GetComponent<Rigidbody>();
	}

	void Update()
	{
		grounded = Physics.Linecast (transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
		if (Input.GetKeyDown ("space") && grounded) {
			jump = true;
		}
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		mainCamera.transform.RotateAround(transform.position, Vector3.up, moveHorizontal);

		Vector3 movement = mainCamera.transform.forward * moveVertical;
		rb.AddForce (movement * speed);

		if (jump) {
			rb.AddForce (new Vector2 (0f, jumpForce));
			jump = false;
			/*notGrounded = true*/;
		}


	}
}