using Microsoft.Xna.Framework.Content;

namespace TriggeredAnimation
{
    public class Cartolina_Idle : TextureAnimation
    {
        public Cartolina_Idle(ContentManager content) : base(content)
        {
        }

        public override string GetAssetName()
        {
            return "idle";
        }

        protected override string GetJsonData() {
            return @"{""frames"": [

{
	""filename"": ""idle.swf0000"",
	""frame"": {""x"":0,""y"":0,""w"":101,""h"":167},
	""rotated"": false,
	""trimmed"": false,
	""spriteSourceSize"": {""x"":0,""y"":0,""w"":101,""h"":167},
	""sourceSize"": {""w"":101,""h"":167}
}
,{
	""filename"": ""idle.swf0001"",
	""frame"": {""x"":101,""y"":0,""w"":101,""h"":167},
	""rotated"": false,
	""trimmed"": false,
	""spriteSourceSize"": {""x"":0,""y"":0,""w"":101,""h"":167},
	""sourceSize"": {""w"":101,""h"":167}
}
,{
	""filename"": ""idle.swf0002"",
	""frame"": {""x"":202,""y"":0,""w"":101,""h"":167},
	""rotated"": false,
	""trimmed"": false,
	""spriteSourceSize"": {""x"":0,""y"":0,""w"":101,""h"":167},
	""sourceSize"": {""w"":101,""h"":167}
}
,{
	""filename"": ""idle.swf0003"",
	""frame"": {""x"":303,""y"":0,""w"":101,""h"":167},
	""rotated"": false,
	""trimmed"": false,
	""spriteSourceSize"": {""x"":0,""y"":0,""w"":101,""h"":167},
	""sourceSize"": {""w"":101,""h"":167}
}
,{
	""filename"": ""idle.swf0004"",
	""frame"": {""x"":404,""y"":0,""w"":101,""h"":167},
	""rotated"": false,
	""trimmed"": false,
	""spriteSourceSize"": {""x"":0,""y"":0,""w"":101,""h"":167},
	""sourceSize"": {""w"":101,""h"":167}
}
,{
	""filename"": ""idle.swf0005"",
	""frame"": {""x"":0,""y"":167,""w"":101,""h"":167},
	""rotated"": false,
	""trimmed"": false,
	""spriteSourceSize"": {""x"":0,""y"":0,""w"":101,""h"":167},
	""sourceSize"": {""w"":101,""h"":167}
}
,{
	""filename"": ""idle.swf0006"",
	""frame"": {""x"":101,""y"":167,""w"":101,""h"":167},
	""rotated"": false,
	""trimmed"": false,
	""spriteSourceSize"": {""x"":0,""y"":0,""w"":101,""h"":167},
	""sourceSize"": {""w"":101,""h"":167}
}
,{
	""filename"": ""idle.swf0007"",
	""frame"": {""x"":202,""y"":167,""w"":101,""h"":167},
	""rotated"": false,
	""trimmed"": false,
	""spriteSourceSize"": {""x"":0,""y"":0,""w"":101,""h"":167},
	""sourceSize"": {""w"":101,""h"":167}
}],
""meta"": {
	""app"": ""Adobe Flash CS6"",
	""version"": ""12.0.0.481"",
	""image"": ""idle.png"",
	""format"": ""RGBA8888"",
	""size"": {""w"":512,""h"":512},
	""scale"": ""1""
}
}
";
        }
    }
}
