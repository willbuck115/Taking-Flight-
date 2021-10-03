using UnityEngine;

public class CourseRing : MonoBehaviour
{
    ProceduralCourse manager;
    Score scoreManager;

    void Awake() {
        manager = FindObjectOfType<ProceduralCourse>();
        scoreManager = FindObjectOfType<Score>();
    }

    void OnTriggerEnter(Collider other) {
        manager.OnPassedThroughRing();
        scoreManager.IncrementScore();
        Destroy(gameObject);
    }
}
