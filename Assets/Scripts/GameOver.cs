using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private float timer = 0f;
    private const float delayBeforeRestart = 2f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > delayBeforeRestart)
        {
            Data.score = 0;
            SceneManager.LoadScene("Gameplay");
        }
    }
}
