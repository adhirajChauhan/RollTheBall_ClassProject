using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;
    public Camera mainCamera;

    [SerializeField] float cameraShakeDuration;
    [SerializeField] float cameraShakeStrength;
    [SerializeField] float cameraShakeRandomness;
    [SerializeField] int cameraShakeVibrato;

    private void Awake()
    {
        instance = this;
    }

    public void CameraShake()
    {
        mainCamera.DOShakePosition(cameraShakeDuration, cameraShakeStrength, cameraShakeVibrato, cameraShakeRandomness);
        Debug.Log("BT_A1");
    }
}
