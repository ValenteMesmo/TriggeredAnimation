﻿using Microsoft.Xna.Framework.Content;

namespace TriggeredAnimation
{
    public class Cartolina_Idle_Body : TextureAnimation
    {
        public Cartolina_Idle_Body(ContentManager content) : base(content)
        {
        }

        public override string GetAssetName()
        {
            return "idle_body";
        }

        protected override string GetJsonData()
        {
            return @"{""frames"": [

{
	""filename"": ""idle.swf0000"",
	""frame"": {""x"":0,""y"":0,""w"":101,""h"":128},
	""rotated"": false,
	""trimmed"": false,
	""spriteSourceSize"": {""x"":0,""y"":0,""w"":101,""h"":128},
	""sourceSize"": {""w"":101,""h"":128}
}
,{
	""filename"": ""idle.swf0001"",
	""frame"": {""x"":101,""y"":0,""w"":101,""h"":128},
	""rotated"": false,
	""trimmed"": false,
	""spriteSourceSize"": {""x"":0,""y"":0,""w"":101,""h"":128},
	""sourceSize"": {""w"":101,""h"":128}
}
,{
	""filename"": ""idle.swf0002"",
	""frame"": {""x"":0,""y"":128,""w"":101,""h"":128},
	""rotated"": false,
	""trimmed"": false,
	""spriteSourceSize"": {""x"":0,""y"":0,""w"":101,""h"":128},
	""sourceSize"": {""w"":101,""h"":128}
}
,{
	""filename"": ""idle.swf0003"",
	""frame"": {""x"":101,""y"":128,""w"":101,""h"":128},
	""rotated"": false,
	""trimmed"": false,
	""spriteSourceSize"": {""x"":0,""y"":0,""w"":101,""h"":128},
	""sourceSize"": {""w"":101,""h"":128}
}
,{
	""filename"": ""idle.swf0004"",
	""frame"": {""x"":0,""y"":256,""w"":101,""h"":128},
	""rotated"": false,
	""trimmed"": false,
	""spriteSourceSize"": {""x"":0,""y"":0,""w"":101,""h"":128},
	""sourceSize"": {""w"":101,""h"":128}
}
,{
	""filename"": ""idle.swf0005"",
	""frame"": {""x"":101,""y"":256,""w"":101,""h"":128},
	""rotated"": false,
	""trimmed"": false,
	""spriteSourceSize"": {""x"":0,""y"":0,""w"":101,""h"":128},
	""sourceSize"": {""w"":101,""h"":128}
}
,{
	""filename"": ""idle.swf0006"",
	""frame"": {""x"":0,""y"":384,""w"":101,""h"":128},
	""rotated"": false,
	""trimmed"": false,
	""spriteSourceSize"": {""x"":0,""y"":0,""w"":101,""h"":128},
	""sourceSize"": {""w"":101,""h"":128}
}],
""meta"": {
	""app"": ""Adobe Flash CS6"",
	""version"": ""12.0.0.481"",
	""image"": ""idle_body.png"",
	""format"": ""RGBA8888"",
	""size"": {""w"":256,""h"":512},
	""scale"": ""1""
}
}
";
        }
    }
}