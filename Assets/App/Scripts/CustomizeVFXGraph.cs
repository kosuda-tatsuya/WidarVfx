using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using klib;

public class CustomizeVFXGraph : MonoBehaviour
{

    [SerializeField] private string _floatPropertyName = "";
    [SerializeField] private float _floatValue = 0;
    [SerializeField] private string _colourPropertyName = "";
    [SerializeField, ColorUsage(hdr: true, showAlpha: true)] private Color _colourValue = Color.white;

    private int _floatPropertyId = 0;
    private int _colourPropertyId = 0;
    private VisualEffect _vfx;


    private void Awake()
    {
        _vfx = GetComponent<VisualEffect>();

        if (_floatPropertyName.IsNotNullOrEmpty())
        {
            _floatPropertyId = Shader.PropertyToID(_floatPropertyName);
            _floatValue = _vfx.GetFloat(_floatPropertyId);
        }

        if (_colourPropertyName.IsNotNullOrEmpty())
        {
            _colourPropertyId = Shader.PropertyToID(_colourPropertyName);
            _colourValue = _vfx.GetVector4(_colourPropertyId);
        }
    }

    private void Update()
    {
        _vfx.SetFloat(_floatPropertyId, _floatValue);
        _vfx.SetVector4(_colourPropertyId, _colourValue);
    }

}
