using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if PLATFORM_ANDROID
using UnityEngine.Android;
#endif

using distriqt.plugins.vibration;
public class VibrationManager : MonoBehaviour
{
    private FeedbackGenerator _selectGenerator;
    private FeedbackGenerator _impactGenerator;

    public void Vibrate(string type)
    {
        if (Vibration.isSupported)
        {
            switch (type)
            {
                case "soft":
                    if (_selectGenerator == null)
                    {
                        _selectGenerator = Vibration.Instance.CreateFeedbackGenerator(FeedbackGeneratorType.SELECTION);
                    }
                    _selectGenerator.PerformFeedback();
                    break;

                case "hard":
                    if (_impactGenerator == null)
                    {
                        _impactGenerator = Vibration.Instance.CreateFeedbackGenerator(FeedbackGeneratorType.IMPACT);
                        _impactGenerator.Prepare();
                    }
                    _impactGenerator.PerformFeedback();
                    break;
            }
        }


    }
}
