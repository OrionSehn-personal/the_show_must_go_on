using UnityEngine;

public class MusicLanesTweener : MonoBehaviour
{
    [SerializeField]
    private LeanTweenType tweenType = LeanTweenType.easeSpring;
    
    [SerializeField]
    private float tweenTime = .6f;

    [SerializeField]
    private float tweenScale = 4f;

    [SerializeField]
    private GameObject lane1GO, lane2GO, lane3GO, lane4GO;
    
    private TweenContainer lane1, lane2, lane3, lane4;

    private void Awake()
    {

        lane1 = TweenContainer.CreateContainer(lane1GO);
        lane2 = TweenContainer.CreateContainer(lane2GO);
        lane3 = TweenContainer.CreateContainer(lane3GO);
        lane4 = TweenContainer.CreateContainer(lane4GO);
    }

    [ContextMenu("Animate lane 1")]
    public void AnimateLane1() => AnimateLane(lane1);
    [ContextMenu("Animate lane 2")]
    public void AnimateLane2() => AnimateLane(lane2);
    [ContextMenu("Animate lane 3")]
    public void AnimateLane3() => AnimateLane(lane3);
    [ContextMenu("Animate lane 4")]
    public void AnimateLane4() => AnimateLane(lane4);

    private void AnimateLane(TweenContainer tweenContainer)
    {
        tweenContainer.Reset();
        tweenContainer.tween = LeanTween.scale(tweenContainer.lane, tweenContainer.originalScale * tweenScale, tweenTime).setEase(tweenType).setLoopOnce();
    }
    
    private struct TweenContainer
    {
        public GameObject lane;
        public LTDescr tween;
        public Vector3 originalScale;

        public void Reset()
        {
            tween?.reset();
            lane.transform.localScale = originalScale;
        }

        public static TweenContainer CreateContainer(GameObject gameObject)
        {
            return new TweenContainer
            {
                lane = gameObject, tween = null, originalScale = gameObject.transform.localScale
            };
        }
    }
}
