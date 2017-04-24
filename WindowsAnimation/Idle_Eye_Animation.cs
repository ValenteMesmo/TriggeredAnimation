using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using TriggeredAnimation;

namespace WindowsAnimation
{
    class Idle_Eye_Animation : TextureAnimation
    {
        public Idle_Eye_Animation(ContentManager content) : base(content)
        {
        }

        public override string GetAssetName()
        {
            return "eyes";
        }

        protected override string GetJsonData()
        {
            return @"{""frames"": [

{
	""filename"": ""eyes.swf0000"",
	""frame"": {""x"":0,""y"":0,""w"":45,""h"":11},
	""rotated"": false,
	""trimmed"": false,
	""spriteSourceSize"": {""x"":0,""y"":0,""w"":45,""h"":11},
	""sourceSize"": {""w"":45,""h"":11}
}
,{
	""filename"": ""eyes.swf0001"",
	""frame"": {""x"":0,""y"":11,""w"":45,""h"":11},
	""rotated"": false,
	""trimmed"": false,
	""spriteSourceSize"": {""x"":0,""y"":0,""w"":45,""h"":11},
	""sourceSize"": {""w"":45,""h"":11}
}],
""meta"": {
	""app"": ""Adobe Flash CS6"",
	""version"": ""12.0.0.481"",
	""image"": ""eyes.png"",
	""format"": ""RGBA8888"",
	""size"": {""w"":64,""h"":64},
	""scale"": ""1""
}
}
";
        }
    }
}
