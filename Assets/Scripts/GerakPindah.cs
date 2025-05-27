using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerakPindah : MonoBehaviour
{
    float speed = 3f;
    public Sprite[] sprites;

    private Vector3 screenPoint;
    private Vector3 offset;
    private float firstY;

    void Start()
    {
        // Pilih sprite random saat mulai
        if (sprites != null && sprites.Length > 0)
        {
            int index = Random.Range(0, sprites.Length);
            GetComponent<SpriteRenderer>().sprite = sprites[index];
        }
        else
        {
            Debug.LogWarning("Sprites belum diisi di Inspector!");
        }
    }

    void Update()
    {
        // Gerak ke kiri terus
        float move = (speed * Time.deltaTime * -1f) + transform.position.x;
        transform.position = new Vector3(move, transform.position.y, transform.position.z);
    }

    void OnMouseDown()
    {
        firstY = transform.position.y;
        screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        offset = transform.position - Camera.main.ScreenToWorldPoint(
            new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
    }

    void OnMouseUp()
    {
        // Kunci kembali ke posisi Y semula setelah mouse lepas
        transform.position = new Vector3(transform.position.x, firstY, transform.position.z);
    }
}