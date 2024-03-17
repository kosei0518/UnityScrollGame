using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GoalFlagScript : MonoBehaviour
{
    public GameObject player;
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
    private async void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.SendMessage("StageClear");
            audioSource.PlayOneShot(sound1);
            // Invoke(nameof(DelaySceneChange), 3.5f);
            StartCoroutine(DelayCoroutine(3.5f, () =>
            {
                DelaySceneChange();
            }));
        }
    }

    private IEnumerator DelayCoroutine(float seconds, UnityAction callback)
    {
        yield return new WaitForSeconds(seconds);
        callback?.Invoke();

    }

    void DelaySceneChange()
    {
        SceneManager.LoadScene("StageSelect");
    }


}
