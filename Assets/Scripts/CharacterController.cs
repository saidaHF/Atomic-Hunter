using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour { 
    public Transform RespawnPoint;
    public RectTransform GameOverMenu; 
    Rigidbody2D body;
    float horizontal;
    float vertical;
    bool lookingRight; 
    bool touch = true;
    [Tooltip("Velocidad")]
    public float runSpeed = 20.0f;
    public static CharacterController Instance { private set; get; }
    public HealthController health;
    public MenuController menuController;
    public GameController gameController;

    private void Awake(){
        if(Instance == null){
            Instance = this;
        } else {
            Destroy(gameObject);
        }
        health = GetComponent<HealthController>();
    }    

    // Start is called before the first frame update
    void Start() {
        body = GetComponent<Rigidbody2D>();
        this.lookingRight = true;
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }
    void Update () {
        if (!gameController.paused) {
            // Edit -> Project Settings -> Input Manager -> Axes
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");

            if ((horizontal == 1 && !lookingRight) || (horizontal == -1 && lookingRight)) {
                this.Flip();
            }
        }
    }
    void FixedUpdate() {  
        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }
    // Flip() - so that the object looks away
    void Flip() {
        lookingRight = !lookingRight;
        transform.Rotate(0f, 180f, 0f);
    }
    private void OnCollisionStay2D(Collision2D collision) {
        if (!gameController.paused) {
            if (touch && collision.gameObject.tag == "Enemy") {
                StartCoroutine(touchAndDamage(1f));
            }
        }
    }

    private IEnumerator touchAndDamage(float waitTime) {
        touch = false;
        Renderer render = GetComponent<Renderer>();
        render.material.color = Color.magenta;
        HealthController health = gameObject.GetComponent<HealthController>();   
        if (health) {
            health.DoDamage();
        }  
        // Dead
        if (health.actualHP == 0) {
            menuController.Retry();
        }
        yield return new WaitForSeconds(0.5f);
        render.material.color = Color.white;
        yield return new WaitForSeconds(waitTime);
        touch = true;
   }

   public void Respawn() {
       SceneManager.LoadScene(SceneManager.GetActiveScene().name);
       //gameObject.transform.position = new Vector2(RespawnPoint.transform.position.x, RespawnPoint.transform.position.y);
       //gameObject.GetComponent<HealthController>().actualHP = 3;
   }

   private void OnDestroy(){
       Instance = null;
   }
}    





