using KinectRecorder.Replay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinectRecorder.Replay
{
    public class ToolBox
    {
        public class ReplaySkeletonFrameReadyEventArgs : EventArgs { public ReplaySkeletonFrame SkeletonFrame { get; set; } }
        public class ReplayColorImageFrameReadyEventArgs : EventArgs { public ReplayColorImageFrame ColorImageFrame { get; set; } }
        public class ReplayDepthImageFrameReadyEventArgs : EventArgs { public ReplayDepthImageFrame DepthImageFrame { get; set; } }
        
    }
}
