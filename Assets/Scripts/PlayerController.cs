using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  public float horizontalInput;
  public float verticalInput;
  public float speed = 10.0f;
  public float xRange = 15.0f;
  public float zRange = 6.0f;
  public int score = 0;
  public int lives = 3;
  public bool gameOver;

  public GameObject projectilePrefab;

  // Start is called before the first frame update
  void Start()
  {
    gameOver = false;
    Debug.Log("Lives: " + lives);
    Debug.Log("Score: " + score);

  }

  // Update is called once per frame
  void Update()
  {
    // Keep the player in bounds
    if (transform.position.x < -xRange)
    {
      transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
    }
    if (transform.position.x > xRange)
    {
      transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
    }
    if (transform.position.z < 0)
    {
      transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }
    if (transform.position.z > zRange)
    {
      transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
    }

    if (!gameOver)
    {
      horizontalInput = Input.GetAxis("Horizontal");
      transform.Translate(horizontalInput * speed * Time.deltaTime * Vector3.right);

      verticalInput = Input.GetAxis("Vertical");
      transform.Translate(verticalInput * speed * Time.deltaTime * Vector3.forward);
    }

    if (Input.GetKeyDown(KeyCode.Space) && !gameOver)
    {
      Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
    }

    if (lives == 0)
    {
      gameOver = true;
    }
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.CompareTag("Enemy") && !gameOver)
    {
      lives--;
      Debug.Log("Lives: " + lives);

      if (lives == 0)
      {
        Debug.Log("Game Over!");
      }
    }
  }
}
