using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoDataManager.Includes.Classes.Generator.PickGenerationProgress
{
    public class PickGenerationProgressEvent : EventArgs
    {
        private int generatedPickCount;
        private long generationAttemptCount;
        private long maxAttempt;

        public PickGenerationProgressEvent()
        {
            maxAttempt = long.MaxValue - 100;
            ResetCounters();
        }
        public int GeneratedPickCount { get => generatedPickCount; set => generatedPickCount = value; }
        public long GenerationAttemptCount { get => generationAttemptCount; set => generationAttemptCount = value; }

        public void ResetCounters()
        {
            GeneratedPickCount = 0;
            GenerationAttemptCount = 0;
        }
        public void IncrementGeneratedPickCount()
        {
            GeneratedPickCount++;
        }
        public void IncrementGenerationAttemptCount()
        {
            GenerationAttemptCount++;
        }
        public bool IsGenerationAttemptCountReachMaxValue()
        {
            return (GenerationAttemptCount > maxAttempt);
        }
    }
}
