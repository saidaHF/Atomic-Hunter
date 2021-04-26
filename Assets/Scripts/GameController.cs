using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
public MenuController menuController;

public bool paused;

// Start is called before the first frame update
void Start() {
    paused = true;
}
// Update is called once per frame
void Update() {
    // PAUSED:
    if (Input.GetKeyDown(KeyCode.Escape)) {
        PausaJuego();  
    } 
}
// For quit:
public void Quit() {
    Application.Quit();
    Debug.Log("EXIT GAME");
}
public void PausaJuego() {
    paused = !paused; 

    if (paused) {
        Time.timeScale = 0;
        menuController.Resume();
    } else {
        Time.timeScale = 1;    
    }
}
}
