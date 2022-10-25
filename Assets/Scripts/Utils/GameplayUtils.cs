using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayUtils : MonoBehaviour
{
    public class DifficultyInterpolationWithTime
    {
        public float MinDifficulty { get; private set; }
        public float MaxDifficulty { get; private set; }
        public float DurationToMaxDifficulty { get; private set; }
        public int TimeSinceStart { get; private set; }
        public int TimePassed { get; private set; }


        public DifficultyInterpolationWithTime(float min, float max, float _durationToMaxDiffInSeconds)
        {
            MinDifficulty = min;
            MaxDifficulty = max;
            DurationToMaxDifficulty = _durationToMaxDiffInSeconds;
        }

        public void InitTime()
        {
            TimeSinceStart = TimeUtils.GetUnixTime();
            TimePassed = 0;
        }

        public void Update()
        {
            TimePassed = TimeUtils.GetUnixTime() - TimeSinceStart;
        }

        public float GetNewDifficultyValue()
        {
            float timeSinceStartNormalized = TimePassed / DurationToMaxDifficulty;
            float newDifficulty = Mathf.Lerp(MinDifficulty, MaxDifficulty, timeSinceStartNormalized);
            return newDifficulty;
        }

        public bool ReachedMaxDifficulty() => TimePassed >= DurationToMaxDifficulty;
    }
}
