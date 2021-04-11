using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour {

    [Tooltip("Vida total")]
    public int maxHP;
    [Tooltip("Vida actual")]
    public int actualHP;

    // Start is called before the first frame update
    void Start() {
       actualHP = maxHP; 
    }

    // Update is called once per frame
    void Update() {  
        
    }
    // Function DoDamage: -1 HP and destroy of gameObject if die (HP == 0)
    public void DoDamage() {
        if (--actualHP <= 0) {
            if (!(gameObject.tag == "Player")) {
                // Only enemies
                Destroy(gameObject);
            }
            
        }
    }
}
