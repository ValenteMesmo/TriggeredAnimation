namespace TriggeredAnimation
{
    public class UnFlaggedAnimationTransitionRule : AnimationTransitionRule
    {
        public string FlagName { get; }

        public UnFlaggedAnimationTransitionRule(Animation Source, Animation Target, string FlagName) : base(Source, Target)
        {
            this.FlagName = FlagName;
        }
    }
}
