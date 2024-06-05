using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalFlagScript : MonoBehaviour
{
    public PlayerController playerController; // インスペクタでアサインされることを確認
    public AudioClip sound1;
    private AudioSource audioSource;
    private string currentSceneName;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        currentSceneName = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (playerController != null)
            {
                playerController.StageClear();
                DistinguishScene();
                audioSource.PlayOneShot(sound1);
                StartCoroutine(DelayLoadScene(3.5f));
            }
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

    void DistinguishScene()
    {
        if (currentSceneName == "MainScene")
        {
            DokanManager.dokan2Bool = true;
        }
        else if (currentSceneName == "Stage2")
        {
            DokanManager.dokan3Bool = true;
        }
        else if (currentSceneName == "Stage3")
        {
            DokanManager.dokan4Bool = true;
        }
    }
}