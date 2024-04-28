using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalFlagScript : MonoBehaviour
{
    public PlayerController playerController;
    public AudioClip sound1;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerController.StageClear();
            audioSource.PlayOneShot(sound1);
            StartCoroutine(DelayLoadScene(3.5f));

        }
    }
    void SceneChange()
    {
        SceneManager.LoadScene("StageSelect");
    }
    IEnumerator DelayLoadScene(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("StageSelect");
    }

}
