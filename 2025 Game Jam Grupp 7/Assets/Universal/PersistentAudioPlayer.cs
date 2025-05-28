using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PersistentAudioPlayer : MonoBehaviour
{
    public enum PersistentMusicPlayerType
    {
        MainMenu,
        Gameplay
    }

    [SerializeField] AudioSource myAudioSource;
    [SerializeField] PersistentMusicPlayerType playerType;

    private void Awake()
    {
        List<PersistentAudioPlayer> allMusicPlayers = FindObjectsByType<PersistentAudioPlayer>(FindObjectsSortMode.None).ToList();

        if(allMusicPlayers.Count == 1)
        {
            DontDestroyOnLoad(gameObject);
            return;
        }

        allMusicPlayers.Remove(this);
        PersistentAudioPlayer otherPlayer = allMusicPlayers[0];

        if (otherPlayer.GetPlayerType() == playerType)
        {
            Destroy(gameObject);
        }
        else
        {
            DestroyImmediate(otherPlayer.gameObject);
            DontDestroyOnLoad(gameObject);
        }
    }

    public PersistentMusicPlayerType GetPlayerType()
    {
        return playerType;
    }
}
