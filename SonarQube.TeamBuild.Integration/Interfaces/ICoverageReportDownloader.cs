﻿//-----------------------------------------------------------------------
// <copyright file="ICoverageReportDownloader.cs" company="SonarSource SA and Microsoft Corporation">
//   Copyright (c) SonarSource SA and Microsoft Corporation.  All rights reserved.
//   Licensed under the MIT License. See License.txt in the project root for license information.
// </copyright>
//-----------------------------------------------------------------------

using SonarQube.Common;
using System;
using System.Collections.Generic;

namespace SonarQube.TeamBuild.Integration
{
    public interface ICoverageReportDownloader // was internal
    {
        /// <summary>
        /// Downloads the specified files and returns a dictionary mapping the url to the name of the downloaded file
        /// </summary>
        /// <param name="tfsUri">The project collection URI</param>
        /// <param name="reportUrl">The file to be downloaded</param>
        /// <param name="downloadDir">The directory into which the files should be downloaded</param>
        /// <param name="newFileName">The name of the new file</param>
        /// <returns>True if the file was downloaded successfully, otherwise false</returns>
        bool DownloadReport(string tfsUri, string reportUrl, string newFullFileName, ILogger logger);
    }
}
