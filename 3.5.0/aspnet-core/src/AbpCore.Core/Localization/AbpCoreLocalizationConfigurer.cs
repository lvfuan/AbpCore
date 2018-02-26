using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace AbpCore.Localization
{
    public static class AbpCoreLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(AbpCoreConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(AbpCoreLocalizationConfigurer).GetAssembly(),
                        "AbpCore.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
