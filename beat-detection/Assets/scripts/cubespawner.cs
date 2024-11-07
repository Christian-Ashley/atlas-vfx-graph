using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubespawner : MonoBehaviour
{
    public GameObject _sampleCubePrefab;
    GameObject[] _sampleCube = new GameObject[512];
    public float _maxScale;
    private audio audio;

    void Start()
    {
        audio = FindObjectOfType<audio>(); // Find the audio in the scene
        for (int i = 0; i < 512; i++)
        {
            GameObject _instanceSampleCube = Instantiate(_sampleCubePrefab);
            _instanceSampleCube.transform.position = this.transform.position;
            _instanceSampleCube.transform.parent = this.transform;
            _instanceSampleCube.name = "SampleCube" + i;
            this.transform.eulerAngles = new Vector3(0, -0.703125f * i, 0);
            _instanceSampleCube.transform.position = Vector3.forward * 100;
            _sampleCube[i] = _instanceSampleCube;
        }
    }

    void Update()
    {
        for (int i = 0; i < 512; i++)
        {
            if (_sampleCube[i] != null) // Check if the cube is not null
            {
                _sampleCube[i].transform.localScale = new Vector3(.5f, (audio._clone[i] * _maxScale) + 2, .5f);
            }
        }
    }
}
