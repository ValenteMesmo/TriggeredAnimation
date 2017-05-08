using System;

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

    public class AnimationTransitionRuleWithInput : AnimationTransitionRule
    {
        public Func<bool> Condition { get; }

        public AnimationTransitionRuleWithInput(
            Animation Source, 
            Animation Target, 
            Func<bool> Condition) : base(Source, Target)
        {
            this.Condition = Condition;
        }
    }
}
