using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace TriggeredAnimation
{
    public class FlaggedAnimationTransitionRule : AnimationTransitionRule
    {
        public string FlagName { get; }

        public FlaggedAnimationTransitionRule(SimpleAnimation Source, SimpleAnimation Target, string FlagName) : base(Source, Target)
        {
            this.FlagName = FlagName;
        }
    }

    public class UnFlaggedAnimationTransitionRule : AnimationTransitionRule
    {
        public string FlagName { get; }

        public UnFlaggedAnimationTransitionRule(SimpleAnimation Source, SimpleAnimation Target, string FlagName) : base(Source, Target)
        {
            this.FlagName = FlagName;
        }
    }

    public class TriggeredAnimationTransitionRule : AnimationTransitionRule
    {
        public string TriggerName { get; }

        public TriggeredAnimationTransitionRule(
            SimpleAnimation Source,
            SimpleAnimation Target,
            string TriggerName) : base(Source, Target)
        {
            this.TriggerName = TriggerName;
        }
    }

    public class AnimationTransitionRule
    {
        public AnimationTransitionRule(SimpleAnimation Source, SimpleAnimation Target)
        {
            this.Source = Source;
            this.Target = Target;
        }

        public SimpleAnimation Source { get; }
        public SimpleAnimation Target { get; }
    }

    public class SimpleAnimation
    {
        public Texture2D Texture { get; }
        public FrameController AnimationFrameChooser { get; }
        public bool HasEnded
        {
            get
            {
                return AnimationFrameChooser.HasEnded();
            }
        }

        public int X { get; set; }
        public int Y { get; set; }

        public SimpleAnimation(
            Texture2D Texture,
            FrameController AnimationFrameChooser,
            int X,
            int Y)
        {
            this.Texture = Texture;
            this.AnimationFrameChooser = AnimationFrameChooser;
            this.X = X;
            this.Y = Y;
        }

        public void Draw(SpriteBatch batch, int x = 0, int y = 0)
        {
            var frame = AnimationFrameChooser.GetNextFrame(DateTime.Now);
            batch.Draw(
                Texture,
                new Rectangle(
                    X + x,
                    Y + y,
                    frame.Width,
                    frame.Height),
                frame,
                Color.White);
        }

        public void Reset()
        {
            AnimationFrameChooser.Reset();
        }

        public SimpleAnimation AsScaleAnimation()
        {
            var AudioService = new AudioService();
            return new SimpleAnimation(Texture, AnimationFrameChooser.AsScale(AudioService.GetCurrent), X, Y);
        }

        public SimpleAnimation Reverse()
        {
            return new SimpleAnimation(Texture, AnimationFrameChooser.AsReverse(), X, Y);
        }

        public void SetFrameRate(int value)
        {
            AnimationFrameChooser.SetFrameRate(value);
        }
    }

    public class Animator
    {
        private AnimationTransitionRule[] Rules;
        private SimpleAnimation CurrentAnimation;
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
