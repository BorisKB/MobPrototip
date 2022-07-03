using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderManager : MonoBehaviour
{
    [SerializeField] private MeshRenderer[] _bloks;
    [SerializeField] private Material _block;
    [SerializeField] private Material _rightBlock;
        

    private int _random1;
    private int _random2;
    public void SetRightBlocks()
    {
        _random1 = Random.Range(0, _bloks.Length);
        _random2 = Random.Range(0, _bloks.Length);

        _bloks[_random1].tag = "RightBlock";
        _bloks[_random1].material = _rightBlock;

        _bloks[_random2].tag = "RightBlock";
        _bloks[_random2].material = _rightBlock;
    }

    public void SetAllBlockToDefault()
    {
        _bloks[_random1].tag = "Block";
        _bloks[_random1].material = _block;

        _bloks[_random2].tag = "Block";
        _bloks[_random2].material = _block;
    }
}
