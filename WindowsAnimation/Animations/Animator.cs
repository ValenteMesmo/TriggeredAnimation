using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace TriggeredAnimation
{
    public class Animator
    {
        private AnimationTransitionRule[] Rules;
        private Animation CurrentAnimation;
        private List<string> Triggers;
        private List<string> Flags;
        public int X { get; set; }
        public int Y { get; set; }

        public Animator(int X, int Y, params AnimationTransitionRule[] rules) : this(rules)
        {
            this.X = X;
            this.Y = Y;
        }

        public Animator(params AnimationTransitionRule[] rules)
        {
            CurrentAnimation = rules[0].Source;
            Rules = rules;
            Triggers = new List<string>();
            Flags = new List<string>();
        }

        public void ActivateTrigger(string triggerName)
        {

            Triggers.Add(triggerName);
        }

        public void Flag(string name, bool value)
        {
            if (value)
            {
                if (Flags.Contains(name))
                    return;
                Flags.Add(name);
            }
            else
            {
                if (Flags.Contains(name))
                    Flags.Remove(name);
            }
        }

        public void Draw(SpriteBatch batch, int x, int y)
        {
            foreach (var rule in Rules)
            {
                if (rule.Source == CurrentAnimation)
                {
                    if (rule is TriggeredAnimationTransitionRule)
                    {
                        var triggerName = (rule as TriggeredAnimationTransitionRule).TriggerName;

                        if (Triggers.Contains(triggerName))
                        {
                            CurrentAnimation.Reset();
                            CurrentAnimation = rule.Target;
                            CurrentAnimation.Reset();
                            break;
                        }
                    }
                    else if (rule is FlaggedAnimationTransitionRule)
                    {
                        var flagName = (rule as FlaggedAnimationTransitionRule).FlagName;

                        if (Flags.Contains(flagName))
                        {
                            CurrentAnimation.Reset();
                            CurrentAnimation = rule.Target;
                            CurrentAnimation.Reset();
                            break;
                        }
                    }
                    else if (rule is UnFlaggedAnimationTransitionRule)
                    {
                        var flagName = (rule as UnFlaggedAnimationTransitionRule).FlagName;

                        if (Flags.Contains(flagName) == false)
                        {
                            CurrentAnimation.Reset();
                            CurrentAnimation = rule.Target;
                            CurrentAnimation.Reset();
                            break;
                        }
                    }
                    else
                    {
                        if (CurrentAnimation.HasEnded)
                        {
                            CurrentAnimation.Reset();
                            CurrentAnimation = rule.Target;
                            CurrentAnimation.Reset();
                            break;
                        }
                    }
                }
            }
            Triggers.Clear();

            CurrentAnimation.Draw(batch, X + x, Y + y);
        }
    }
}
