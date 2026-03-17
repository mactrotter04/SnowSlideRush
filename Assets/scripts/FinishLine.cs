using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] ParticleSystem FinishEffect;
    [SerializeField] float LoadDelay = 2f;
    

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("You Win!");
            FinishEffect.Play();
            //GetComponent<AudioSource>().Play();
            audioSource.Play();
            Invoke(nameof(ReloadLevel), LoadDelay);
        }
    }


    void ReloadLevel()
    {
        SceneManager.LoadScene("Level 1");
    }
}
