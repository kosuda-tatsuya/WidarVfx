using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizeParticleSystem : MonoBehaviour
{

    private ParticleSystem _ps = default;
    private ParticleSystemRenderer _psr = default;
    [SerializeField, Range(0, 2)] private float _speed = 1f;
    [SerializeField] private Color _color = Color.white;
    [SerializeField] private Vector3 _position = Vector3.zero, _rotation = Vector3.zero, _scale = Vector3.one;
    [SerializeField, Range(0, 10)] private int _sortingFudge = 0;

    private void Awake()
    {
        if (_ps == null) { _ps = GetComponent<ParticleSystem>(); }

        if (_psr == null) { _psr = GetComponent<ParticleSystemRenderer>(); }
    }

    private void Update()
    {
        var main = _ps.main;
        main.simulationSpeed = _speed;
        main.startColor = _color;
        transform.position = _position;
        transform.localEulerAngles = _rotation;
        transform.localScale = _scale;
        _psr.sortingFudge = _sortingFudge;
    }

}
