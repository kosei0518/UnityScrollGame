using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraPositionScript : MonoBehaviour
{
    [SerializeField]
    private float cameraChaseDistance;
    GameObject playerObject;
    Transform playerTransform;

    private Tween _shakeTween;

    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        playerTransform = playerObject.transform;
    }

    void Update()
    {
        if (playerTransform.position.x > cameraChaseDistance)
        {
            transform.position = new Vector3(playerTransform.position.x, 7, -14);
        }

        // Time.timeScaleが変更される直前にCameraShakingメソッドを呼び出す
        if (Time.timeScale > 0 && Mathf.Approximately(Time.timeScale, 0))
        {
            CameraShaking();
        }
    }

    void CameraShaking()
    {
        _shakeTween = transform.DOShakePosition(1.0f, new Vector3(0.1f, 0.1f, 0), 10, 90, false);
    }
}
