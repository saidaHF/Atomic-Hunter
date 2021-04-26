using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
  public GameObject[] points;
  bool follow = false;
  public int speed;
  private float time;
  private int random;
  Transform playerPosition;

  public GameController gameController;
    // Start is called before the first frame update
    void Start() {
        playerPosition = GameObject.Find("Lire").transform; 
        random = Random.Range(0, points.Length);
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }
    // Update is called once per frame
    void Update() {
      if (!gameController.paused) {
        // Follow character
        if (follow) {
            transform.position = Vector2.MoveTowards(transform.position, playerPosition.position, speed * 1.5f * Time.deltaTime);
        } else { 
          // Patrol enemies 
          transform.position = Vector2.MoveTowards(transform.position, points[random].transform.position, speed * Time.deltaTime);
          time += Time.deltaTime;
          if (time >= 2) {
              random = Random.Range(0, points.Length);
              time = 0;
          }
        }
      }
    }
    private void OnTriggerEnter2D(Collider2D collision) {
      if (collision.gameObject.tag == "Player") {
          follow = true;
      }
    }
    private void OnTriggerExit2D(Collider2D collision) {
      if (collision.gameObject.tag == "Player") {
          follow = false;
      }
    }
}
