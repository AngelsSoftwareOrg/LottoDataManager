using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoDataManager.Includes.Classes.Generator.PickGenerationProgress
{
    public abstract class AbstractPickGenerationProgress
    {
        public event EventHandler<PickGenerationProgressEvent> PickGenerationProgress;
        private PickGenerationProgressEvent pickGenerationProgressEvent;
        private Boolean isPickGenerationRunning;
        protected AbstractPickGenerationProgress()
        {
            pickGenerationProgressEvent = new PickGenerationProgressEvent();
            IsPickGenerationRunning = false;
        }
        protected PickGenerationProgressEvent PickGenerationProgressEvent { get => pickGenerationProgressEvent; }
        public bool IsPickGenerationRunning { get => isPickGenerationRunning; set => isPickGenerationRunning = value; }
        protected void RaisePickGenerationProgress()
        {
            if (PickGenerationProgress == null) return;
            PickGenerationProgress.Invoke(this, PickGenerationProgressEvent);
        }
        protected bool IsContinuePickGenerationProgress()
        {
            RaisePickGenerationProgress();
            if (!IsPickGenerationRunning) return false;
            if (PickGenerationProgressEvent.IsGenerationAttemptCountReachMaxValue()) return false;
            return true;
        }
        public void ResetPickGenerationStats()
        {
            PickGenerationProgressEvent.ResetCounters();
        }
        protected void StartPickGeneration()
        {
            IsPickGenerationRunning = true;
            ResetPickGenerationStats();
        }
        public void StopPickGeneration()
        {
            IsPickGenerationRunning = false;
        }
    }
}
