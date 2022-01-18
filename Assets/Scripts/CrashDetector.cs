using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float reloadDelay = 1.5f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;
    bool hasPlayed = false;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground")
        {
            FindObjectOfType<PlayerController>().DisableControls();
            crashEffect.Play();
            
            if (!hasPlayed)
            {
                hasPlayed = true;
                GetComponent<AudioSource>().PlayOneShot(crashSFX);
            }
            Invoke("ReloadScene", reloadDelay);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
