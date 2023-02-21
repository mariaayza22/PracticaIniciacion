using System.Collections;
using System.Collections.Generic;
using Test;
using UnityEngine;

[DefaultExecutionOrder(-1)]
public class MAZ_AudioManager : MonoBehaviour
{
    private static MAZ_AudioManager m_instance;

    [SerializeField] private AudioSource m_correct;
    [SerializeField] private AudioSource m_incorrect;
    [SerializeField] private AudioSource m_background;

    public static MAZ_AudioManager Instance
    {
        get
        {
            return m_instance;
        }
    }

    private void Awake()
    {
        if (m_instance == null)
        {
            m_instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public void correctSound()
    {
        m_correct.Play();
    }

    public void incorrectSound()
    {
        m_incorrect.Play();
    }

    
}
