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
    
    [SerializeField]
    SilenceHandler silenceHandler = new SilenceHandler();

    // Misfires - aka wrong notes
    public void Misfire(MisfireHandler.MisfireType misfireType) => misfireHandler?.Misfire(misfireType);

    public void MisfireMarimba() => Misfire(MisfireHandler.MisfireType.Marimba);
    public void MisfirePercussion() => Misfire(MisfireHandler.MisfireType.Percussion);
    public void MisfireShaker() => Misfire(MisfireHandler.MisfireType.Shaker);
    public void MisfireTuba() => Misfire(MisfireHandler.MisfireType.Tuba);

    // Silence handling
    public void SilenceMarimba()
    {
        misfireHandler.isMarimbaSilenced = true;
        silenceHandler.Silence(MisfireHandler.MisfireType.Marimba);
    }
    
    public void SilencePercussion()
    {
        misfireHandler.isPercussionSilenced = true;
        silenceHandler.Silence(MisfireHandler.MisfireType.Percussion);
    }
    
    public void SilenceShaker()
    {
        misfireHandler.isShakerSilenced = true;
        silenceHandler.Silence(MisfireHandler.MisfireType.Shaker);
    }

    public void SilenceTuba()
    {
        misfireHandler.isTubaSilenced = true;
        silenceHandler.Silence(MisfireHandler.MisfireType.Tuba);
    }
    
    // Music control
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

    [NonSerialized]
    public bool isMarimbaSilenced, isPercussionSilenced, isShakerSilenced, isTubaSilenced;

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
                if(!isMarimbaSilenced)
                    Misfire(marimbaMisfireEvent);
                break;
            case MisfireType.Percussion:
                if(!isPercussionSilenced)
                    Misfire(percussionMisfireEvent);
                break;
            case MisfireType.Shaker:
                if(!isShakerSilenced)
                    Misfire(shakerMisfireEvent);
                break;
            case MisfireType.Tuba:
                if(!isTubaSilenced)
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

[Serializable]
public class SilenceHandler
{
    [SerializeField]
    private EventReference marimbaSilenceEvent;
    
    [SerializeField]
    private EventReference percussionSilenceEvent;
    
    [SerializeField]
    private EventReference shakerSilenceEvent;
    
    [SerializeField]
    private EventReference tubaSilenceEvent;

    public void Silence(MisfireHandler.MisfireType silenceType)
    {
        switch (silenceType)
        {
            case MisfireHandler.MisfireType.Marimba:
                Silence(marimbaSilenceEvent);
                break;
            case MisfireHandler.MisfireType.Percussion:
                Silence(percussionSilenceEvent);
                break;
            case MisfireHandler.MisfireType.Shaker:
                Silence(shakerSilenceEvent);
                break;
            case MisfireHandler.MisfireType.Tuba:
                Silence(tubaSilenceEvent);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(silenceType), silenceType, null);
        }
    }

    public void Silence(EventReference eventReference)
    {
        if(eventReference.IsNull)
            return;
        
        RuntimeManager.PlayOneShot(eventReference);
    }
}
