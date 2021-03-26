using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies_Controller : MonoBehaviour {

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

    // Function -1 HP and destroy of gameObject if die (HP == 0)
    public void Attacked() {
        if (--actualHP <= 0) {
            Destroy(gameObject);
        }
    }
}
