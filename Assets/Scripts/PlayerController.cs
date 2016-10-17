using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	public float jumpForce = 1000f;
	[HideInInspector] public bool jump = false;

	private Rigidbody rb;
	private bool notGrounded = false;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
	}

	void Update()
	{
		/*grounded = Physics2D.Linecast (transform.position, groundCheck.position, 1 << LayerMask.NameToLayer (currentPage));
		*/
		if (Input.GetKeyDown ("space")/* && notGrounded*/) {
			jump = true;
		}
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);

		if (jump) {
			rb.AddForce (new Vector2 (0f, jumpForce));
			jump = false;
			/*notGrounded = true*/;
		}


	}
}