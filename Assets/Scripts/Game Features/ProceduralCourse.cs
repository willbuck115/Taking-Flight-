using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralCourse : MonoBehaviour {

    int ringsSinceStart;
    public float ringsPresent;

    public float disPositionValue;

    GameObject ringPlacer;
    public GameObject ringPrefab;

    Vector3 previousPosition = Vector3.zero;

    bool mapLoaded;

    void Start() {
        ringPlacer = new GameObject();
        ringPlacer.transform.name = "Ring Placer";
        StartCoroutine(Wait());
    }

    void Update() {
        if (mapLoaded) {
            if (ringsPresent < 1) {
                CalculatePosition(0, 0, 0);
            }
        }
    }

    void CalculatePosition(float heightIncrease, float x, float z) {
        // Possibly add changing direction support in future
        if (x == 0 || z == 0) {
            x = Random.Range(previousPosition.x - disPositionValue, previousPosition.x + disPositionValue);
            z = previousPosition.z + 200;
        }

        //float y = Random.Range (previousPosition.y - disPositionValue, previousPosition.y + disPositionValue);;
        float y = 50 + heightIncrease;

        RaycastHit hit;
        Ray ray = new Ray(new Vector3(x, y, z), Vector3.up);

        if (Physics.CheckSphere(new Vector3(x, y, z), 20) || Physics.Raycast(ray, out hit, 25f)) {
            print("Collider");
            CalculatePosition(y + 10, x, z);
            return;
        } else {
            Vector3 placeRingAt = new Vector3(x, y, z);
            previousPosition = placeRingAt;
            PlaceRing(placeRingAt);
        }
    }

    void PlaceRing(Vector3 position) {
        GameObject ring = Instantiate(ringPrefab);
        ring.transform.position = position;
        ring.transform.parent = transform;

        ringsPresent++;
        ringsSinceStart++;
    }

    public void OnPassedThroughRing() {
        if (ringsPresent > 0) {
            ringsPresent--;
        }
    }

    IEnumerator Wait() {
        yield return new WaitForSeconds(1);
        mapLoaded = true;
    }

}