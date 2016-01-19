using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

  public float speed;
  public Text scoreText;
  public Text winText;
  public Rigidbody dummyPickUp;
  public float dummyVelocity;

  private Rigidbody playerBody;
  private int score;

	void Start ()
  {
    playerBody = GetComponent<Rigidbody>();
    score = 0;
    displayScore();
    winText.text = "";
	}

  void Update()
  {
    if (Input.GetButtonDown("Jump") || Input.GetButtonDown("Fire1"))
    {
      Vector3 belowPlayer = transform.position - new Vector3(0, 0.3f, 0);
      throwObject(dummyPickUp, belowPlayer);
    }
  }

	void FixedUpdate()
  {
	  float moveHorizontal = Input.GetAxis("Horizontal");
    float moveVertical = Input.GetAxis("Vertical");
    
    Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
    playerBody.AddForce (movement * speed);
	}

  void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.CompareTag("Pick Up"))
    {
      other.gameObject.SetActive(false);
      score++;
      displayScore();
    }
  }

  void displayScore()
  {
    int totaldummyPickUps = GameObject.FindGameObjectsWithTag("Pick Up").Length;
    scoreText.text = "Score: " + score.ToString();
    if (totaldummyPickUps == 0)
    {
      winText.text = "Got 'Em All!";
    }
  }

  void OnCollisionEnter(Collision col)
  {
    if (col.gameObject.tag == "Wall")
    {
      Vector3 abovePlayer = transform.position + new Vector3(0, 1, 0);
      throwObject(dummyPickUp, abovePlayer);
    }
  }

  /** Clones the prefab 'cloneObject', given its starting postion and veloicty. */
  void throwObject(Rigidbody clonedObject, Vector3 position)
  {
    Rigidbody clone;
    clone = Instantiate(clonedObject, position, transform.rotation) as Rigidbody;
    clone.AddForce(-position * -dummyVelocity);
  }
}
