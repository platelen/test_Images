using System;
using UnityEngine;

namespace Lesson_1.Orientation
{
    public class OrientationPhone : MonoBehaviour
    {
        public enum Orientation
        {
            Any,
            Portrait,
            PortraitFixed,
            Landscape,
            LandscapeFixed
        }

        public Orientation ScreenOrientation;

        private void Start()
        {
            Application.targetFrameRate = 60;

            switch (ScreenOrientation)
            {
                case Orientation.Any:
                    Screen.orientation = UnityEngine.ScreenOrientation.AutoRotation;

                    Screen.autorotateToPortrait = Screen.autorotateToPortraitUpsideDown = true;
                    Screen.autorotateToLandscapeLeft = Screen.autorotateToLandscapeRight = true;
                    break;

                case Orientation.Portrait:
                    Screen.orientation = UnityEngine.ScreenOrientation.Portrait;
                    Screen.orientation = UnityEngine.ScreenOrientation.AutoRotation;

                    Screen.autorotateToPortrait = Screen.autorotateToPortraitUpsideDown = true;
                    Screen.autorotateToLandscapeLeft = Screen.autorotateToLandscapeRight = false;
                    break;

                case Orientation.PortraitFixed:
                    Screen.orientation = UnityEngine.ScreenOrientation.Portrait;
                    break;

                case Orientation.Landscape:
                    Screen.orientation = UnityEngine.ScreenOrientation.LandscapeLeft;
                    Screen.orientation = UnityEngine.ScreenOrientation.LandscapeRight;
                    Screen.orientation = UnityEngine.ScreenOrientation.AutoRotation;

                    Screen.autorotateToPortrait = Screen.autorotateToPortraitUpsideDown = false;
                    Screen.autorotateToLandscapeLeft = Screen.autorotateToLandscapeRight = true;
                    Screen.autorotateToLandscapeRight = Screen.autorotateToLandscapeLeft = true;
                    break;
                case Orientation.LandscapeFixed:
                    Screen.orientation = UnityEngine.ScreenOrientation.LandscapeLeft;
                    break;
            }

            Destroy(gameObject);
        }
    }
}