using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DifficultManager : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdown;
    [SerializeField] private Material playerMaterial;
    [SerializeField] private Material rightBlockMaterial;
    [SerializeField] private MeshRenderer player;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Setdifficult() 
    {
        if (dropdown.value == 0) 
        {
            player.material = playerMaterial ;
        }
        if (dropdown.value == 1)
        {
            player.material = rightBlockMaterial;
        }

    }
}
