using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformRotate : MonoBehaviour
{

    
    public Transform _currentCylinder;

    private Quaternion target;
    // Start is called before the first frame update
    void Start()
    {
        target = _currentCylinder.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (_currentCylinder.rotation != target)
        {
            _currentCylinder.rotation = Quaternion.Slerp(_currentCylinder.rotation, target, 5.0f * Time.deltaTime);
        }
    }

    public void LeftButton()
    {
        target *= Quaternion.Euler(0, -60, 0);
    }
    public void RightButton()
    {
        target *= Quaternion.Euler(0, 60, 0);
    }
}
