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
            Animation Source,
            Animation Target,
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
        public AnimationTransitionRule(Animation Source, Animation Target)
        {
            this.Source = Source;
            this.Target = Target;
        }

        public Animation Source { get; }
        public Animation Target { get; }
    }

    public class Animation
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

        public Rectangle GetSourceRectangle()
        {
            return AnimationFrameChooser.GetNextFrame(DateTime.Now);
        }

        public void Reset()
        {
            AnimationFrameChooser.Reset();
        }
    }

    public class Animator
    {
        private AnimationTransitionRule[] Rules;
        private Animation CurrentAnimation;
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

            var sourceRectangle = CurrentAnimation.GetSourceRectangle();
            batch.Draw(
                 CurrentAnimation.Texture,
                 new Rectangle(
                     x,
                     y,
                     sourceRectangle.Width,
                     sourceRectangle.Height),
                 sourceRectangle,
                 color);
        }
    }
}
