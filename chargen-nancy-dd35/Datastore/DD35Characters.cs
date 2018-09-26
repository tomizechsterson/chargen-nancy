using System.Threading.Tasks;

namespace chargen_nancy_dd35.Datastore
{
    public interface DD35Characters
    {
        Task<CharacterModel[]> Get();
        Task<CharacterModel> Get(long id);
        Task<long> Add(CharacterModel model);
        Task Update(long id, CharacterModel model);
        Task Delete(long id);
    }
}