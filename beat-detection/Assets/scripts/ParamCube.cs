using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParamCube : MonoBehaviour
{
    public int _band;               // Band index to target specific frequency
    public float _startScale, _scaleMultiplier; // Controls the scale of the object
    public bool _useBuffer;         // Whether to use the buffer or not
    Material _material;             // Material for the cube to control its color and emission

    // Start is called before the first frame update
    void Start()
    {
        // Get the material of the cube (assuming it's the first material)
        _material = GetComponent<MeshRenderer>().materials[0];
    }

    // Update is called once per frame
    void Update()
    {
        // Check if we should use the audio buffer for smoothing
        if (_useBuffer)
        {
            // Use the buffered audio band data from AudioHandler
            transform.localScale = new Vector3(
                transform.localScale.x,
                (AudioHandler._audioBandBuffer[_band] * _scaleMultiplier) + _startScale,
                transform.localScale.z
            );

            // Set the emission color based on the buffered audio band data
            Color _color = new Color(
                AudioHandler._audioBandBuffer[_band],
                AudioHandler._audioBandBuffer[_band],
                AudioHandler._audioBandBuffer[_band]
            );
            _material.SetColor("_EmissionColor", _color);
        }
        else
        {
            // Use the raw audio band data from AudioHandler
            transform.localScale = new Vector3(
                transform.localScale.x,
                (AudioHandler._audioBand[_band] * _scaleMultiplier) + _startScale,
                transform.localScale.z
            );

            // Set the emission color based on the raw audio band data
            Color _color = new Color(
                AudioHandler._audioBand[_band],
                AudioHandler._audioBand[_band],
                AudioHandler._audioBand[_band]
            );
            _material.SetColor("_EmissionColor", _color);
        }
    }
}
