using Raven.Client.Documents;
using RavenDB_13354.Issue;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace RavenDB_13354.IssueTests
{
    [Collection(Globals.InjectGlobalFixture)]
    public class WhereClauseTests
    {
        private readonly GlobalSetupFixture _global;

        public WhereClauseTests(GlobalSetupFixture global) => _global = global;


        [Fact(DisplayName = "Should be able to save and read back the same data.")]
        public async Task InsertTest()
        {
            ReadRepository readRepository = new ReadRepository(_global._appSettings);

            var response = await readRepository.Save(_global._entity);
            Assert.True(response != null);

            var getResponse = await readRepository.Get(response.Id);
            Assert.True(getResponse != null);
        }

        [Theory(DisplayName = "Should be able to get Data from the Root props")]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public async Task Where_Root_Tests(int step)
        {
            ReadRepository readRepository = new ReadRepository(_global._appSettings);
            var response = await readRepository.Save(_global._entity);

            var session = readRepository.GetSessionForQuery();
            var docs = session.Query<Entity>();

            if (step == 1)
            {
                var filtered = docs.Where(t => t.Name == _global._queryParam);
                var result = await filtered.ToListAsync();
                Assert.True(result.Any());
            }

            if (step == 2)
            {
                var filtered = docs.Where(t => t.NameComma == _global._queryParam);
                var result = await filtered.ToListAsync();
                Assert.True(result.Any());
            }

            if (step == 3)
            {
                var filtered = docs.Where(t => t.NameHypen == _global._queryParam);
                var result = await filtered.ToListAsync();
                Assert.True(result.Any());
            }

        }

        [Theory(DisplayName = "Should be able to get Data from SubEntityComma")]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public async Task Where_SubEntity_Tests(int step)
        {

            ReadRepository readRepository = new ReadRepository(_global._appSettings);
            var response = await readRepository.Save(_global._entity);

            var session = readRepository.GetSessionForQuery();
            var docs = session.Query<Entity>();

            if (step == 1)
            {
                var filtered = docs.Where(t => t.SubEntityComma.Name == _global._queryParam);
                var result = await filtered.ToListAsync();
                Assert.True(result.Any());
            }

            if (step == 2)
            {
                var filtered = docs.Where(t => t.SubEntityComma.NameComma == _global._queryParam);
                var result = await filtered.ToListAsync();
                Assert.True(result.Any());
            }

            if (step == 3)
            {
                var filtered = docs.Where(t => t.SubEntityComma.NameHypen == _global._queryParam);
                var result = await filtered.ToListAsync();
                Assert.True(result.Any());
            }
        }

        [Theory(DisplayName = "Should be able to get Data from Conventional")]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public async Task Where_Conventional_Tests(int step)
        {

            ReadRepository readRepository = new ReadRepository(_global._appSettings);
            var response = await readRepository.Save(_global._entity);

            var session = readRepository.GetSessionForQuery();
            var docs = session.Query<Entity>();

            if (step == 1)
            {
                var filtered = docs.Where(t => t.Conventional.Name == _global._queryParam);
                var result = await filtered.ToListAsync();
                Assert.True(result.Any());
            }

            if (step == 2)
            {
                var filtered = docs.Where(t => t.Conventional.NameComma == _global._queryParam);
                var result = await filtered.ToListAsync();
                Assert.True(result.Any());
            }

            if (step == 3)
            {
                var filtered = docs.Where(t => t.Conventional.NameHypen == _global._queryParam);
                var result = await filtered.ToListAsync();
                Assert.True(result.Any());
            }
        }

        [Theory(DisplayName = "Should be able to get Data from Conv_entional")]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public async Task Where_Conv_entional_Tests(int step)
        {

            ReadRepository readRepository = new ReadRepository(_global._appSettings);
            var response = await readRepository.Save(_global._entity);

            var session = readRepository.GetSessionForQuery();
            var docs = session.Query<Entity>();

            if (step == 1)
            {
                var filtered = docs.Where(t => t.Conv_entional.Name == _global._queryParam);
                var result = await filtered.ToListAsync();
                Assert.True(result.Any());
            }

            if (step == 2)
            {
                var filtered = docs.Where(t => t.Conv_entional.NameComma == _global._queryParam);
                var result = await filtered.ToListAsync();
                Assert.True(result.Any());
            }

            if (step == 3)
            {
                var filtered = docs.Where(t => t.Conv_entional.NameHypen == _global._queryParam);
                var result = await filtered.ToListAsync();
                Assert.True(result.Any());
            }
        }

        [Theory(DisplayName = "Should be able to get Data from Conv__entional")]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public async Task Where_Conv__entional_Tests(int step)
        {

            ReadRepository readRepository = new ReadRepository(_global._appSettings);
            var response = await readRepository.Save(_global._entity);

            var session = readRepository.GetSessionForQuery();

            var docs = session.Query<Entity>();

            if (step == 1)
            {
                var filtered = docs.Where(t => t.Conv__entional.Name == _global._queryParam);
                var result = await filtered.ToListAsync();
                Assert.True(result.Any());
            }

            if (step == 2)
            {
                var filtered = docs.Where(t => t.Conv__entional.NameComma == _global._queryParam);
                var result = await filtered.ToListAsync();
                Assert.True(result.Any());
            }

            if (step == 3)
            {
                var filtered = docs.Where(t => t.Conv__entional.NameHypen == _global._queryParam);
                var result = await filtered.ToListAsync();
                Assert.True(result.Any());
            }
        }
    }
}
