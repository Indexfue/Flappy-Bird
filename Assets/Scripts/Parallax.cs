using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Parallax : MonoBehaviour
{
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private GameObject _parallaxObject;

    private float _parallaxObjectLength;
    [SerializeField] private GameObject _newParallaxObject;

    private void Start()
    {
        _parallaxObjectLength = _parallaxObject.GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void Update()
    {
        ParallaxUpdatePosition();
        ParallaxDestroyOld();
    }

    private void ParallaxUpdatePosition()
    {
        if (_newParallaxObject != null) return;
        
        if (_cameraTransform.position.x > _parallaxObject.transform.position.x)
        {
            _newParallaxObject = Instantiate(_parallaxObject);
            Transform newParallaxObjectTransform = _newParallaxObject.transform;
            newParallaxObjectTransform.position = new Vector2(newParallaxObjectTransform.position.x + _parallaxObjectLength,
                _parallaxObject.transform.position.y);
        }
    }

    private void ParallaxDestroyOld()
    {
        if (_newParallaxObject == null) return;
        
        if (_cameraTransform.position.x > _newParallaxObject.transform.position.x)
        {
            Destroy(_parallaxObject);
            _parallaxObject = Instantiate(_newParallaxObject);
            Destroy(_newParallaxObject);
        }
    }
}
