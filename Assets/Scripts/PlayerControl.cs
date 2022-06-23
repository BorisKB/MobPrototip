using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControl : MonoBehaviour
{
    public Action onEnterRightBlock;
    public Action onGameOver;


    [SerializeField] private float force = 100f;
    [SerializeField] private float forcePerHit = 0.05f;
    [SerializeField] private float minForce = 0.75f;

    [SerializeField] private GameObject _hitFX;
    [SerializeField] private Transform _hitPoint;

    private Rigidbody _rigidbody;
    private bool noForce = false;
    private bool onPosition = true;
    private float _standartForce;
    // Start is called before the first frame update
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _standartForce = force;
    }

    private void Update()
    {
        if (onPosition == false) 
        {
            transform.position = Vector3.Slerp(transform.position, new Vector3(0, 5, -4.5f), 5f * Time.deltaTime);
        }
    }

    public void StartPlayer() 
    {
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.useGravity = false;
        onPosition = false;
        force = _standartForce;
        StartCoroutine(WaitingOnUnPause());
    }

    public void FreezePlayer() 
    {
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.useGravity = false;
        onPosition = false;
    }
    public void UnFreezePlayer()
    {
        _rigidbody.useGravity = true;
        onPosition = true;
    }
    private void OnCollisionEnter(Collision other)
    {
        if (noForce == false)
        {
            if (other.transform.tag == "RightBlock")
            {
                StartCoroutine(WaitingWhenHit());
                _rigidbody.velocity = Vector3.zero;
                _rigidbody.AddForce(Vector3.up * force, ForceMode.Impulse);
                GameObject hitFx = Instantiate(_hitFX, _hitPoint.transform.position, Quaternion.identity);
                Destroy(hitFx, 4f);
                if (force >= minForce)
                {
                    force -= forcePerHit;
                }
                onEnterRightBlock?.Invoke();
            }
            else
            {
                onGameOver?.Invoke();
            }
        }
        return;
    }

    private IEnumerator WaitingOnUnPause() 
    {
        yield return new WaitForSeconds(2f);
        _rigidbody.useGravity = true;
        onPosition = true;
    }
    private IEnumerator WaitingWhenHit()
    {
        noForce = true;

        yield return new WaitForSeconds(0.5f);

        noForce = false;
    }
}
