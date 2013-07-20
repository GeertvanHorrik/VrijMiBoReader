// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ModuleInitializer.cs" company="CatenaLogic">
//   Copyright (c) 2013 CatenaLogic. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Catel.IoC;

using VrijMiBoReader.Cache;
using VrijMiBoReader.Services;

/// <summary>
/// Used by the ModuleInit. All code inside the Initialize method is ran as soon as the assembly is loaded.
/// </summary>
public static class ModuleInitializer
{
    #region Methods
    /// <summary>
    /// Initializes the module.
    /// </summary>
    public static void Initialize()
    {
        var serviceLocator = ServiceLocator.Default;

        serviceLocator.RegisterType<IEntryCache, EntryCache>();
        serviceLocator.RegisterType<ICrawlerService, CrawlerService>();
        serviceLocator.RegisterType<IParserService, ParserService>();
        
    }
    #endregion
}