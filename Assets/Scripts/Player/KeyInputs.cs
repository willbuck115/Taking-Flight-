using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class KeyInputs : MonoBehaviour
{
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
    }
}
