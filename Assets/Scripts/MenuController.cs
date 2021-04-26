using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour {

    public GameController gameController;
    public GameObject canvas;
    public GameObject startMenu;
    public GameObject hud;
    public GameObject background;
    public GameObject buttons;
    public GameObject playButton;
    public GameObject retryButton;
    public GameObject resumeButton;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ActivateMenu() {
        canvas.SetActive(true);
        startMenu.SetActive(true);
        hud.SetActive(true);
        background.SetActive(true);
        buttons.SetActive(true);
    }

    void ManageButtons(bool playState, bool retryState, bool resumeState) {
        ActivateMenu();
        playButton.SetActive(playState);
        retryButton.SetActive(retryState);
        resumeButton.SetActive(resumeState);
    }

    public void Play() {
        ManageButtons(true, false, false);
    }

    public void Retry() {
        gameController.paused = true;
        ManageButtons(false, true, false);
    }
    
    public void Resume() {
        ManageButtons(false, false, true);
    }
}
