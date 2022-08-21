using System;
using FMODUnity;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private EventReference musicEvent;

    [SerializeField]
    private EventReference endGameEvent;

    [SerializeField]
    private MisfireHandler misfireHandler = new MisfireHandler();

    public void Misfire(MisfireHandler.MisfireType misfireType) => misfireHandler?.Misfire(misfireType);

    public void MisfireMarimba() => Misfire(MisfireHandler.MisfireType.Marimba);
    public void MisfirePercussion() => Misfire(MisfireHandler.MisfireType.Percussion);
    public void MisfireShaker() => Misfire(MisfireHandler.MisfireType.Shaker);
    public void MisfireTuba() => Misfire(MisfireHandler.MisfireType.Tuba);

    public void StartMusic() => RuntimeManager.PlayOneShot(musicEvent);

    public void StopMusic() => RuntimeManager.PlayOneShot(endGameEvent);
}

[Serializable]
public class MisfireHandler
{
    public enum MisfireType
    {
        Marimba, Percussion, Shaker, Tuba
    }

    [SerializeField]
    private EventReference marimbaMisfireEvent;
    
    [SerializeField]
    private EventReference percussionMisfireEvent;
    
    [SerializeField]
    private EventReference shakerMisfireEvent;
    
    [SerializeField]
    private EventReference tubaMisfireEvent;

    [SerializeField]
    private EventReference genericMisfireEvent;

    public void Misfire(MisfireType misfireType)
    {
        switch (misfireType)
        {
            case MisfireType.Marimba:
                Misfire(marimbaMisfireEvent);
                break;
            case MisfireType.Percussion:
                Misfire(percussionMisfireEvent);
                break;
            case MisfireType.Shaker:
                Misfire(shakerMisfireEvent);
                break;
            case MisfireType.Tuba:
                Misfire(tubaMisfireEvent);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(misfireType), misfireType, null);
        }
    }

    public void Misfire(EventReference eventReference)
    {
        RuntimeManager.PlayOneShot(eventReference.IsNull ? genericMisfireEvent : eventReference);
    }
}
