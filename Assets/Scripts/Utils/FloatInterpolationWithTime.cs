using UnityEngine;


namespace GameplayUtils.LerpValueUtils
{
    ///<summary>
    /// This class is used to interpolate a float value from a min to a max value over a given time duration.
    /// You have control over when the lerp happens (when you call Tick() method) and when the lerp starts (when you call InitTime() method).

    /// Can be used in cases:
    /// - Increase difficulty of a game over time
    /// - Increase the speed of a game over time
    /// - Increase the size of a game object over time
    /// - Increase the damage of a game object over time

    ///</summary>
    public class FloatInterpolationWithTime
    {
        public float MinVal { get; private set; }
        public float MaxVal { get; private set; }
        public float DurationToMaxVal { get; private set; }
        public float TimeSinceStart { get; private set; }
        public float TimePassed { get; private set; }


        public FloatInterpolationWithTime(float min, float max, float durationToMaxDiffInSeconds)
        {
            MinVal = min;
            MaxVal = max;
            DurationToMaxVal = durationToMaxDiffInSeconds;
        }

        public void InitTime()
        {
            TimeSinceStart = TimeUtils.GetUnixTime();
            TimePassed = 0.0f;
        }

        public void Tick()
        {
            TimePassed += Time.deltaTime;
        }

        public float GetNewValue()
        {
            float timeSinceStartNormalized = TimePassed / DurationToMaxVal;
            float newVal = Mathf.Lerp(MinVal, MaxVal, timeSinceStartNormalized);
            return newVal;
        }

        public bool ReachedMaxVal() => TimePassed >= DurationToMaxVal;
    }
}