using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  Microsoft.MixedReality.Toolkit.Input;

public class RecordView : MonoBehaviour
{
    // Start is called before the first frame update
    private InputRecordingService inputRecordingService;

    public void record()
    {
        inputRecordingService.StartRecording();
    }

    public void stop()
    {
        inputRecordingService.StopRecording();
        inputRecordingService.SaveInputAnimation("video", "Assets/Prefabs(universal)");
    }
    
}
