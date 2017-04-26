using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace TriggeredAnimation
{
    public class ParameterizedAnimationTransitionRule : AnimationTransitionRule
    {
        public Dictionary<string, string> Parameters { get; }

        public ParameterizedAnimationTransitionRule(
            IAnimation Source,
            IAnimation Target,
            params KeyValuePair<string, string>[] parameters) : base(Source, Target)
        {
            Parameters = new Dictionary<string, string>();

            foreach (var item in Parameters)
            {
                Parameters.Add(item.Key, item.Value);
            }
        }

    }

    public class AnimationTransitionRule
    {
        public AnimationTransitionRule(IAnimation Source, IAnimation Target)
        {
            this.Source = Source;
            this.Target = Target;
        }

        public IAnimation Source { get; }
        public IAnimation Target { get; }
    }

    public interface IAnimation
    {
        void Draw(SpriteBatch batch, int x, int y, Color color);
        void Reset();
        bool HasEnded { get; }
    }

    public class Animation : IAnimation
    {
        public Texture2D Texture { get; }
        public FrameChooser AnimationFrameChooser { get; }
        public bool HasEnded
        {
            get
            {
                return AnimationFrameChooser.HasEnded();
            }
        }

        public Animation(
            Texture2D Texture,
            FrameChooser AnimationFrameChooser)
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
    }

    public class EmptyAnimation : IAnimation
    {
        public bool HasEnded => true;

        public void Draw(SpriteBatch batch, int x, int y, Color color)
        {
            
        }

        public void Reset()
        {
            
        }
    }

    public class Animator
    {
        private AnimationTransitionRule[] Rules;
        private IAnimation CurrentAnimation;
        private Dictionary<string, string> Parameters;

        public Animator(params AnimationTransitionRule[] rules)
        {
            CurrentAnimation = rules[0].Source;
            Rules = rules;
            Parameters = new Dictionary<string, string>();
        }

        public void ChangeParameter(string key, string value)
        {
            if (Parameters.ContainsKey(key) == false)
                Parameters.Add(key, value);
            else
                Parameters[key] = value;
        }

        public void Draw(SpriteBatch batch, int x, int y, Color color)
        {
            foreach (var rule in Rules)
            {
                if (rule.Source == CurrentAnimation)
                {
                    if (rule is ParameterizedAnimationTransitionRule)
                    {
                        var allRulesPassed = true;
                        var ruleParameters = (rule as ParameterizedAnimationTransitionRule).Parameters;
                        foreach (var key in ruleParameters.Keys)
                        {
                            if (Parameters.ContainsKey(key) == false
                                || Parameters[key] != ruleParameters[key])
                                allRulesPassed = false;
                        }

                        if (allRulesPassed)
                        {
                            CurrentAnimation.Reset();
                            CurrentAnimation = rule.Target;
                            CurrentAnimation.Reset();
                        }
                    }
                    else
                    {
                        if (CurrentAnimation.HasEnded)
                        {
                            CurrentAnimation.Reset();
                            CurrentAnimation = rule.Target;
                            CurrentAnimation.Reset();
                        }
                    }
                }
            }

            CurrentAnimation.Draw(batch, x, y, color);
        }
    }
}
