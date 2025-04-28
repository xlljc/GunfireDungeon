
using System.Text.Json.Serialization;

public partial class GameSave
{
    [JsonInclude]
    public DebugData Debug;
    
    public class DebugData
    {
        [JsonInclude]
        public float X = 500;
        
        [JsonInclude]
        public float Y = 10;

        [JsonInclude]
        public bool ShoFps;

        [JsonInclude]
        public bool DebugDraw;

        public void Init()
        {
            
        }
    }
}