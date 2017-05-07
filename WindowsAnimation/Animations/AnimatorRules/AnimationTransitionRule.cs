using System;

namespace TriggeredAnimation
{
    public class AnimationTransitionRule
    {
        public AnimationTransitionRule(Animation Source, Animation Target)
        {
            this.Source = Source;
            this.Target = Target;
        }

        public Animation Source { get; }
        public Animation Target { get; }
    }
}
