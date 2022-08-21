using UnityEngine;
using UnityEngine.UI;

namespace Music
{
    public class AudioManagerUI : MonoBehaviour
    {
        [SerializeField]
        private AudioManager manager;

        [SerializeField]
        private Button playMusicButton;
        
        [SerializeField]
        private Button endMusicButton;
        
        [SerializeField]
        private Button misfireMarimbaButton;
        
        [SerializeField]
        private Button misfirePercussionButton;
        
        [SerializeField]
        private Button misfireShakerButton;
        
        [SerializeField]
        private Button misfireTubaButton;

        private void Start()
        {
            playMusicButton.onClick.AddListener(manager.StartMusic);
            endMusicButton.onClick.AddListener(manager.StopMusic);

            misfireMarimbaButton.onClick.AddListener(manager.MisfireMarimba);
            misfirePercussionButton.onClick.AddListener(manager.MisfirePercussion);
            misfireShakerButton.onClick.AddListener(manager.MisfireShaker);
            misfireTubaButton.onClick.AddListener(manager.MisfireTuba);
        }
    }
}