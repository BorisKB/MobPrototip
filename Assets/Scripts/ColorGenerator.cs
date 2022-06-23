using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorGenerator : MonoBehaviour
{
    [SerializeField]private Gradient colorsss;

    [SerializeField] private Material[] materials;

    [SerializeField] private Color[] colors;

    [SerializeField] private float CycleTime;

    private Camera _camera;
    private void Awake()
    {
        _camera = Camera.main;
    }
    public void GenerateNewColors() 
    {
        for (int i = 0; i < colors.Length; i++)
        {
            colors[i] = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            materials[i].color = colors[i];
        }
    }
    private void Update()
    {
        _camera.backgroundColor = colorsss.Evaluate(Mathf.PingPong(Time.time, CycleTime) / CycleTime);
    }
}
