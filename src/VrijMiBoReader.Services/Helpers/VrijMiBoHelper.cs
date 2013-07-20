// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VrijMiBoHelper.cs" company="CatenaLogic">
//   Copyright (c) 2013 CatenaLogic. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace VrijMiBoReader
{
    using System;

    using Catel;

    public static class VrijMiBoHelper
    {
        public static string GetUrl(DateTime date, int index)
        {
            Argument.IsNotNull(() => date);
            Argument.IsMinimal(() => index, 1);

            var url = string.Format("{0}{1}/{2:00}/vrijmibo_{3}.html", Constants.GeenStijlArchiveUrl, date.Year, date.Month, index);
            return url;
        }

        public static string GetName(DateTime date, int index)
        {
            var name = string.Format("VrijMiBo {0} ({1})", index, date.ToLongDateString());
            return name;
        }
    }
}