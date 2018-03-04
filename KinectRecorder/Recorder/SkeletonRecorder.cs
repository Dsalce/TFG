using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Kinect;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace KinectRecorder
{
  public  class SkeletonRecorder
    {
        DateTime referenceTime;

        readonly BinaryWriter writer;

        internal SkeletonRecorder(BinaryWriter writer)
        {

            this.writer = writer;

            referenceTime = DateTime.Now;

        }



        public void Record(SkeletonFrame frame)
        {

            // Header

            writer.Write((int)KinectRecordOptions.Skeletons);

            // Data

            TimeSpan timeSpan = DateTime.Now.Subtract(referenceTime);

            referenceTime = DateTime.Now;

            writer.Write((long)timeSpan.TotalMilliseconds);

            writer.Write(frame.FloorClipPlane.Item1);

            writer.Write(frame.FloorClipPlane.Item2);

            writer.Write(frame.FloorClipPlane.Item3);

            writer.Write(frame.FloorClipPlane.Item4);

            writer.Write(frame.FrameNumber);

            // Skeletons

            Skeleton[] skeletons = this.GetSkeletons(frame);



            BinaryFormatter formatter = new BinaryFormatter();

            formatter.Serialize(writer.BaseStream, skeletons);

        }
        public  Skeleton[] GetSkeletons( SkeletonFrame frame)
        {

            if (frame == null)

                return null;

            var skeletons = new Skeleton[frame.SkeletonArrayLength];

            frame.CopySkeletonDataTo(skeletons);

            return skeletons;

        }
    }
}
