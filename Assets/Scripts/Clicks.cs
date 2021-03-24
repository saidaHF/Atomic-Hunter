using UnityEngine;
using System.Collections;

// Detects clicks from the mouse and prints a message
// depending on the click detected.

public class Clicks : MonoBehaviour
{
    void Update()
    {
        // Pabsorb shot
        if (Input.GetMouseButtonDown(0)) {
            
            Debug.Log("Pressed primary button.");  
        }
          
        // Pabsorb absorb
        if (Input.GetMouseButtonDown(1)) {

            Debug.Log("Pressed secondary button.");
        }
            
    }
}
