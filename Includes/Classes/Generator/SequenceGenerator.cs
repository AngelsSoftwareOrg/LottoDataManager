using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoDataManager.Includes.Classes.Generator
{
    public interface SequenceGenerator
    {
        bool AreParametersValueValid(out String errMessage);
        List<int[]> GenerateSequence();
        String GetDescription();
        List<SequenceGeneratorParams> GetFieldParameters();
        void ResetParamsValue();
        int GetSequenceGeneratorID();
        GeneratorType GetSequenceGeneratorType();
    }
}
