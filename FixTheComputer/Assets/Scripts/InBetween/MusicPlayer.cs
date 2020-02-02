using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public static MusicPlayer instance;
    [SerializeField]
    AudioClip billy, havana, shape, lilnas, LMFAO, mackle, post, taylor;
    public bool billylock, havanalock, shapelock, lilnaslock, LMFAOlock, macklelock, postlock, taylorlock = false;
    public GameObject billygo, havanago, shapego, lilnasgo, LMFAOgo, macklego, postgo, taylorgo;
    List<int> numbers = new List<int>();

    AudioSource au;
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    void Start()
    {
        instance = this;
        au = GetComponent<AudioSource>();
        for (int i = 0; i < 7; i++)

            numbers.Add(i+1);


        billygo.SetActive(billylock);
        havanago.SetActive(havanalock);
        shapego.SetActive(shapelock);
        lilnasgo.SetActive(lilnaslock);
        LMFAOgo.SetActive(LMFAOlock);
        macklego.SetActive(macklelock);
        postgo.SetActive(postlock);
        taylorgo.SetActive(taylorlock);

    }

    // Update is called once per frame
    void Update()
    {    
    }

    public void lockSongs()
    {
        billylock = true;
        havanalock = true;
        shapelock = true;
        lilnaslock = true;
        LMFAOlock = true;
        macklelock = true;
        postlock = true;
        taylorlock = true;
    }

    public void unlockSong()
    {

        int pickASong = Random.Range(1, numbers.Count);
        
        if (pickASong == 1) { billylock = false; numbers.Remove(1); }
        if (pickASong == 2) { havanalock = false; numbers.Remove(2); }
        if (pickASong == 3) { shapelock = false; numbers.Remove(3); }
        if (pickASong == 4) { lilnaslock = false; numbers.Remove(4); }
        if (pickASong == 5) { LMFAOlock = false; numbers.Remove(5); }
        if (pickASong == 6) { macklelock = false; numbers.Remove(6); }
        if (pickASong == 7) { postlock = false; numbers.Remove(7); }
        if (pickASong == 8) { taylorlock = false; numbers.Remove(8); }
    }

    public void PlayBilly() {
        if (!billylock)
        {
            au.clip = billy;
            au.Play();
        }
    }
    public void PlayHavana()
    {
        if (!havanalock)
        {
            au.clip = havana;
            au.Play();
        }
    }
    public void PlayShape()
    {
        if (!shapelock)
        {
            au.clip = shape;
            au.Play();
        }
    }
    public void PlayLilNas()
    {
        if (!lilnaslock)
        {
            au.clip = lilnas;
            au.Play();
        }
    }
    public void PlayLMFAO()
    {
        if (!LMFAOlock)
        {
            au.clip = LMFAO;
            au.Play();
        }
    }
    public void PlayMackle()
    {
        if (!macklelock)
        {
            au.clip = mackle;
            au.Play();
        }
    }
    
    public void PlayPost()
    {
        if (!postlock)
        {
            au.clip = post;
            au.Play();
        }
    }
    public void PlayTaylor()
    {
        if (!taylorlock)
        {
            au.clip = taylor;
            au.Play();
        }
    }


}
