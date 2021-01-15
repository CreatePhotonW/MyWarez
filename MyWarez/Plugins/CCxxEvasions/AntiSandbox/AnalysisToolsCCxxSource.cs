﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using System.Linq;

using MyWarez.Core;


namespace MyWarez.Plugins.CCxxEvasions
{
    // Contract: Returns true if analysistools processes are not running
    public interface IAnalysisTools : ICCxxSourceIParameterlessCFunction
    {
        public new string Name => "AnalysisTools";
    }

    // TODO: confirm if source is shellcodable. It looks like it'll be easy to modify it to be so
    // TODO: User specified set of analysis tools process names
    public sealed class IAnalysisToolsCCxxSource : CCxxSource, IAnalysisTools
    {
        private static readonly string ResourceDirectory = Path.Join(Core.Constants.PluginsResourceDirectory, "CCxxEvasions", "AntiSandbox", nameof(IAnalysisToolsCCxxSource));

        private static readonly string FunctionNamePlaceholder = "AnalysisTools";

        public IAnalysisToolsCCxxSource()
            : base(CreateSource())
        {
            FindAndReplace(SourceFiles, FunctionNamePlaceholder, ((ICFunction)this).Name);
        }

        string ICFunction.ReturnType => "BOOL";
        string ICFunction.Name => ((IAnalysisTools)this).Name + GetHashCode();
        public IEnumerable<string> ParameterTypes => null;

        public static ICCxxSource CreateSource()
        {
            var sourceFiles = SourceDirectoryToSourceFiles(ResourceDirectory);
            return new CCxxSource(sourceFiles);
        }
    }
}
