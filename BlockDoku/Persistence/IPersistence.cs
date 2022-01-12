using BlockDoku.Model;

namespace BlockDoku.Persistence
{
    public interface IPersistence
    {
        public Color[] Load(string path);

        public void Save(string path, Color[] values);
    }
}
