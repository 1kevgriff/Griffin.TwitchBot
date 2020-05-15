using System;
using System.Collections.Generic;
using System.Text;

namespace Griffin.TwitchFunctions
{
    public class ShieldBadge
    {
        public int SchemaVersion { get; private set; } = 1;

        /// <summary>
        /// Left Text
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Right Text
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Right Color
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// Left Color
        /// 
        /// </summary>
        public string LabelColor { get; set; }

        /// <summary>
        /// Style
        /// 
        /// Options: flat, plastic, flat-square, for-the-badge, social 
        /// </summary>
        public string Style { get; set; }
    }
}
