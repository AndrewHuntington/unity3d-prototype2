using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  public float health;
  public float maxHealth;
  [SerializeField] FloatingHealthBar healthBar;
  [SerializeField] PlayerController player;


  void Awake()
  {
    GameObject playerObject = GameObject.Find("Player");
    if (playerObject != null)
    {
      player = playerObject.GetComponent<PlayerController>();
    }

    healthBar = GetComponentInChildren<FloatingHealthBar>();
    healthBar.UpdateHealthBar(health, maxHealth);
  }

  // Update is called once per frame
  void Update()
  {

  }

  private void OnTriggerEnter(Collider other)
  {
    if (!other.CompareTag("Player") && health <= 1)
    {
      health--;
      healthBar.UpdateHealthBar(health, maxHealth);

      Destroy(gameObject);
      Destroy(other.gameObject);
      Destroy(healthBar);
      player.score++;
      Debug.Log("Score: " + player.score);
    }
    else if (!other.CompareTag("Player"))
    {
      health--;
      healthBar.UpdateHealthBar(health, maxHealth);
      Destroy(other.gameObject);
    }

  }
}
