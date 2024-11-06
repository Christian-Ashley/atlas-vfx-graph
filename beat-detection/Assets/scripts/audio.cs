using System.Collections;
using UnityEngine;

[RequireComponent (GetComponent<AudioSource>())]
public class audio : MonoBehaviour
{
    AudioSource _audiosource;
    public float[] _samples = new float[512];
    // Start is called before the first frame update
    void Start()
    {
        _audiosource = GetComponent<AudioSource> ();
    }

    // Update is called once per frame
    void Update()
    {
        GetSpectrumAudioSource ();
    }
    void GetSpectrumAudioSource()
    {
        _audiosource.GetSpectrumData(_samples, 0, FFTWindow.Blackman);
    }
}
