using UnityEngine;
using System.Collections;

public class HideOnPlay : MonoBehaviour {

    void Awake() {
        Start();
    }

    void Start () {
		gameObject.SetActive (false);
	}
}
