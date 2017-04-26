using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace TriggeredAnimation
{
    public class TriggeredAnimationTransitionRule : AnimationTransitionRule
    {
        public string  TriggerName { get; }

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

        public SimpleAnimation(
            Texture2D Texture,
            FrameController AnimationFrameChooser)
        {
            this.Texture = Texture;
            this.AnimationFrameChooser = AnimationFrameChooser;
        }

        public void Draw(SpriteBatch batch, int x, int y, Color color)
        {
            var frame = AnimationFrameChooser.GetNextFrame(DateTime.Now);
            batch.Draw(
                Texture,
                new Rectangle(
                    x,
                    y,
                    frame.Width,
                    frame.Height),
                frame,
                color);
        }

        public void Reset()
        {
            AnimationFrameChooser.Reset();
        }

        public SimpleAnimation AsScaleAnimation()
        {
            var AudioService = new AudioService();
            return new SimpleAnimation(Texture,AnimationFrameChooser.AsScale(AudioService.GetCurrent));
        }

        public SimpleAnimation Reverse()
        {
            return new SimpleAnimation(Texture, AnimationFrameChooser.AsReverse());
        }
    }

    public class Animator
    {
        private AnimationTransitionRule[] Rules;
        private SimpleAnimation CurrentAnimation;
        private List<string> Triggers;

        public Animator(params AnimationTransitionRule[] rules)
        {
            CurrentAnimation = rules[0].Source;
            Rules = rules;
            Triggers = new List<string>();
        }

        public void ActivateTrigger(string triggerName)
        {

            Triggers.Add(triggerName);
        }

        public void Draw(SpriteBatch batch, int x, int y, Color color)
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

            CurrentAnimation.Draw(batch, x, y, color);
        }
    }
}
