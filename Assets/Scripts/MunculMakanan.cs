using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MunculMakanan : MonoBehaviour
{
    public float jeda = 1f;
    float timer;
    public GameObject[] obyekMakanan;

    void Start()
    {

    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > jeda)
        {
            int random = Random.Range(0, obyekMakanan.Length);
            Instantiate(obyekMakanan[random], transform.position,
            transform.rotation);
            timer = 0;
        }
    }
}