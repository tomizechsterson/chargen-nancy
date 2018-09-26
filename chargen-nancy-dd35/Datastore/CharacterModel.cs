namespace chargen_nancy_dd35.Datastore
{
    public class CharacterModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static CharacterModel NullModel()
        {
            return new CharacterModel {Id = -1, Name = ""};
        }
    }
}