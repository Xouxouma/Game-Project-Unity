﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public float _sensitivity = 5.0f;
    public float _smoothing = 2.0f;
    private Vector2 _mouseLook;
    private Vector2 _smoothV;
    public GameObject _player;

    private void Awake()
    {
        //_player = transform.parent.gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0)
        {
            Vector2 mouseDirection = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

            mouseDirection.x *= _sensitivity * _smoothing;
            mouseDirection.y *= _sensitivity * _smoothing;
            _smoothV.x = Mathf.Lerp(_smoothV.x, mouseDirection.x, 1f / _smoothing);
            _smoothV.y = Mathf.Lerp(_smoothV.y, mouseDirection.y, 1f / _smoothing);
            _mouseLook += _smoothV;
            _mouseLook.y = Mathf.Clamp(_mouseLook.y, -90, 90);
            transform.localRotation = Quaternion.AngleAxis(-_mouseLook.y, Vector3.right);
            _player.transform.rotation = Quaternion.AngleAxis(_mouseLook.x, _player.transform.up);
            //transform.rotation = Quaternion.AngleAxis(_mouseLook.x, _player.transform.up);
        }
    }
}
