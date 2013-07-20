// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Constants.cs" company="CatenaLogic">
//   Copyright (c) 2013 CatenaLogic. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace VrijMiBoReader
{
    using System;

    public static class Constants
    {
        #region Constants
        public const string GeenStijlUrl = "http://www.geenstijl.nl/";

        public const string GeenStijlArchiveUrl = "http://www.geenstijl.nl/mt/archieven/";

        public const string GeenStijlRssFeedUrl = "http://www.geenstijl.nl/index.xml";

        public const int PatternStartIndex = 10;

        public static readonly DateTime PatternStartDate = new DateTime(2011, 1, 7); // January 7th, 2011 is a friday
        #endregion
    }
}