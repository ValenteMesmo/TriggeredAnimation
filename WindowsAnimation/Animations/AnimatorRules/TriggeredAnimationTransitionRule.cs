namespace TriggeredAnimation
{
    public class TriggeredAnimationTransitionRule : AnimationTransitionRule
    {
        public string TriggerName { get; }

        public TriggeredAnimationTransitionRule(
            Animation Source,
            Animation Target,
            string TriggerName) : base(Source, Target)
        {
            this.TriggerName = TriggerName;
        }
    }
}
