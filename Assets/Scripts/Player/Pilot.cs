using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pilot : MonoBehaviour {

    public float maxSpeed = 10f;
    public float rotSpeed;

    bool isUsingController = false;

    [Range(0.7f, 1f)]
    public float throttle;
    public Vector2 smoothingValue;

    float yRot;

    public float CalculateSpeed() {

        float currentSpeed;
        currentSpeed = maxSpeed * throttle;

        return currentSpeed;
    }

    void Update() {

        float currentSpeed = CalculateSpeed();
        transform.position += transform.forward * Time.deltaTime * currentSpeed;

        if (Input.GetJoystickNames().Length > 0) {
            // CONTROLLER INPUT
            if (Input.GetAxis("Right Trigger") > 0) {
                if (throttle < 1) {
                    throttle += .01f;
                }
            } else if (Input.GetAxis("Right Trigger") <= 0) {
                if (throttle >.85f)
                    throttle -= .01f;
            }

            if (Input.GetAxis("Left Trigger") > 0) {
                if (throttle >.7f)
                    throttle -= .01f;
            } else if (Input.GetAxis("Left Trigger") <= 0) {
                if (throttle < .85f)
                    throttle += .01f;
            }
            transform.Rotate(Input.GetAxis("Vertical") * smoothingValue.y * Time.deltaTime, 0, -Input.GetAxis("Horizontal") * smoothingValue.x * Time.deltaTime);
            print("Controller");
        }
        // KEYBOARD INPUT
        if (Input.GetKey(KeyCode.Q)) {
            if (throttle < 1) {
                throttle += .01f;
            }
        } else {
            if (throttle >.85f)
                throttle -= .01f;
        }
        if (Input.GetKey(KeyCode.E)) {
            if (throttle >.7f)
                throttle -= .01f;
        } else {
            if (throttle < .85f)
                throttle += .01f;
        }
        transform.Rotate(Input.GetAxis("VerticalKey") * smoothingValue.y * Time.deltaTime, 0, -Input.GetAxis("HorizontalKey") * smoothingValue.x * Time.deltaTime);
        print("Keyboard");
        Rudder();
    }

    void Rudder() {
        // THE RUDDER FUNCTION WORKS FOR BOTH KEYBOARD AND CONTROLLER AS INPUT HAS BEEN SET IN UNITY PLAYER SETTINGS
        if (Input.GetButton("Right Bumper")) {
            transform.Rotate(Vector3.up * rotSpeed * Time.deltaTime);
        } else if (Input.GetButton("Left Bumper")) {
            transform.Rotate(Vector3.down * rotSpeed * Time.deltaTime);
        }
    }

    void OnCollisionEnter(Collision collision) {
        print("Death");
        SceneManager.LoadScene(0);
    }
}