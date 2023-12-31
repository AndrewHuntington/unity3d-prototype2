﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
  public GameObject[] ballPrefabs;

  private float spawnLimitXLeft = -22;
  private float spawnLimitXRight = 7;
  private float spawnPosY = 30;

  // Start is called before the first frame update
  void Start()
  {
    // Start the spawning process
    StartCoroutine(SpawnRandomBallWithDelay());
  }
  IEnumerator SpawnRandomBallWithDelay()
  {
    while (true)
    {
      float delay = Random.Range(3f, 5f);
      Debug.Log(delay);
      yield return new WaitForSeconds(delay);

      SpawnRandomBall();
    }
  }

  // Spawn random ball at random x position at top of play area
  void SpawnRandomBall()
  {
    int ballIndex = Random.Range(0, ballPrefabs.Length);
    // Generate random ball index and random spawn position
    Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

    // instantiate ball at random spawn location
    Instantiate(ballPrefabs[ballIndex], spawnPos, ballPrefabs[ballIndex].transform.rotation);
  }
}
