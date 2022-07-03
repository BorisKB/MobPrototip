using System.Collections.Generic;
using UnityEngine;

public class ColorGenerator : MonoBehaviour
{
    [SerializeField]private Gradient colorsss;

    [SerializeField] private Material cylinderMaterial;
    [SerializeField] private Material playerMaterial;
    [SerializeField] private Material rightBlockMaterial;
    [SerializeField] private Material blockMaterial;

    [SerializeField] private Color[] colorForCylinder;
    [SerializeField] private Color[] colorForPlayer;
    [SerializeField] private Color[] colorForRightBlocks;
    [SerializeField] private Color[] colorForBlocks;

    [SerializeField] private Color[] _colors;

    [SerializeField] private float CycleTime;

    private int randomNumber;

    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }
    public void GenerateNewColors() 
    {
        randomNumber = Random.Range(0, colorForCylinder.Length);

        _colors[0] = colorForCylinder[randomNumber];
        _colors[1] = colorForPlayer[randomNumber];
        _colors[2] = colorForRightBlocks[randomNumber];
        _colors[3] = colorForBlocks[randomNumber];

        _colors = Shuffle(_colors);

        cylinderMaterial.color = _colors[0];
        playerMaterial.color = _colors[1];
        rightBlockMaterial.color = _colors[2];
        blockMaterial.color = _colors[3];
    }
    private void Update()
    {
        _camera.backgroundColor = colorsss.Evaluate(Mathf.PingPong(Time.time, CycleTime) / CycleTime);
    }

    private Color[] Shuffle(Color[] colors) 
    {
        Color color;
        for (int i = colors.Length - 1; i >= 1; i--)
        {
            int j = Random.Range(0, i);

            color = colors[j];
            colors[j] = colors[i];
            colors[i] = color;
        }

        return colors;
    }
}
