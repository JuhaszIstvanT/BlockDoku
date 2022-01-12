using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using BlockDoku.Model;

namespace BlockDoku.Persistence
{
    public class FilePersistence : IPersistence
    {
        public Color[] Load(string path)
        {
            if (path == null)
                throw new ArgumentException("path");
            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    String[] numbers = reader.ReadToEnd().Split();

                    return numbers.Select(number => (Color)Int32.Parse(number)).ToArray();
                }
            }
            catch
            {
                throw new DataException("Error occured during reading.");
            }
        }

        public void Save(string path, Color[] values)
        {
            if (path == null)
                throw new ArgumentNullException("path");
            if (values == null)
                throw new ArgumentNullException("values");

            try
            {
                using (StreamWriter writer = new StreamWriter(path))
                {
                    writer.Write(values.Select(value => ((Int32)value).ToString()).Aggregate((value1, value2) => value1 + " " + value2));
                }
            }
            catch
            {
                throw new DataException("Error occured during writing.");
            }
        }
    }
}
