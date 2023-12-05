using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
  public GameObject dogPrefab;
  private float timeSinceLastInstantiation = 0f;
  public float instantiationDelay = 0.5f;

  // Update is called once per frame
  void Update()
  {
    // Update the timer
    timeSinceLastInstantiation += Time.deltaTime;

    // Check if spacebar is pressed and if the delay has passed
    // If so, send dog
    if (Input.GetKeyDown(KeyCode.Space) && timeSinceLastInstantiation >= instantiationDelay)
    {
      Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);

      // Reset the timer after instantiation
      timeSinceLastInstantiation = 0f;
    }


  }
}
