using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LottoDataManager.Includes.Classes.Generator
{
    public class SequenceGeneratorParamFieldsFormFactory
    {
        private static SequenceGeneratorParamFieldsFormFactory seqGenParamFieldFormsFactory;

        private SequenceGeneratorParamFieldsFormFactory() { }

        public static SequenceGeneratorParamFieldsFormFactory GetInstance()
        {
            if (seqGenParamFieldFormsFactory == null) seqGenParamFieldFormsFactory = new SequenceGeneratorParamFieldsFormFactory();
            return seqGenParamFieldFormsFactory;
        }

        public Control GetControl(SequenceGeneratorParams seqParam)
        {
            if (seqParam.GeneratorParamType == GeneratorParamType.COUNT) return GetNumericUpAndDown(seqParam);

            return null;
        }


        private NumericUpDown GetNumericUpAndDown(SequenceGeneratorParams seqParam)
        {
            NumericUpDown numericUpDown = new NumericUpDown();
            numericUpDown.Minimum = 1;
            numericUpDown.Maximum = 10000;
            numericUpDown.Tag = seqParam;
            numericUpDown.ValueChanged += NumericUpDown_ValueChanged;
            numericUpDown.Value = 1;
            return numericUpDown;
        }

        private void NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown n = (NumericUpDown)sender;
            SequenceGeneratorParams seq = (SequenceGeneratorParams)n.Tag;
            seq.ParamValue = n.Value;
        }
    }
}
