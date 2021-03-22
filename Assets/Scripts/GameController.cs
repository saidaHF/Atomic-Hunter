using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    GameState gameState = GameState.Idle;

    void StartGame() {
        this.gameState = GameState.Playing;
    }

    void EndGame()  {
        this.gameState = GameState.Idle;
    }

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }
}
