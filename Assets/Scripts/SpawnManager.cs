using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
  public GameObject[] animalPrefabsTop;
  public GameObject[] animalPrefabsRight;
  public GameObject[] animalPrefabsLeft;
  private float spawnRangeX = 20f;
  public float spawnRangeZTop = 10f;
  public float spawnRangeZBottom = -1f;

  private float spawnPosZ = 20f;
  public float spawnPosX = 20f;
  private float startDelay = 2;
  private float spawnInterval = 1.5f;

  // Start is called before the first frame update
  void Start()
  {
    InvokeRepeating("SpawnRandomAnimalTop", startDelay, spawnInterval);
    InvokeRepeating("SpawnRandomAnimalRightSide", startDelay, spawnInterval);
    InvokeRepeating("SpawnRandomAnimalLeftSide", startDelay, spawnInterval);

  }

  // Update is called once per frame
  void Update()
  {

  }

  private void SpawnRandomAnimalTop()
  {
    int animalIndex = Random.Range(0, animalPrefabsTop.Length);
    Vector3 spawnPos = new(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);

    Instantiate(animalPrefabsTop[animalIndex], spawnPos, animalPrefabsTop[animalIndex].transform.rotation);
  }

  private void SpawnRandomAnimalRightSide()
  {
    int animalIndex = Random.Range(0, animalPrefabsRight.Length);

    Vector3 spawnPos = new(spawnPosX, 0, Random.Range(spawnRangeZBottom, spawnRangeZTop));
    Instantiate(animalPrefabsRight[animalIndex], spawnPos, animalPrefabsRight[animalIndex].transform.rotation);
  }

  private void SpawnRandomAnimalLeftSide()
  {
    int animalIndex = Random.Range(0, animalPrefabsRight.Length);

    Vector3 spawnPos = new(-spawnPosX, 0, Random.Range(spawnRangeZBottom, spawnRangeZTop));
    Instantiate(animalPrefabsLeft[animalIndex], spawnPos, animalPrefabsLeft[animalIndex].transform.rotation);

  }
}

