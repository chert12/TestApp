using UnityEngine;

namespace Chernov.Test.Data
{
    public class Constants
    {
        public class Filenames
        {
            public const string RecordsFolderName = "Records";
            public const string RecordFilenameTemplate = "record_{0}.txt";
        }
        
        public class Texts
        {
            public const string ClickForStartRecording = "Click for start recording";
            public const string Recording = "Recording...";
        }

        public class Colors
        {
            public static readonly Color MainAccent = new Color32(0, 175, 185, 255);
            public static readonly Color Red = new Color32(240, 113, 103, 255);
        }
    }
}