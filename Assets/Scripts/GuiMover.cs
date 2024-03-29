﻿using UnityEngine;

public class GuiMover : MonoBehaviour
{
    float speed = 5f;   // Speed of the text
    RectTransform myRectTransform;

    void Start()
    {
        myRectTransform = GetComponent<RectTransform>();
        GameObject canvas = GameObject.Find("Canvas");
        transform.SetParent(canvas.transform);
    }

    void Update()
    {
        myRectTransform.localPosition += Vector3.left * speed; // Move from right to left
    }

    private void LateUpdate()
    {
        Vector3[] v = new Vector3[4];
        myRectTransform.GetWorldCorners(v);
        if (v[3].x < 0) // 3 is lower right corner, and we check if that has left the screen
        {
            Destroy(gameObject);
        }
    }

}
