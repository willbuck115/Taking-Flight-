using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{

    int score = 0;
    public TextMeshProUGUI text;

    public void IncrementScore(){
        score++;
        text.text = "" + score;
    }

}
