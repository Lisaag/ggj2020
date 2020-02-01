using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    AudioClip billy, havana, shape, lilnas, LMFAO, mackle, post, taylor;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayBilly() { 
        audio.clip = billy;
        audio.Play();
        Debug.Log("hit");
    }
    public void PlayHavana()
    {
        audio.clip = havana;
        audio.Play();
        Debug.Log("hit");
    }
    public void PlayShape()
    {
        audio.clip = shape;
        audio.Play();
        Debug.Log("hit");
    }
    public void PlayLilNas()
    {
        audio.clip = lilnas;
        audio.Play();
        Debug.Log("hit");
    }
    public void PlayLMFAO()
    {
        audio.clip = LMFAO;
        audio.Play();
        Debug.Log("hit");
    }
    public void PlayMackle()
    {
        audio.clip = mackle;
        audio.Play();
        Debug.Log("hit");
    }
    public void PlayPost()
    {
        audio.clip = post;
        audio.Play();
        Debug.Log("hit");
    }
    public void PlayTaylor()
    {
        audio.clip = taylor;
        audio.Play();
        Debug.Log("hit");
    }


}
