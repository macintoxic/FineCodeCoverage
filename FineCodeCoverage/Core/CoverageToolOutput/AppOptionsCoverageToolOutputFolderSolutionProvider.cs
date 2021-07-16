using System;
using System.ComponentModel.Composition;
using Alphaleonis.Win32.Filesystem;
using FineCodeCoverage.Core.Utilities;
using FineCodeCoverage.Options;

namespace FineCodeCoverage.Engine
{
    [Order(1, typeof(ICoverageToolOutputFolderSolutionProvider))]
    class AppOptionsCoverageToolOutputFolderSolutionProvider : ICoverageToolOutputFolderSolutionProvider
    {
        private readonly IAppOptionsProvider appOptionsProvider;

        [ImportingConstructor]
        public AppOptionsCoverageToolOutputFolderSolutionProvider(IAppOptionsProvider appOptionsProvider)
        {
            this.appOptionsProvider = appOptionsProvider;
        }
        public string Provide(Func<string> solutionFolderProvider)
        {
            var appOptions = appOptionsProvider.Get();
            if (!String.IsNullOrEmpty(appOptions.FCCSolutionOutputDirectoryName))
            {
                var solutionFolder = solutionFolderProvider();
                if(solutionFolder != null)
                {
                    return Path.Combine(solutionFolder, appOptions.FCCSolutionOutputDirectoryName);
                }
            }
            return null;
        }
    }
}
