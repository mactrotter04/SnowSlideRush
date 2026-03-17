using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float LoadDelay = 2f;
    [SerializeField] ParticleSystem CrashEffect;
    [SerializeField] AudioClip crashSound;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Ground"))
        {
            Debug.Log("You Loose!");
            FindAnyObjectByType<PlayerController>().disableControl();
            CrashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSound);
            Invoke(nameof(ReloadLevel), LoadDelay);
        }
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene("Level 1");
    }
}
