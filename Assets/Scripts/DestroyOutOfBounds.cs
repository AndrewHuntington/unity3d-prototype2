using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
  private float topBound = 30.0f;
  private float lowerBound = -10.0f;
  private float leftBound = -25.0f;
  private float rightBound = 25.0f;
  public PlayerController player;

  // Start is called before the first frame update
  void Start()
  {
    GameObject playerObject = GameObject.Find("Player");
    if (playerObject != null)
    {
      player = playerObject.GetComponent<PlayerController>();
    }
  }

  // Update is called once per frame
  void Update()
  {
    if (transform.position.z > topBound || transform.position.x < leftBound || transform.position.x > rightBound)
    {
      Destroy(gameObject);
    }
    else if (transform.position.z < lowerBound)
    {
      Destroy(gameObject);

      // Currently only takes a life if an animal goes past the lower boundary
      // Animals that go through the left and right boundaries are destroyed, but do not take a life
      if (!player.gameOver)
      {
        player.lives--;
        Debug.Log("Lives: " + player.lives);

        if (player.lives == 0)
        {
          Debug.Log("Game Over!");
        }
      }
    }
  }
}
