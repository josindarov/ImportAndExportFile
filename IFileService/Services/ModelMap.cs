using CsvHelper.Configuration;
using Domain;

namespace Application.Services
{
    public class ModelMap : ClassMap<Model>
    {
        public ModelMap()
        {
            Map(m => m.Name).Name("PersonName");
            Map(m => m.Age).Name("Age");
            Map(m => m.Pet1).Name("Pet1");
            Map(m => m.Pet1Type).Name("Pet1Type");
            Map(m => m.Pet2).Name("Pet2");
            Map(m => m.Pet2Type).Name("Pet2Type");
            Map(m => m.Pet3).Name("Pet3");
            Map(m => m.Pet3Type).Name("Pet3Type");
        }
    }
}
