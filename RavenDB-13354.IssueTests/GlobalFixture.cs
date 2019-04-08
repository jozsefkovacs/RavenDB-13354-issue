using Raven.Client.Documents;
using RavenDB_13354.Issue;
using System;
using Xunit;

namespace RavenDB_13354.IssueTests
{
    public class Globals
    {
        public const string InjectGlobalFixture = "GlobalFixture";
    }

    [CollectionDefinition(Globals.InjectGlobalFixture)]
    public class GlobalSetup : ICollectionFixture<GlobalSetupFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }

    /// <summary>
    /// Global setup fixture, ran once for all tests.
    /// </summary>
    /// <remarks>
    /// Docs: https://xunit.github.io/docs/shared-context#collection-fixture
    /// </remarks>
    public class GlobalSetupFixture : IDisposable
    {
        internal AppSettings _appSettings { get; set; }
        internal IDocumentStore _store { get; set; }
        internal readonly string _queryParam = "1";
        internal Entity _entity { get; set; }
        public GlobalSetupFixture()
        {
            ArrangeAppSettings();
            ArrangeMappings();
            ArrangeMocks();
        }

        private void ArrangeAppSettings()
        {
            var settings = new AppSettings
            {
                RavenDbEndpoint = "http://127.0.0.1:8080",
                RavenThreatDb = "threat"
            };

            _appSettings = settings;
        }

        private void ArrangeMappings()
        {
        }

        private void ArrangeMocks()
        {
            IDocumentStore store = new DocumentStore
            {
                Urls = new[] { _appSettings.RavenDbEndpoint },
                Database = _appSettings.RavenThreatDb,
                Conventions = { }
            };
            store.Initialize();
            _store = store;

            _entity = new Entity
            {
                Name = _queryParam, // = "1"
                NameComma = _queryParam,
                NameHypen = _queryParam,
                Conventional = new SubEntity
                {
                    Name = _queryParam,
                    NameComma = _queryParam,
                    NameHypen = _queryParam,
                },
                Conv__entional = new SubEntity
                {
                    Name = _queryParam,
                    NameComma = _queryParam,
                    NameHypen = _queryParam,
                },
                Conv_entional = new SubEntity
                {
                    Name = _queryParam,
                    NameComma = _queryParam,
                    NameHypen = _queryParam,
                },
                SubEntityComma = new SubEntity
                {
                    Name = _queryParam,
                    NameComma = _queryParam,
                    NameHypen = _queryParam,
                }
            };
        }

        private void Teardown()
        {
        }

        public void Dispose() => Teardown();
    }
}