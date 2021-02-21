using UnityEngine;

// Include the namespace required to use Unity UI and Input System
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{

	// Create public variables for player speed, gun kickback, and health
	public float speed;
	public float kickback;
	public int health = 3;

	private float movementX;
	private float movementY;

	private Rigidbody rb;

	public GameObject currentGun;
	private SimpleShoot gun;
	private Transform directionTransform;
	public PlayerManager manager;
	public Material[] playerColor; //create an index for the different player colors

	private MeshRenderer material;

	public bool ready = false;

	// At the start of the game..
	void Start()
	{
		manager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>(); //grabs the PlayerManager class from the PlayerManager object
		material = GetComponent<MeshRenderer>();

        switch (manager.spawnLocation) //handles spawning players with different properties
        {
			case 1:
				this.gameObject.transform.position = new Vector3(-5f, 0.5f, 5f); //sets player spawn location
				material.material = playerColor[0]; //changes the color for each player
				gameObject.name = "Player1"; //sets the name of this player for the playermanager script
				break;
			case 2:
				this.gameObject.transform.position = new Vector3(5f, 0.5f, 5f);
				material.material = playerColor[1];
				gameObject.name = "Player2";
				break;
			case 3:
				this.gameObject.transform.position = new Vector3(5f, 0.5f, -5f);
				material.material = playerColor[2];
				gameObject.name = "Player3";
				break;
			case 4:
				this.gameObject.transform.position = new Vector3(-5f, 0.5f, -5f);
				material.material = playerColor[3];
				gameObject.name = "Player4";
				break;
        }

		// Assign the Rigidbody component to our private rb variable
		rb = GetComponent<Rigidbody>();

		//Set variable "gun" to the "SimpleShoot" script on the player's currentGun object.
		gun = currentGun.GetComponent<SimpleShoot>();


	}

    private void Update()
    {
        if(health <= 0) //if the player's health reaches 0
        {
			//you lose

			Destroy(this.gameObject);
        }
    }

    void FixedUpdate()
	{
		// Create a Vector3 variable, and assign X and Z to feature the horizontal and vertical float variables above
		Vector3 movement = new Vector3(movementX, 0.0f, movementY);

		rb.AddForce(movement * speed);
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "bullet") //if the player is hit by a bullet
        {
			health--;
			Debug.Log("I've been shot!");
        }
    }

	void OnMove(InputValue value)
	{
		if(manager.playersReady == true)
        {
			Vector2 v = value.Get<Vector2>();

			movementX = v.x;
			movementY = v.y;
		}
	}
	void OnFire()
	{
		if(manager.playersReady == false)
        {
			if(ready == false)
            {
				ready = true;
            }

            else
            {
				ready = false;
            }
        }

        else
        {
			Vector3 knockbackForce = new Vector3(Vector3.back.x, 0.0f, Vector3.back.z);

			//apply gun kickback to ball
			rb.AddRelativeForce(knockbackForce * kickback, ForceMode.Impulse);

			//Run the shoot and casing release functions on the SimpleShoot script
			gun.Shoot();
			gun.CasingRelease();

			Debug.Log("Fire");
		}

	}

}
