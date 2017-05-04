namespace TriggeredAnimation
{
    public class FlaggedAnimationTransitionRule : AnimationTransitionRule
    {
        public string FlagName { get; }

        public FlaggedAnimationTransitionRule(Animation Source, Animation Target, string FlagName) : base(Source, Target)
        {
            this.FlagName = FlagName;
        }
    }
}
