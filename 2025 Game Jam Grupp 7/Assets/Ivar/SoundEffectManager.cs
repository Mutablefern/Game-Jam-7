using System;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class SoundEffectManager : MonoBehaviour
{
    [SerializeField] GameObject effectPrefab;


    public string currentVisualEffect = "null";

    [SerializeField] private VisualEffectInfo[] effectInfoArray;
    private Dictionary<string, VisualEffectInfo> effectInfoDict;

    private void Awake()
    {
        effectInfoDict = new Dictionary<string, VisualEffectInfo>();
        foreach (VisualEffectInfo effectInfo in effectInfoArray)
        {
            effectInfoDict.Add(effectInfo.name, effectInfo);
        }
    }

    private void FixedUpdate()
    {
        if (currentVisualEffect != null)
        {
            return;
        }
    }

    public void SetEffectData(string visualType)
    {
        if (!effectInfoDict.ContainsKey(visualType)) return;

        GameObject newEffect = Instantiate(effectPrefab, transform);
        Destroy(newEffect, 10f);
        VisualEffectInfo info = effectInfoDict[visualType];

        AudioSource audioSource = newEffect.GetComponent<AudioSource>();
        if (audioSource != null)
        {
            audioSource.clip = info.soundEffect;
            audioSource.volume = info.volume;
            audioSource.Play();
        }
    }

    [Serializable]
    public class VisualEffectInfo
    {
        public string name;
        public AudioClip soundEffect;
        public float volume = 1f;
    }
}
