using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    AudioClip billy, havana, shape, lilnas, LMFAO, mackle, post, taylor;
    AudioSource au;
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    void Start()
    {
       au = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayBilly() {
        au.clip = billy;
        au.Play();
    }
    public void PlayHavana()
    {
        au.clip = havana;
        au.Play();
    }
    public void PlayShape()
    {
        au.clip = shape;
        au.Play();
    }
    public void PlayLilNas()
    {
        au.clip = lilnas;
        au.Play();
    }
    public void PlayLMFAO()
    {
        au.clip = LMFAO;
        au.Play();
    }
    public void PlayMackle()
    {
        au.clip = mackle;
        au.Play();
    }
    public void PlayPost()
    {
        au.clip = post;
        au.Play();
    }
    public void PlayTaylor()
    {
        au.clip = taylor;
        au.Play();
    }


}
