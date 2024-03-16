using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] private ParticleSystem crashEffect;
    [SerializeField] float loadDelay = 0.5f;
    bool hasCrashed = false;
    [SerializeField] AudioClip crashSFX;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Ground") && !hasCrashed)
        {
            hasCrashed = true;
            FindObjectOfType<PlayerController>().DisableControls();
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadScene", loadDelay);
        }
    }
    
    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
