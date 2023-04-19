using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    private float red = 1f;
    private float green = 0f;
    private float blue = 0f;
    private float alpha = 0.5f;

    private float colorChangeRate = 0.3f;
    private Material material;
    private int rotationDirection = 0;
    private float rotationRate = 10.0f;
    void Start()
    {
        transform.position = new Vector3(3, 4, 1);
        transform.localScale = Vector3.one * 1.3f;

        material = Renderer.material;
        material.color = new Color(red, green, blue, alpha);

        alpha = Random.Range(0.3f, 0.9f);
        colorChangeRate = Random.Range(0.2f, 0.5f);
        rotationDirection = Random.Range(0, 3);
        rotationRate = Random.Range(10.0f,15.0f);
    }
    
    void Update()
    {
        if (red == 1f && green < 1f && blue == 0f)
        {
            green += colorChangeRate * Time.deltaTime;
        }
        else if (red > 0f && green == 1f && blue == 0f)
        {
            red -= colorChangeRate * Time.deltaTime;
        }
        else if (red == 0f && green == 1f && blue < 1f)
        {
            blue += colorChangeRate * Time.deltaTime;
        }
        else if (red == 0f && green > 0f && blue == 1f)
        {
            green -= colorChangeRate * Time.deltaTime;
        }
        else if (red < 1f && green == 0f && blue == 1f)
        {
            red += colorChangeRate * Time.deltaTime;
        }
        else if (red == 1f && green == 0f && blue > 0f)
        {
            blue -= colorChangeRate * Time.deltaTime;
        }

        if (red > 1f) { red = 1f; }
        if (green > 1f) { green = 1f; }
        if (blue > 1f) { blue = 1f; }

        if (red < 0f) { red = 0f; }
        if (green < 0f) { green = 0f; }
        if (blue < 0f) 
        {
            blue = 0f;

            alpha = Random.Range(0.3f, 0.9f);
            colorChangeRate = Random.Range(0.2f, 0.5f);
            rotationDirection = Random.Range(0, 3);
            rotationRate = Random.Range(10.0f, 15.0f);
        }

        material.color = new Color(red, green, blue, alpha);

        switch (rotationDirection)
        {
            case 0:
                transform.Rotate(rotationRate * Time.deltaTime, 0.0f, 0.0f);
                break;
            case 1:
                transform.Rotate(0.0f, rotationRate * Time.deltaTime, 0.0f);
                break;
            case 2:
                transform.Rotate(0.0f, 0.0f, rotationRate * Time.deltaTime);
                break;
        }
        
    }
}
