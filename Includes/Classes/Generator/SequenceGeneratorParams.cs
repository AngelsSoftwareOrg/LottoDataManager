﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoDataManager.Includes.Classes.Generator
{
    public class SequenceGeneratorParams
    {
        private GeneratorParamType generatorParamType;
        private String description;
        private Object paramValue;

        public GeneratorParamType GeneratorParamType { get => generatorParamType; set => generatorParamType = value; }
        public string Description { get => description; set => description = value; }
        public object ParamValue { get => paramValue; set => paramValue = value; }
    }
}
