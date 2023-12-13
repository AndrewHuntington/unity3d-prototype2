using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
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

  }

  private void OnTriggerEnter(Collider other)
  {
    if (!other.CompareTag("Player"))
    {
      Destroy(gameObject);
      Destroy(other.gameObject);
      player.score++;
      Debug.Log("Score: " + player.score);
    }

  }
}
