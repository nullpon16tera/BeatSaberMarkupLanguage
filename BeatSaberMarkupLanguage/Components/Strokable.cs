﻿using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace BeatSaberMarkupLanguage.Components
{
    public class Strokable : MonoBehaviour
    {
        public Image image;

        private static Sprite _roundRectSmallStroke;
        private static Sprite _roundRectBigStroke;

        public void SetType(StrokeType strokeType)
        {
            if (image == null)
                return;
            switch (strokeType)
            {
                case StrokeType.None:
                    image.enabled = false;
                    break;
                case StrokeType.Clean:
                    image.enabled = true;
                    if (_roundRectSmallStroke == null)
                        _roundRectSmallStroke = Resources.FindObjectsOfTypeAll<Sprite>().Last(x => x.name == "RoundRectSmallStroke");
                    image.sprite = _roundRectSmallStroke;
                    break;
                case StrokeType.Regular:
                    image.enabled = true;
                    if (_roundRectBigStroke == null)
                        _roundRectBigStroke = Resources.FindObjectsOfTypeAll<Sprite>().Last(x => x.name == "RoundRectBigStroke");
                    image.sprite = _roundRectBigStroke;
                    break;
            }
        }

        public void SetColor(string strokeColor)
        {
            if (image == null)
                return;
            if (!ColorUtility.TryParseHtmlString(strokeColor, out Color color))
                Logger.log.Warn($"Invalid color: {strokeColor}");
            image.color = color;
            image.enabled = true;
        }

        public enum StrokeType
        {
            None, Clean, Regular
        }
    }
}
